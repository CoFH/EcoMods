// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
namespace Eco.Mods.Organisms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using Eco.Core.Utils;
    using Eco.Core.Items;
    using Eco.Gameplay.Interactions;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Minimap;
    using Eco.Gameplay.Plants;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Rooms;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared;
    using Eco.Shared.Math;
    using Eco.Shared.Networking;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.SharedTypes;
    using Eco.Simulation;
    using Eco.Simulation.Agents;
    using Eco.Simulation.Types;
    using Eco.World;
    using Eco.World.Blocks;
    using Eco.Gameplay.GameActions;
    using Eco.Simulation.WorldLayers.Pushers;
    using Eco.Shared.Localization;
    using Eco.Shared.Items;
    using Eco.Gameplay.Civics;
    using Vector3 = System.Numerics.Vector3;
    using System.ComponentModel;
    using Eco.Gameplay.Interactions.Interactors;

    using Eco.Mods.TechTree;

    [Serialized]
    [Tag(BlockTags.Choppable)]
    class TrunkPiece
    {
        [Serialized] public Guid ID;
        [Serialized] public float SliceStart;
        [Serialized] public float SliceEnd;

        public double LastUpdateTime;
        [Serialized] public Vector3 Position;
        [Serialized] public Vector3 Velocity;
        [Serialized] public Quaternion Rotation;

        [Serialized] public bool Collected;

        public bool IsValid => World.IsLegalVerticalPosition(this.Position);
        public bool IsCollectedOrNotValid => !this.IsValid || this.Collected; // Returns collected if valid. We will count this as collected if its not valid

        public BSONObject ToUpdateBson()
        {
            var bson    = BSONObject.New;
            bson["id"]  = this.ID;
            bson["pos"] = this.Position;
            bson["rot"] = this.Rotation;
            bson["v"]   = this.Velocity;
            return bson;
        }

        public BSONObject ToInitialBson()
        {
            var bson          = BSONObject.New;
            bson["id"]        = this.ID;
            bson["start"]     = this.SliceStart;
            bson["end"]       = this.SliceEnd;
            bson["pos"]       = this.Position;
            bson["rot"]       = this.Rotation;
            bson["v"]         = this.Velocity;
            bson["collected"] = this.Collected;
            return bson;
        }
    }

    // gameplay version of simulations tree
    [Serialized] public class TreeEntity : Tree, IDamageable, IHasInteractions
    {
        readonly object sync = new();

        /// <summary>This needs to be 5, because 5 is the max yield bonus, and 5+5=10 is the max log stack size.</summary>
        private const int MaxTrunkPickupSize = 5;
        /// <summary>Max number of tree debris spawn from the tree.</summary>
        private const int MaxTreeDebris = 20;

        // the list of all the slices done to this trunk
        [Serialized] readonly ThreadSafeList<TrunkPiece> trunkPieces = new ThreadSafeList<TrunkPiece>();

        public override bool UpRooted => this.stumpHealth <= 0;

        public override float SaplingGrowthPercent => 0.3f;

        // estimated, need to get better measurements w/ and w/o Top branch
        private static readonly float[] GrowthThresholds = new float[7] { 0.20f, 0.28f, 0.38f, 0.48f, 0.57f, 0.78f, 0.95f };
        private int currentGrowthThreshold = 0;
        private int treeDebrisSpawned; // it is runtime variable, it shouldn't spawn from felt trees so should be fine, but even if hacked someway it will produce at max 10 debris after restart

        public double LastUpdateTime { get; private set; }
        float lastKeyframeTime;

        [Serialized] public int ChopperUserID { get; protected set; } = -1;//who chopped down this tree have access to its trunks regardless of thier position

        public override IEnumerable<Vector3> TrunkPositions { get { return this.trunkPieces.Where(x => !x.Collected).Select(x => x.Position); } }

        private ThreadSafeHashSet<Vector3i> groundHits;
        MinimapObject minimapObject = new();

        public override bool Ripe
        {
            get
            {
                if (this.Fallen && this.trunkPieces.All(piece => piece.IsCollectedOrNotValid))
                    return false;
                return this.GrowthPercent >= this.SaplingGrowthPercent;
            }
        }

        public override bool GrowthBlocked
        {
            get
            {
                if (this.Fallen || this.GrowthPercent >= 1f)
                    return true;
                if ((this.currentGrowthThreshold >= GrowthThresholds.Length) // already at max occupied spaces
                    || this.GrowthPercent < GrowthThresholds[this.currentGrowthThreshold])
                    return false;
                var block = World.GetBlock(this.Position.XYZi() + (Vector3i.Up * (this.currentGrowthThreshold + 1)));
                if (!block.Is<Empty>() && block.GetType() != this.Species.BlockType)
                        return true; // can't grow until obstruction is removed
                return false;
            }
        }

        public override float GrowthPercent
        {
            get => base.GrowthPercent;
            set { base.GrowthPercent = Mathf.Clamp01(value); this.UpdateGrowthOccupancy(); }
        }

        private void UpdateGrowthOccupancy()
        {
            if (this.IsGrowthConditionsNotMet) return; //Check if we can't grow, species is null or is already fallen.

            WrappedWorldPosition3i position = this.Position.XYZi() + (Vector3i.Up * this.currentGrowthThreshold);
            bool canGrow = position.TryIncreaseY(1, out position);

            if (canGrow)
            {
                // check if block is empty
                var block = World.GetBlock(position);
                if (!block.Is<Empty>() && block.GetType() != this.Species.BlockType) canGrow = false;
            }

            if (!canGrow)
            {
                base.GrowthPercent = GrowthThresholds[this.currentGrowthThreshold] - 0.01f;
                return; // cap growth at slightly less than threshold, can't grow until obstruction is removed
            }

            this.currentGrowthThreshold++;
            World.SetBlock(this.Species.BlockType, position);
            this.UpdateMinimapObjectScale(); //Update minimap tree icon only when growth threshold is reached.
            this.LastUpdateTime = TimeUtil.Seconds;
        }

        private bool IsGrowthConditionsNotMet => this.Species == null || this.Fallen || this.currentGrowthThreshold >= GrowthThresholds.Length || this.GrowthPercent < GrowthThresholds[this.currentGrowthThreshold];
        private bool CanHarvest => this.branches.None(branch => branch != null && branch.Health > 0f);  // can't harvest if any branches are still alive

        public INetObjectViewer Controller { get; private set; }
    
        float ResourceMultiplier => (this.Species.ResourceRange.Diff * this.GrowthPercent) + this.Species.ResourceRange.Min;
        int GetBasePickupSize(TrunkPiece trunk) => Math.Max(Mathf.RoundUpToInt((trunk.SliceEnd - trunk.SliceStart) * this.ResourceMultiplier), 1);

        [Interaction(InteractionTrigger.InteractKey, requiredEnvVars: new[] { "canPickup", "id" }, animationDriven: true)]                        //A definition for when we can actually pickup
        public void PickUp(Player player, InteractionTriggerInfo trigger, InteractionTarget target) 
        { 
            if (target.TryGetParameter("id", out var id)) 
                this.PickupLog(player, (Guid) id, target.HitPos); 
        }

        #region IController
        int controllerID;

        public ref int ControllerID => ref this.controllerID;
    #pragma warning disable CS0067
        public event PropertyChangedEventHandler PropertyChanged; //Disabled warning for property not being used, but its needed for change notifications to work
    #pragma warning restore CS0067
        #endregion

        public TreeEntity(TreeSpecies species, WorldPosition3i position, PlantPack plantPack)
            : base(species, position, plantPack)
        { }

        // needed for serialization
        protected TreeEntity()
        { }

        public override void Initialize()
        {
            base.Initialize();
            this.UpdateGrowthOccupancy();
            this.minimapObject.Position              = this.Position;
            this.minimapObject.Type                  = this.Species.GetType();
            this.minimapObject.DisplayObjectCategory = Localizer.DoStr("Trees");
            this.minimapObject.DisplayName           = this.Species.DisplayName;

            this.UpdateMinimapObjectScale();
            if (!this.Fallen)
                MinimapManager.Obj.Objects.Add(this.minimapObject);
        }

        //The scale formula for the minimap is based on the Species's Scale and the Tree's Growth.
        void UpdateMinimapObjectScale()
        {
            if (this.Species == null || this.Fallen) return;

            float scaleXZ            = this.Species.XZScaleRange.Interpolate(this.scaleRandomValue);                      // Get a random XZ size based on the species range
            float scaleY             = this.Species.YScaleRange.Interpolate(this.scaleRandomValue);                       // Get a random Y  size based on the species range
            this.minimapObject.Scale = new Vector3(scaleXZ, scaleY, scaleXZ) * Mathf.Lerp(0.25f, 1f, this.GrowthPercent); // Scale multiplied by growth percent (clamped min so newborn trees can be seen in minimap).
        }

        void CheckDestroy()
        {
            // destroy the tree if it has fallen, all the trunk pieces are collected, and the stump is removed
            if (this.Fallen && this.stumpHealth <= 0 && this.trunkPieces.All(piece => piece.IsCollectedOrNotValid))
                this.Destroy();
        }

        void PickupLog(Player player, Guid logID, Vector3 pickupPosition)
        {
            lock (this.sync)
            {
                if (!this.CanHarvest)
                    player.ErrorLocStr("Log is not ready for harvest.  Remove all branches first.");

                var trunk = this.trunkPieces.FirstOrDefault(p => p.ID == logID);
                if (trunk?.IsCollectedOrNotValid == false)
                {
                    //Check log size, if its too big, it can't be picked up
                    var canPickup = this.GetBasePickupSize(trunk) <= MaxTrunkPickupSize;
                    if (!canPickup)
                    {
                        player.ErrorLocStr("Log is too large to pick up, slice into smaller pieces first.");
                        return;
                    }

                    var resourceType = this.Species.ResourceItemType;
                    var resource     = Item.Get(resourceType);
                    var baseCount    = this.GetBasePickupSize(trunk);
                    var yield        = resource.Yield;
                    var bonusItems   = yield?.GetCurrentValueInt(player.User.DynamicValueContext, null) ?? 0;
                    var numItems     = baseCount + bonusItems;
                    var carried      = player.User.Inventory.Carried;

                    if (numItems > 0)
                    {
                        if (!carried.IsEmpty) // Early tests: neeed to check type mismatch and max quantity.
                        { 
                            if      (carried.Stacks.First().Item.Type != resourceType)                    { player.Error(Localizer.Format("You are already carrying {0:items} and cannot pick up {1:items}.", carried.Stacks.First().Item.UILink(LinkConfig.ShowPlural), resource.UILink(LinkConfig.ShowPlural)));  return; }                        
                            else if (carried.Stacks.First().Quantity + numItems > resource.MaxStackSize)  { player.Error(Localizer.Format("You can't carry {0:n0} more {1:items} ({2} max).", numItems, resource.UILink(numItems != 1 ? LinkConfig.ShowPlural : 0), resource.MaxStackSize));                        return; } 
                        }

                        // Prepare a game action pack.
                        var pack = new GameActionPack();
                            pack.AddPostEffect          (() => { trunk.Collected = true; this.RPC("DestroyLog", logID); this.MarkDirty(); this.CheckDestroy(); }); // Delete the log if succseeded.
                            pack.GetOrCreateInventoryChangeSet   (carried, player.User).AddItems(this.Species.ResourceItemType, numItems);                         // Add items to the changeset.
                            pack.AddGameAction          (new HarvestOrHunt() {   Species         = this.Species.GetType(),
                                                                                 HarvestedStacks = new ItemStack(Item.Get(this.Species.ResourceItemType), numItems).SingleItemAsEnumerable(),
                                                                                 ActionLocation  = pickupPosition.XYZi(),
                                                                                 Citizen         = player.User,
                                                                                 ChopperUserID   = this.ChopperUserID});                  
                            pack.TryPerform(player.User); // Try to perform the action and apply changes & effects.
                    }
                }
            }
        }

        #region RPCs
        [RPC]
        public void DestroyLeaf(int leafID)
        {
            this.GetLeafByID(leafID, out var branchID, out var leafIdOnBranch);
            TreeBranch branch = this.branches[branchID];
            LeafBunch leaf    = branch.Leaves[leafIdOnBranch];

            if (leaf.Health > 0)
            {
                // replicate to all clients
                leaf.Health = 0;
                this.RPC("DestroyLeaves", branchID, leafIdOnBranch);
            }
        }

        [RPC]
        public void DestroyBranch(int branchID)
        {
            TreeBranch branch = this.branches[branchID];

            if (branch.Health > 0)
            {
                // replicate to all clients
                branch.Health = 0;
                this.RPC("DestroyBranch", branchID);
            }

            this.MarkDirty();
        }

        TrunkPiece GetTrunkPiece(float slicePoint) => this.trunkPieces.FirstOrDefault(p => p.SliceStart < slicePoint && p.SliceEnd > slicePoint);

        private Result TrySliceTrunkInternal(float slicePoint, INetObject player)
        {
            lock (this.sync) // prevent threading issues due to multiple choppers
            {
                // find the trunk piece this is coming from
                var trunkPiece = this.GetTrunkPiece(slicePoint);
                if (trunkPiece == null) return Result.FailedNoMessage;

                // if this is a tiny slice, clamp to the nearest valid size
                const float minPieceResources = 5f;
                var         minPieceSize      = minPieceResources / this.ResourceMultiplier;
                var         targetSize        = trunkPiece.SliceEnd - trunkPiece.SliceStart;
                var         targetResources   = targetSize * this.ResourceMultiplier;
                var         newPieceSize      = trunkPiece.SliceEnd - slicePoint;
                var         newPieceResources = newPieceSize * this.ResourceMultiplier;
                if (targetResources <= minPieceResources) return Result.FailLocStr("This log cannot be sliced any smaller");          // can't slice, too small

                if (targetResources < (2 * minPieceResources))               slicePoint = trunkPiece.SliceStart + (.5f * targetSize); // if smaller than 2x the min size, slice directly in half
                else if (newPieceSize < minPieceSize)                        slicePoint = trunkPiece.SliceEnd - minPieceSize;         // round down to nearest slice point where the resulting block will be the size of the log
                else if (slicePoint - trunkPiece.SliceStart <= minPieceSize) slicePoint = trunkPiece.SliceStart + minPieceSize;       // round up

                var sourceID = trunkPiece.ID;
                // slice and assign new IDs (New piece is always the back end of the source piece)
                var newPiece = new TrunkPiece()
                {
                    ID         = Guid.NewGuid(),
                    SliceStart = slicePoint,
                    SliceEnd   = trunkPiece.SliceEnd,
                    Position   = trunkPiece.Position,
                    Rotation   = trunkPiece.Rotation,
                };
                this.trunkPieces.Add(newPiece);
                trunkPiece.ID       = Guid.NewGuid();
                trunkPiece.SliceEnd = slicePoint;

                // ensure the pieces are listed in order
                this.trunkPieces.Sort((a, b) => a.SliceStart.CompareTo(b.SliceStart));

                // reciprocate to clients
                this.RPC("SliceTrunk", slicePoint, sourceID, trunkPiece.ID, newPiece.ID);

                PlantSimEvents.OnLogChopped.Invoke((player as Player)?.User);

                this.MarkDirty();
                return Result.Succeeded;
            }
        }

        [RPC]
        public void CollideWithTerrain(Player player, Vector3i position)
        {
            if (player != this.Controller)
                return;

            lock (this.sync)
            {
                if (this.groundHits == null)
                    this.groundHits = new ThreadSafeHashSet<Vector3i>();
            }

            // Prevent spawning more than MaxGroundHits debris for one tree
            if (this.treeDebrisSpawned >= MaxTreeDebris)
                return;

            // destroy plants and spawn dirt within a radius under the hit position
            var radius = 1;
            for (var x = -radius; x <= radius; x++)
                for (var z = -radius; z <= radius; z++)
                {
                    var offsetpos = position + new Vector3i(x, -1, z);
                    if (!this.groundHits.Add(offsetpos))
                        continue;

                    var abovepos = offsetpos + Vector3i.Up;
                    var aboveblock = World.GetBlock(abovepos);
                    var hitblock = World.GetBlock(offsetpos);
                    if (!aboveblock.Is<Solid>())
                    {
                        // turn soil into dirt
                        if (hitblock.GetType() == typeof(GrassBlock) || hitblock.GetType() == typeof(ForestSoilBlock))
                        {
                            player.SpawnBlockEffect(offsetpos, typeof(DirtBlock), BlockEffect.Delete);
                            World.SetBlock<DirtBlock>(offsetpos);
                            BiomePusher.AddFrozenColumn(offsetpos.XZ);
                        }

                        // kill any above plants
                        if (aboveblock is PlantBlock)
                        {
                            // make sure there is a plant here, sometimes world/ecosim are out of sync
                            var plant = EcoSim.PlantSim.GetPlant(abovepos);
                            if (plant != null)
                            {
                                player.SpawnBlockEffect(abovepos, aboveblock.GetType(), BlockEffect.Delete);
                                EcoSim.PlantSim.DestroyPlant(plant, DeathType.Logging, true, player.User);
                            }
                            else World.DeleteBlock(abovepos);
                        }

                        if (hitblock.Is<Solid>() && World.GetBlock(abovepos).Is<Empty>() && RandomUtil.Value < this.Species.ChanceToSpawnDebris)
                        {
                            GameActionAccumulator.Obj.AddGameActions(new CreateTreeDebris()
                            {
                                Count = 1,
                                ActionLocation = abovepos,
                                Citizen = player.User
                            }, player?.User);

                            World.SetBlock(this.Species.DebrisType, abovepos);
                            player.SpawnBlockEffect(abovepos, this.Species.DebrisType, BlockEffect.Place);
                            RoomData.QueueRoomTest(abovepos);
                            if (Interlocked.Increment(ref this.treeDebrisSpawned) >= MaxTreeDebris) return;
                        }
                    }
                }
        }
        #endregion

        ChopTree CreateChopTreeAction(INetObject damager, Item tool, bool felled, bool branches = false) => new ChopTree()
        {
            Citizen          = (damager as Player)?.User,
            Species          = this.Species.GetType(),
            ChopperUserID    = this.ChopperUserID,
            ActionLocation   = this.Position.XYZi(),
            AccessNeeded     = AccessType.FullAccess,
            Felled           = felled,
            BranchesTargeted = branches,
            GrowthPercent    = this.GrowthPercent * 100,
            ToolUsed         = tool
        };

        void FellTree(INetObject killer)
        {
            // create the initial trunk piece
            var trunkPiece = new TrunkPiece() { ID = Guid.NewGuid(), SliceStart = 0f, SliceEnd = 1f,  };

            // clear tree occupancy
            if (this.Species.BlockType != null)
            {
                var treeBlockCheck = this.Position.XYZi() + Vector3i.Up;
                while (World.GetBlock(treeBlockCheck).GetType() == this.Species.BlockType)
                {
                    World.DeleteBlock(treeBlockCheck);
                    treeBlockCheck += Vector3i.Up;
                }
            }

            this.trunkPieces.Add(trunkPiece);

            var player = killer as Player;
            if (player != null)
            {
                this.SetPhysicsController(player);                        // set the killing player's client as the one in control of the physics of the tree. Handled by "FellTree".
                player.RPC("YellTimber");                                 // Issue sound effect.
            }

            this.RPC("FellTree", trunkPiece.ID, this.ResourceMultiplier); // Fell the tree
            Animal.AlertNearbyAnimals(this.Position, 15f);                // Alert nearby animals to aware about falling tree

            // break off any branches that are young
            for (var branchID = 0; branchID < this.branches.Length; branchID++)
            {
                var branch = this.branches[branchID];
                if (branch == null)
                    continue;

                var branchAge = Mathf.Clamp01((float)((this.GrowthPercent - branch.SpawnAge) / (branch.MatureAge - branch.SpawnAge)));
                if (branchAge <= .5f)
                    this.DestroyBranch(branchID);
            }

            if (player != null)
                PlantSimEvents.TreeFelledEvent.Invoke(player.User, this.Species);
            MinimapManager.Obj.Objects.Remove(this.minimapObject);

            this.MarkDirty();
        }

        public GameActionPack TryApplyDamage(GameActionPack pack, INetObject damager, float amount, InteractionTarget target, Item tool, out float damageReceived, Type damageDealer = null, float experienceMultiplier = 1f)
        {
            damageReceived = amount;

            //If the tree is really young, just outright uproot and destroy it
            if (this.IsSapling) return this.TryKillSapling(pack, damager, tool);
            else if (target.TryGetParameter(BlockParameterNames.IsTrunk, out _))              return this.TryDamageTrunk (pack, damager, amount, tool);
            else if (target.TryGetParameter(BlockParameterNames.IsStump, out _))              return this.TryDamageStump (pack, damager, amount, tool);
            else if (target.TryGetParameter(BlockParameterNames.Branch,  out var branchID))   return this.TryDamageBranch(pack, damager, amount, (int)branchID,     tool);
            else if (target.TryGetParameter(BlockParameterNames.Slice,   out var slicePoint)) return this.TrySliceTrunk  (pack, damager, amount, (float)slicePoint, tool);
            else if (target.TryGetParameter(BlockParameterNames.Leaf,    out var leafID))     return this.TryDamageLeaf  (pack, damager, amount, (int)leafID,       tool);
    
            DebugUtils.Fail($"Failed to damage a tree - tree is not a sapling and we can't determine which part of the tree should be damaged because of missing parameters in {nameof(target)}.");
            pack.EarlyResult = Result.FailedNoMessage;
            return pack;
        }

        /// <summary>Perform damaging healthy branches and trunk (if it's a fallen tree).</summary>
        private GameActionPack TrySliceTrunk(GameActionPack pack, INetObject damager, float amount, float slicePoint, Item tool)
        {
            //If there are still branches, damage them instead
            for (var branchID = 0; branchID < this.branches.Length; branchID++)
                this.TryDamageBranch(pack, damager, amount, branchID, tool);

            //If the tree is fallen, damage it
            if (this.Fallen) pack.AddGameAction(this.CreateChopTreeAction(damager, tool, false));
        
            //Cut into slices if action is a success
            pack.AddPostEffect(() => this.TrySliceTrunkInternal(slicePoint, damager));
            return pack;
        }

        private GameActionPack TryKillSapling(GameActionPack pack, INetObject damager, Item tool)
        {
            pack.AddGameAction(this.CreateChopTreeAction(damager, tool, true));
            pack.AddPostEffect(() => EcoSim.PlantSim.DestroyPlant(this, DeathType.Harvesting, killer:damager is Player damagerPlayer ? damagerPlayer.User : null));
            return pack;
        }

        private GameActionPack TryDamageTrunk(GameActionPack pack, INetObject damager, float amount, Item tool)
        {
            var user = (damager as Player)?.User;
            if (this.health <= 0) return pack;

            pack.AddGameAction(this.CreateChopTreeAction(damager, tool, this.health <= amount));

            pack.AddPostEffect(() =>
            { 
                // damage trunk
                var damageDone = InterlockedUtils.SubMinNonNegative(ref this.health, amount);
                if (damageDone <= 0f) return;

                this.RPC("UpdateHP", this.health / this.Species.TreeHealth);

                if (this.health <= 0)
                {
                    this.health = 0;
                    this.FellTree(damager);
                    this.ChopperUserID = damager is Player player ? player.User.Id : -1;
                    EcoSim.PlantSim.KillPlant(this, DeathType.Logging, true);

                    // Trunk Cleanup
                    if (user != null && user.Talentset.HasTalent(typeof(LoggingLoggersLuckTalent)))
                    {
                        if (World.GetBlock(this.Position.XYZi()).GetType() == this.Species.BlockType) World.DeleteBlock(this.Position.XYZi());
                        this.stumpHealth = 0;

                        //give tree resources
                        var changes = InventoryChangeSet.New(user.Inventory, user);
                        var trunkResources = this.Species.TrunkResources;
                        if (trunkResources != null) trunkResources.ForEach(x => changes.AddItems(x.Key, x.Value.RandInt));
                        else DebugUtils.Fail("Trunk resources missing for: " + this.Species.Name);
                        changes.TryApply();

                        this.RPC("DestroyStump");

                        // Let another plant grow here
                        EcoSim.PlantSim.UpRootPlant(this);
                    }
                }

                this.MarkDirty();
            });
            return pack;
        }

        private GameActionPack TryDamageStump(GameActionPack pack, INetObject damager, float amount, Item tool)
        {
            if (this.Fallen && this.stumpHealth > 0)
            {
                var player = damager as Player;
                if (player != null)
                {
                    pack.AddGameAction(new ChopStump()
                    {
                        Citizen        = player.User,
                        ActionLocation = this.Position.XYZi(),
                        Destroyed      = this.stumpHealth <= amount,
                        Species        = this.Species.GetType(),
                        ToolUsed       = tool
                    });
                }

                pack.AddPostEffect(() =>
                {
                    this.stumpHealth = Mathf.Max(0, this.stumpHealth - amount);

                    if (this.stumpHealth <= 0)
                    {
                        if (World.GetBlock(this.Position.XYZi()).GetType() == this.Species.BlockType) World.DeleteBlock(this.Position.XYZi());
                        this.stumpHealth = 0;
                        //give tree resources
                        if (player != null)
                        {
                            var changes = InventoryChangeSet.New(player.User.Inventory, player.User);
                            var trunkResources = this.Species.TrunkResources;
                            if (trunkResources != null) trunkResources.ForEach(x => changes.AddItems(x.Key, x.Value.RandInt));
                            else DebugUtils.Fail("Trunk resources missing for: " + this.Species.Name);
                            changes.TryApply();
                        }
                        this.RPC("DestroyStump");

                        // Let another plant grow here
                        EcoSim.PlantSim.UpRootPlant(this);
                    }

                    this.MarkDirty();
                    this.CheckDestroy();
                });
            }
            else this.TryDamageTrunk(pack, damager, amount, tool);

            return pack;
        }

        private GameActionPack TryDamageLeaf(GameActionPack pack, INetObject damager, float amount, int leafID, Item tool)
        {
            var leaf = this.GetLeafByID(leafID, out var branchID, out var leafIdOnBranch);
            if (leaf != null && leaf.Health > 0)
            {
                pack.AddGameAction(this.CreateChopTreeAction(damager, tool, false, true));
                pack.AddPostEffect(() =>
                {
                    if ((leaf.Health = Mathf.Max(0, leaf.Health - amount)) == 0) this.RPC("DestroyLeaves", branchID, leafIdOnBranch);
                    this.MarkDirty();
                });
            }
        
            return pack;
        }

        /// <summary>LeafID on the client is unique for the whole tree not just the branch, this takes that unique id and returns the leaf while outputting ID of the branch the leaf is on and leaf ID relative to the branch</summary>
        LeafBunch GetLeafByID(int leafID, out int branchID, out int leafIdOnBranch)
        {
            branchID = 0;
            for (; branchID < this.branches.Length; branchID++) //Iterate through all of the branches
            {
                var branch = this.branches[branchID];                         //Get the branch so we can check its leaves
                if (branch == null) continue;                                 //if the branch is null it has no leaves (trees can have null branches for variety)
                var branchLeavesCount = branch.Leaves.Length;                 //since leaf ID is based on amount of total leaves on the tree, if LeafID is greater than total leaf count on that branch its not the correct branch
                if (leafID >= branchLeavesCount) leafID -= branchLeavesCount; //so we reduce leafID by the leaf count of that branch (to do same check for the next branch) and increment branch ID
                else break;                                                   //do this until we are left with a branch where leaf count is more than the modified leaf ID, that is the parent branch of our leaf
            }
            var leaf = this.branches[branchID].Leaves[leafID];
            leafIdOnBranch = leafID;
            return leaf;
        }

        private GameActionPack TryDamageBranch(GameActionPack pack, INetObject damager, float amount, int branchID, Item tool)
        {
            var branch = this.branches[branchID];
            if (branch != null && branch.Health > 0)
            {
                pack.AddGameAction(this.CreateChopTreeAction(damager, tool, false, true));
                pack.AddPostEffect(() =>
                { 
                    if ((branch.Health = Mathf.Max(0, branch.Health - amount)) == 0) { this.RPC("DestroyBranch", branchID); this.MarkDirty(); }
                });
            }
            return pack;
        }

        public override void SendInitialState(BSONObject bsonObj, INetObjectViewer viewer)
        {
            base.SendInitialState(bsonObj, viewer);

            // if we have trunk pieces, send those
            this.trunkPieces.RemoveNulls();
            var trunkInfo = BSONArray.New;
            if (this.trunkPieces.Count > 0)
            {
                foreach (var trunkPiece in this.trunkPieces)
                    if (trunkPiece.IsValid) trunkInfo.Add(trunkPiece.ToInitialBson());
            }
            bsonObj["trunks"] = trunkInfo;

            if (this.Controller != null && this.Controller is INetObject)
                bsonObj["controller"] = ((INetObject)this.Controller).ID;

            bsonObj["mult"] = this.ResourceMultiplier;
            bsonObj["density"] = this.Species.Density;
        }

        public override void SendUpdate(BSONObject bsonObj, INetObjectViewer viewer)
        {
            base.SendUpdate(bsonObj, viewer);

            if (this.Fallen && this.Controller != viewer)
            {
                var trunkInfo = BSONArray.New;
                foreach (var trunkPiece in this.trunkPieces)
                {
                    if (trunkPiece.Position == Vector3.Zero || !trunkPiece.IsValid)
                        continue;
                    if (trunkPiece.LastUpdateTime < viewer.LastSentUpdateTime)
                        continue;

                    trunkInfo.Add(trunkPiece.ToUpdateBson());
                }
                bsonObj["trunks"] = trunkInfo;
                bsonObj["time"] = this.lastKeyframeTime;
            }
        }

        public override void ReceiveUpdate(BSONObject bsonObj)
        {
            bool changed = false;
            if (!bsonObj.ContainsKey("trunks"))
                return;
            BSONArray trunks = bsonObj["trunks"].ArrayValue;
            foreach (BSONObject obj in trunks)
            {
                Guid id = obj["id"];
                TrunkPiece piece = this.trunkPieces.FirstOrDefault(p => p.ID == id);

                if (piece != null && (piece.Position != obj["pos"] || piece.Rotation != obj["rot"]))
                {
                    piece.Position = obj["pos"];
                    piece.Rotation = obj["rot"];
                    piece.Velocity = obj["v"];
                    piece.LastUpdateTime = TimeUtil.Seconds;
                    changed = true;
                }
            }

            if (changed)
            {
                this.lastKeyframeTime = bsonObj["time"];
                this.LastUpdateTime = TimeUtil.Seconds;
            }
        }

        #region mostly copied from NetPhysicsEntity
        public override bool IsRelevant(INetObjectViewer viewer)
        {
            if (viewer is IWorldObserver observer)
            {
                var closestWrapped = World.ClosestWrappedLocation(observer.Position, this.Position);
                var v = closestWrapped - observer.Position;
                if (World.WrappedDistanceSq(this.Position, observer.Position) < observer.ChunkViewDistance.VisibleSq)
                {
                    if (this.Controller == null)
                        this.SetPhysicsController(observer);
                    return true;
                }
            }
            return false;
        }

        public override bool IsNotRelevant(INetObjectViewer viewer)
        {
            if (viewer is not IWorldObserver observer) return false;                                   // only can check for IWorldObserver
            var closestWrapped     = World.ClosestWrappedLocation(observer.Position, this.Position);
            var notVisibleDistance = observer.ChunkViewDistance.NotVisible;
            var v                  = closestWrapped - observer.Position;
            if (Mathf.Abs(v.X) >= notVisibleDistance || Mathf.Abs(v.Z) >= notVisibleDistance)         // check if any of horizontal distances to viewer length enough to go out of view
            {
                if (this.Controller != null && this.Controller.Equals(viewer))                        // in that case reset owning physics controller
                    this.SetPhysicsController(null);
                return true;                                                                          // and return true
            }
            else
            {
                // Still relevant, Check if viewer would be a better controller (observer is very close and current controller is far enough)
                if (this.Controller is not IWorldObserver current)
                    this.SetPhysicsController(observer);
                else if (current != observer && Vector2.WrappedDistance(observer.Position.XZ(), this.Position.XZ()) < 10f)
                {
                    if (Vector2.WrappedDistance(current.Position.XZ(), this.Position.XZ()) > 15f)
                        this.SetPhysicsController(observer);
                }
                return false;
            }
        }

        public bool SetPhysicsController(INetObjectViewer owner)
        {
            // Trees don't need physics until felled
            if (!this.Fallen)
                return false;

            if (Equals(this.Controller, owner))
                return false;

            this.Controller?.RemoveDestroyAction(this.RemovePhysicsController);

            this.Controller = owner;

            this.Controller?.AddDestroyAction(this.RemovePhysicsController);

            if (owner is INetObject netObject)
                this.NetObj.Controller.RPC("UpdateController", netObject.ID);

            return true;
        }

        void RemovePhysicsController()
        {
            this.SetPhysicsController(null);
        }
        #endregion

        /// <summary> Check if we need to send the update to client based on update time. </summary>
        public override bool IsUpdated(INetObjectViewer viewer)
        {
            if (this.LastUpdateTime > viewer.LastSentUpdateTime) return true;
            return false;
        }

        public override void Destroy()
        {
            var treeBlockCheck = this.Position.XYZi();
            for (int i = 0; i <= GrowthThresholds.Length; i++)
            {
                var block = World.GetBlock(treeBlockCheck);
                if (block.GetType() == this.Species.BlockType)
                    World.DeleteBlock(treeBlockCheck);
                if (block.Is<Solid>())
                    break;
                treeBlockCheck += Vector3i.Up;
            }
            MinimapManager.Obj.Objects.Remove(this.minimapObject);
            base.Destroy();
        }
    }
}
