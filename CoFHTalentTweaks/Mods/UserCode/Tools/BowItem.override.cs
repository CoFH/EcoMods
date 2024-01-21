// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.TechTree
{
    using System;
    using Eco.Core.Controller;
    using Eco.Core.Items;
    using Eco.Gameplay.Animals;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.GameActions;
    using Eco.Gameplay.Interactions;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Shared.Localization;
    using Eco.Shared.Math;
    using Eco.Shared.Networking;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.Voxel;
    using Eco.Shared.Items;
    using Eco.Simulation.Agents;
    using Vector3 = System.Numerics.Vector3;
    using System.ComponentModel;
    using Eco.Shared.SharedTypes;
	using Eco.Gameplay.Interactions.Interactors;

	[Tag("Harvester")]
    [Serialized]
    [LocDisplayName("Bow")]
    [Weight(0)]
    [Category("Hidden")]
    public abstract partial class BowItem : RangeWeaponItem, IInteractor
    {
        private static readonly SkillModifiedValue CaloriesBurnValue;
        private static readonly SkillModifiedValue DamageValue;

        static BowItem()
        {
            CaloriesBurnValue = CreateCalorieValue(20, typeof(HuntingSkill), typeof(BowItem));
            DamageValue = CreateDamageValue(1, typeof(HuntingSkill), typeof(BowItem));
        }

        private static readonly IDynamicValue SkilledRepairCostValue = new ConstantValue(5);
        public override IDynamicValue SkilledRepairCost              => SkilledRepairCostValue;
        public override ItemHandOrigin HandOrigin                    => ItemHandOrigin.Left;
        public override IDynamicValue CaloriesBurn                   => CaloriesBurnValue;
        public override IDynamicValue Damage                         => DamageValue;
        public override Type ExperienceSkill                         => typeof(HuntingSkill);
        private static readonly IDynamicValue Exp                    = new ConstantValue(1f);
        public override IDynamicValue ExperienceRate                 => Exp;
        public override Tag RepairTag                                => TagManager.Tag("Log");
        public override int FullRepairAmount                         => 5;
        protected virtual Type ToolType                              => typeof(BowItem);
        public override ItemCategory ItemCategory                    => ItemCategory.Bow;
        [SyncToView] public virtual float FireVelocity               => 55f;       // Initial arrow velocity
        [SyncToView] public virtual float DrawTime                   => 1f;        // How long to draw the bow in total
        [SyncToView] public virtual string ArrowPrefab               => "Arrow";   // What arrow prefab will be used

        [Interaction(InteractionTrigger.LeftClick, canHoldToTrigger: TriBool.True, animationDriven: true, Flags = InteractionFlags.NoTargetRequired)]
        public void ShootInteraction(Player player, InteractionTriggerInfo trigger, InteractionTarget target) { }

        [RPC]
        public int Shoot(Player player, Vector3 position, Vector3 velocity)
        {
            // If the player has an arrow to fire then use the bow, but do not gain any experience from using the tool. Experience is ONLY gained if the Arrow hits an animal.
            if (player.User.Inventory.TryRemoveItem<ArrowItem>(player.User) && AtomicActions.UseToolNow(this.CreateMultiblockContext(player, false)))
            {
                var arrow = new ArrowEntity
                {
                    Damage = this.Damage.GetCurrentValue(player.User),                  // Set the Damage so that Experience Points are gained if the arrow hits an animal.
                    Controller = player,
                    Position = position,
                    Velocity = velocity,
                    BowItem = this
                };
                arrow.SetActiveAndCreate();
                return arrow.ID;
            }
            return -1;
        }
    }

    public class ArrowEntity : NetEntity, IDetectHarvest
    {
        public BowItem BowItem { get; set; }
        public float Damage { get; set; }
        public INetObjectViewer Controller { get; set; }
        public Vector3 Velocity { get; set; }
        public NetObjAttachInfo Attached;
        private readonly double destroyTime;
        private const double LifeTime    = 120f;
        //This value is really high so it will have few false-positive cheating checks. Otherwise it's almost impossible to hunt something with ping 300
        //May be reduced when animal syncing will be improoved.
        private const float HeadDistance = 50f;

        public ArrowEntity()
            : base("Arrow")
        {
            this.destroyTime = TimeUtil.Seconds + LifeTime;
        }

        [RPC]
        public override void Destroy()
        {
            // let clients help decide when to destroy
            base.Destroy();
        }

        [RPC]
        public void Hit(NetObjAttachInfo hitAttachInfo, Vector3 position, string location)
        {
            if (!(this.Controller is Player player)) return;

            var target = NetObjectManager.Default.GetNetObject(hitAttachInfo.ParentID);

            // Prevent attaching to targets that are not within accessible distance
            if (target is INetObjectPosition targetPosition && World.WrappedDistance(targetPosition.Position, position) > HeadDistance)
            {
                this.Destroy();
                return;
            }

            switch (target)
            {
                // bow only damages animals // Auth will be checked inside TryApplyDamage via HarvestOrHunt. Other cases are harmless.
                case AnimalEntity targetAnimal:
                {
                    targetAnimal.AttachedEntities.Add(this);

                    var experienceMultiplier = 0.5f * this.Damage;
                    var locationMultiplier = 1f;
                    var hitHead = location.Contains("Head");

                    // player will do x1.5 damage when hit head and x2.25 if they have HuntingDeadeyeTalent; experience scales with damage
                    if (hitHead)
                    {
                        experienceMultiplier *= 0.5f;
                        locationMultiplier *= 1.5f;
                        if (player.User.Talentset.HasTalent(typeof(HuntingDeadeyeTalent)))  // This makes it a multiplicative 50% and not additive
                        {
                            experienceMultiplier *= 0.5f;
                            locationMultiplier *= 1.5f;
                        }
                    }
                    // player experience is now based on damage and get x0,5 of it
                    // var experienceMultiplier = hitHead ? player.User.Talentset.HasTalent(typeof(HuntingDeadeyeTalent)) ? 1f * this.Damage : 0.75f * this.Damage : 0.5f * this.Damage;
                    // player will do x1,5 damage when hit head and x2 if they have HuntingDeadeyeTalent
                    // var locationMultiplier = hitHead ? player.User.Talentset.HasTalent(typeof(HuntingDeadeyeTalent)) ? 2f : 1.5f : 1f;
                    if (targetAnimal.TryApplyDamage(new(), player, this.Damage * locationMultiplier, new() { TargetObjNetID = targetAnimal.ID }, this.BowItem, out float damageDealt, typeof(ArrowItem), experienceMultiplier).TryPerform(player.User))
                    {
                        hitAttachInfo.HitInfo = Text.Color(hitHead ? Color.Red.HexRGBA : Color.Orange.HexRGBA, Text.Num(damageDealt));
                        this.Attached = hitAttachInfo;
                    }
                    else if (targetAnimal.Dead)
                        this.Attached = hitAttachInfo;
                    else
                    this.Destroy();
                    break;
                }
                case Player targetPlayer:
                    // arrows look silly sticking in player capsule colliders
                    player.ErrorLoc($"You must obtain authorization to shoot {targetPlayer.User.MarkedUpName}.");
                    this.Destroy();
                    break;
                default:
                    this.Attached = hitAttachInfo;
                    break;
            }

            Animal.AlertNearbyAnimals(this.Position, 15f);

            if (this.Attached != null)
                this.RPC("Attach", this.Attached);

            this.Position = position;
            this.Rotation = Quaternion.LookRotation(this.Velocity.Normalize());
            this.Velocity = Vector3.Zero;
        }

        [RPC]
        public void HitStatic(Vector3 position, Quaternion rotation)
        {
            this.Position = position;
            this.Rotation = rotation;
            this.Velocity = Vector3.Zero;
            this.RPC("Attach", position, rotation);
            Animal.AlertNearbyAnimals(this.Position, 15f);
        }

        public override bool IsRelevant(INetObjectViewer viewer)
        {
            if (this.Attached != null)
            {
                var obj = NetObjectManager.Default.GetNetObject(this.Attached.ParentID);
                if (obj != null)
                    return obj.IsRelevant(viewer);

                this.Destroy();
                return false;
            }

            return base.IsRelevant(viewer);
        }

        public override bool IsNotRelevant(INetObjectViewer viewer)
        {
            if (TimeUtil.Seconds > this.destroyTime)
            {
                this.Destroy();
                return true;
            }

            if (this.Attached != null)
            {
                var obj = NetObjectManager.Default.GetNetObject(this.Attached.ParentID);
                if (obj != null)
                    return obj.IsNotRelevant(viewer);

                this.Destroy();
                return true;
            }

            return base.IsNotRelevant(viewer);
        }

        public override void SendUpdate(BSONObject bsonObj, INetObjectViewer viewer)
        {
            if (this.Attached == null)
                base.SendUpdate(bsonObj, viewer);
        }

        public override void SendInitialState(BSONObject bsonObj, INetObjectViewer viewer)
        {
            base.SendInitialState(bsonObj, viewer);
            if (this.Attached != null)
                bsonObj["attached"] = (this.Attached as IBsonSerialize).ToBson();
            bsonObj["v"] = this.Velocity;
            if (this.Controller != null && this.Controller is INetObject)
                bsonObj["controller"] = ((INetObject) this.Controller).ID;
        }

        public void OnHarvest(Player player)
        {
            var talent = player?.User.Talentset.GetTalent(typeof(HuntingArrowRecoveryTalent));
            if (talent != null && RandomUtil.Chance(talent.Value))
                player.User.Inventory.TryAddItems(typeof(ArrowItem), 1);

        }
    }
}
