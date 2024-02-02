namespace Eco.Gameplay.Items
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel;
    using System.Linq;
    using Eco.Core.Controller;
    using Eco.Core.Items;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.GameActions;
    using Eco.Gameplay.Interactions.Interactors;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Items.Recipes;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Gameplay.Utils;
    using Eco.Mods.TechTree;
    using Eco.Shared.Localization;
    using Eco.Shared.Localization;
    using Eco.Shared.Math;
    using Eco.Shared.Serialization;
    using Eco.Shared.SharedTypes;
    using Eco.Shared.Utils;
    using Eco.Simulation.WorldLayers;
    using Eco.World;
    using Eco.World.Blocks;

    [Serialized] // Tells the save/load system this object needs to be serialized. 
    [LocDisplayName("Activated Charcoal")] // Defines the localized name of the item.
    [LocDescription("Charcoal which has been pulverized and chemically treated to massively increase its adsorbency.")] //The tooltip description for the item.
    [Weight(500)] // Defines how heavy ActivatedCharcoal is.
    [Category("Tool")] // Gives this item the category of "Tool" for organization
    [MaxStackSize(50)]
    public partial class ActivatedCharcoalItem : ToolItem, IInteractor, IStackableMergable
    {
        public override IDynamicValue CaloriesBurn => new ConstantValue(0);

        public override float DurabilityRate => 0.0f;

        [Interaction(InteractionTrigger.RightClick, tags: new string[] { BlockTags.Samplable, BlockTags.Clearable })]
        public bool ApplyToSoil(Player player, InteractionTriggerInfo triggerInfo, InteractionTarget target)
        {
            if (triggerInfo == InteractionTrigger.RightClick) return this.Amend(player, triggerInfo, target);
            return false;
        }

        // Attempts to alter the target block by applying this tool's effects to it.
        bool Amend(Player player, InteractionTriggerInfo trigger, InteractionTarget target)
        {
            if (!target.IsBlock) return false;

            var climateSim = WorldLayerManager.Obj.ClimateSim;
            if (climateSim.GroundPollution.EntryWorldPos(target.BlockPosition.Value.XZ) <= 0.01) return false;

            var pack = new GameActionPack(new FertilizeAction()
            {
                ActionLocation = target.BlockPosition.Value,   
                Citizen = player.User,
                ItemUsed = this,
            });

            pack.GetOrCreateInventoryChangeSet(player.User.Inventory, player.User).RemoveItem(this.Type);

            // If everything goes well, adjust Ground Pollution.
            pack.AddPostEffect(()=>
            { 
                climateSim.AddGroundPollution(target.BlockPosition.Value.XZ, -1f);
                if (climateSim.GroundPollution.EntryWorldPos(target.BlockPosition.Value.XZ) <= 0)
                {
                    climateSim.GroundPollution.SetAtWorldPos(target.BlockPosition.Value.XZ, 0);
                }
            });

            return pack.TryPerform(player.User);
        }

        public bool CanStack(Item stackingOntoItem) => true;

        public int StackableQualityGroup() => 0;

        public Item Merge(Item another, int first, int second)
        {
            return this;
        }

        static ActivatedCharcoalItem() { } // so static members are created
    }

}