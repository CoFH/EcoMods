// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

#nullable enable

namespace Eco.Mods.TechTree
{
    using System;
    using System.ComponentModel;
    using Eco.Core.Items;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.GameActions;
    using Eco.Gameplay.Interactions.Interactors;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Shared.Localization;
    using Eco.Shared.SharedTypes;
    using Eco.Shared.Items;
    using Eco.Simulation;
    using Eco.Simulation.Types;
    using Eco.World;
    using Eco.World.Blocks;
    using Eco.Mods.Organisms;
    using Eco.Gameplay.Utils;
    using Eco.Shared.Math;
    using System.Linq;
    using System.Collections.Generic;
    using Eco.Shared.Utils;

    [Category("Hidden"), Tag("Logging")]
    public abstract partial class AxeItem : MeleeWeaponItem, IInteractor
    {
        static IDynamicValue caloriesBurn      = new ConstantValue(0);
        static IDynamicValue damage            = new ConstantValue(100);
        static IDynamicValue tier              = new ConstantValue(0);
        static IDynamicValue skilledRepairCost = new ConstantValue(1);

        public override Item            RepairItem            => Item.Get<StoneItem>();
        public override int             FullRepairAmount      => 1;
        public override IDynamicValue   CaloriesBurn          => caloriesBurn;
        public override IDynamicValue   Damage                => damage;
        public override IDynamicValue   Tier                  => tier;
        public override IDynamicValue   SkilledRepairCost     => skilledRepairCost;
        public override Type            ExperienceSkill       => typeof(LoggingSkill);
        public override ItemCategory    ItemCategory          => ItemCategory.Axe;
        
        //Only block an axe can interact with is tree debris block
        public override bool IsValidForInteraction(Item item) => item is LogItem;

        [Interaction(InteractionTrigger.LeftClick, tags: BlockTags.Choppable, DisallowedEnvVars = new[] {"felled" }, AnimationDriven = true, InteractionDistance = 1.5f)] //Dont allow felled trees to be chopped, they get 'sliced' with a different limiter (below interaction)
        [Interaction(InteractionTrigger.LeftClick, "Slice", requiredEnvVars: new[] { "slice" }, highlightColorHex: InteractionHexColors.Yellow, AnimationDriven = true, InteractionDistance = 1.5f)]
        public bool Chop(Player player, InteractionTriggerInfo triggerInfo, InteractionTarget target)
        {
            if (triggerInfo == InteractionTrigger.LeftClick)
            {
                //Try delete tree debris with reduced XP multiplier
                if (target.IsBlock && this.TryCreateMultiblockContext(out var multiblockContext, target, player, tagsTargetable: BlockTags.Choppable))
                    using (var pack = new GameActionPack()) //Create game action pack, compose and try to perform
                    {
                        if (target.IsBlock && target.Block().Get<TreeDebris>() is TreeDebris treeDebris)
                        {
                            #region CHANGED BY CoFHTalentTweaks
                            if (player.User.Talentset.HasTalent(typeof(LoggingCleanupCrewTalent)))
                            {
                                multiblockContext.CaloriesPerAction = 0;
                                multiblockContext.RepairableItem = null;
                            }
                            #endregion

                            //Add debris items to inventory
                            foreach (var x in ((TreeSpecies)EcoSim.GetSpecies(treeDebris.Species)).DebrisResources)
                                pack.AddToInventory(player.User.Inventory, Item.Get(x.Key), x.Value.RandInt, player.User);
                        }

                        //Set description and reduce XP multiplier for cleaning debris
                        multiblockContext.ActionDescription = GameActionDescription.DoStr("clean up tree debris", "cleaning up tree debris");
                        multiblockContext.ExperiencePerAction *= 0.1f;

                        pack.DeleteBlock(multiblockContext);           //Add block deletion to the pack and try to perform it

                        return !pack.TryPerform(player.User).Failed;   //Return true on success and false on failure
                    }

                //Try to interact with tree
                if (target.NetObj is TreeEntity tree)
                {
                    var action = tree.TryApplyDamage(new(), player, this.Damage.GetCurrentValue(player!.User) + this.PerkDamage.GetCurrentValue(player!.User), target, this, out _);
                    action.UseTool(this.CreateMultiblockContext(player, !target.TryGetParameter(BlockParameterNames.Slice, out var _), tree.Position.XYZi())); //Only give xp by chopping trunks, not slicing.
                    return action.TryPerform(player.User).Success;
                }
            }
            
            return false;
        }
    }
}
