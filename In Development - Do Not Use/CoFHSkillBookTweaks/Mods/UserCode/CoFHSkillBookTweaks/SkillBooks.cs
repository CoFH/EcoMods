namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using Eco.Core.Items;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Simulation.Time;
    using Eco.Gameplay.Items.Recipes;

    public partial class AdvancedBakingSkillBook : SkillBook<AdvancedBakingSkill, AdvancedBakingSkillScroll> {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            this.Skill.SkillTree.Parent.StaticSkill.SkillTree.TryDiscover(WorldTime.Seconds, player.User); //Trigger a discover for the root skill, in case the user gave themselves this book with a /give command to test discovery.
            this.Skill.SkillTree.TryDiscover(WorldTime.Seconds, player.User); //Trigger a discover, in case the user gave themselves this book with a /give command to test discovery.

            return string.Empty;
        }
    }

    public partial class AdvancedCookingSkillBook : SkillBook<AdvancedCookingSkill, AdvancedCookingSkillScroll> {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            this.Skill.SkillTree.Parent.StaticSkill.SkillTree.TryDiscover(WorldTime.Seconds, player.User); //Trigger a discover for the root skill, in case the user gave themselves this book with a /give command to test discovery.
            this.Skill.SkillTree.TryDiscover(WorldTime.Seconds, player.User); //Trigger a discover, in case the user gave themselves this book with a /give command to test discovery.

            return string.Empty;
        }
    }

    public partial class AdvancedMasonrySkillBook : SkillBook<AdvancedMasonrySkill, AdvancedMasonrySkillScroll> {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            this.Skill.SkillTree.Parent.StaticSkill.SkillTree.TryDiscover(WorldTime.Seconds, player.User); //Trigger a discover for the root skill, in case the user gave themselves this book with a /give command to test discovery.
            this.Skill.SkillTree.TryDiscover(WorldTime.Seconds, player.User); //Trigger a discover, in case the user gave themselves this book with a /give command to test discovery.

            return string.Empty;
        }
    }

    public partial class AdvancedSmeltingSkillBook : SkillBook<AdvancedSmeltingSkill, AdvancedSmeltingSkillScroll> {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            this.Skill.SkillTree.Parent.StaticSkill.SkillTree.TryDiscover(WorldTime.Seconds, player.User); //Trigger a discover for the root skill, in case the user gave themselves this book with a /give command to test discovery.
            this.Skill.SkillTree.TryDiscover(WorldTime.Seconds, player.User); //Trigger a discover, in case the user gave themselves this book with a /give command to test discovery.

            return string.Empty;
        }
    }

    public partial class BakingSkillBook : SkillBook<BakingSkill, BakingSkillScroll> {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            this.Skill.SkillTree.Parent.StaticSkill.SkillTree.TryDiscover(WorldTime.Seconds, player.User); //Trigger a discover for the root skill, in case the user gave themselves this book with a /give command to test discovery.
            this.Skill.SkillTree.TryDiscover(WorldTime.Seconds, player.User); //Trigger a discover, in case the user gave themselves this book with a /give command to test discovery.

            return string.Empty;
        }
    }

    public partial class BasicEngineeringSkillBook : SkillBook<BasicEngineeringSkill, BasicEngineeringSkillScroll> {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            this.Skill.SkillTree.Parent.StaticSkill.SkillTree.TryDiscover(WorldTime.Seconds, player.User); //Trigger a discover for the root skill, in case the user gave themselves this book with a /give command to test discovery.
            this.Skill.SkillTree.TryDiscover(WorldTime.Seconds, player.User); //Trigger a discover, in case the user gave themselves this book with a /give command to test discovery.

            return string.Empty;
        }
    }

    public partial class ButcherySkillBook : SkillBook<ButcherySkill, ButcherySkillScroll> {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            this.Skill.SkillTree.Parent.StaticSkill.SkillTree.TryDiscover(WorldTime.Seconds, player.User); //Trigger a discover for the root skill, in case the user gave themselves this book with a /give command to test discovery.
            this.Skill.SkillTree.TryDiscover(WorldTime.Seconds, player.User); //Trigger a discover, in case the user gave themselves this book with a /give command to test discovery.

            return string.Empty;
        }
    }

    public partial class CarpentrySkillBook : SkillBook<CarpentrySkill, CarpentrySkillScroll> {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            this.Skill.SkillTree.Parent.StaticSkill.SkillTree.TryDiscover(WorldTime.Seconds, player.User); //Trigger a discover for the root skill, in case the user gave themselves this book with a /give command to test discovery.
            this.Skill.SkillTree.TryDiscover(WorldTime.Seconds, player.User); //Trigger a discover, in case the user gave themselves this book with a /give command to test discovery.

            return string.Empty;
        }
    }

    public partial class CompositesSkillBook : SkillBook<CompositesSkill, CompositesSkillScroll> {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            this.Skill.SkillTree.Parent.StaticSkill.SkillTree.TryDiscover(WorldTime.Seconds, player.User); //Trigger a discover for the root skill, in case the user gave themselves this book with a /give command to test discovery.
            this.Skill.SkillTree.TryDiscover(WorldTime.Seconds, player.User); //Trigger a discover, in case the user gave themselves this book with a /give command to test discovery.

            return string.Empty;
        }
    }

    public partial class CookingSkillBook : SkillBook<CookingSkill, CookingSkillScroll> {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            this.Skill.SkillTree.Parent.StaticSkill.SkillTree.TryDiscover(WorldTime.Seconds, player.User); //Trigger a discover for the root skill, in case the user gave themselves this book with a /give command to test discovery.
            this.Skill.SkillTree.TryDiscover(WorldTime.Seconds, player.User); //Trigger a discover, in case the user gave themselves this book with a /give command to test discovery.

            return string.Empty;
        }
    }

    public partial class CuttingEdgeCookingSkillBook : SkillBook<CuttingEdgeCookingSkill, CuttingEdgeCookingSkillScroll> {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            this.Skill.SkillTree.Parent.StaticSkill.SkillTree.TryDiscover(WorldTime.Seconds, player.User); //Trigger a discover for the root skill, in case the user gave themselves this book with a /give command to test discovery.
            this.Skill.SkillTree.TryDiscover(WorldTime.Seconds, player.User); //Trigger a discover, in case the user gave themselves this book with a /give command to test discovery.

            return string.Empty;
        }
    }

    public partial class ElectronicsSkillBook : SkillBook<ElectronicsSkill, ElectronicsSkillScroll> {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            this.Skill.SkillTree.Parent.StaticSkill.SkillTree.TryDiscover(WorldTime.Seconds, player.User); //Trigger a discover for the root skill, in case the user gave themselves this book with a /give command to test discovery.
            this.Skill.SkillTree.TryDiscover(WorldTime.Seconds, player.User); //Trigger a discover, in case the user gave themselves this book with a /give command to test discovery.

            return string.Empty;
        }
    }

    public partial class FarmingSkillBook : SkillBook<FarmingSkill, FarmingSkillScroll> {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            this.Skill.SkillTree.Parent.StaticSkill.SkillTree.TryDiscover(WorldTime.Seconds, player.User); //Trigger a discover for the root skill, in case the user gave themselves this book with a /give command to test discovery.
            this.Skill.SkillTree.TryDiscover(WorldTime.Seconds, player.User); //Trigger a discover, in case the user gave themselves this book with a /give command to test discovery.

            return string.Empty;
        }
    }

    public partial class FertilizersSkillBook : SkillBook<FertilizersSkill, FertilizersSkillScroll> {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            this.Skill.SkillTree.Parent.StaticSkill.SkillTree.TryDiscover(WorldTime.Seconds, player.User); //Trigger a discover for the root skill, in case the user gave themselves this book with a /give command to test discovery.
            this.Skill.SkillTree.TryDiscover(WorldTime.Seconds, player.User); //Trigger a discover, in case the user gave themselves this book with a /give command to test discovery.

            return string.Empty;
        }
    }

    public partial class GlassworkingSkillBook : SkillBook<GlassworkingSkill, GlassworkingSkillScroll> {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            this.Skill.SkillTree.Parent.StaticSkill.SkillTree.TryDiscover(WorldTime.Seconds, player.User); //Trigger a discover for the root skill, in case the user gave themselves this book with a /give command to test discovery.
            this.Skill.SkillTree.TryDiscover(WorldTime.Seconds, player.User); //Trigger a discover, in case the user gave themselves this book with a /give command to test discovery.

            return string.Empty;
        }
    }

    public partial class IndustrySkillBook : SkillBook<IndustrySkill, IndustrySkillScroll> {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            this.Skill.SkillTree.Parent.StaticSkill.SkillTree.TryDiscover(WorldTime.Seconds, player.User); //Trigger a discover for the root skill, in case the user gave themselves this book with a /give command to test discovery.
            this.Skill.SkillTree.TryDiscover(WorldTime.Seconds, player.User); //Trigger a discover, in case the user gave themselves this book with a /give command to test discovery.

            return string.Empty;
        }
    }

    public partial class MasonrySkillBook : SkillBook<MasonrySkill, MasonrySkillScroll> {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            this.Skill.SkillTree.Parent.StaticSkill.SkillTree.TryDiscover(WorldTime.Seconds, player.User); //Trigger a discover for the root skill, in case the user gave themselves this book with a /give command to test discovery.
            this.Skill.SkillTree.TryDiscover(WorldTime.Seconds, player.User); //Trigger a discover, in case the user gave themselves this book with a /give command to test discovery.

            return string.Empty;
        }
    }

    public partial class MechanicsSkillBook : SkillBook<MechanicsSkill, MechanicsSkillScroll> {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            this.Skill.SkillTree.Parent.StaticSkill.SkillTree.TryDiscover(WorldTime.Seconds, player.User); //Trigger a discover for the root skill, in case the user gave themselves this book with a /give command to test discovery.
            this.Skill.SkillTree.TryDiscover(WorldTime.Seconds, player.User); //Trigger a discover, in case the user gave themselves this book with a /give command to test discovery.

            return string.Empty;
        }
    }

    public partial class MillingSkillBook : SkillBook<MillingSkill, MillingSkillScroll> {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            this.Skill.SkillTree.Parent.StaticSkill.SkillTree.TryDiscover(WorldTime.Seconds, player.User); //Trigger a discover for the root skill, in case the user gave themselves this book with a /give command to test discovery.
            this.Skill.SkillTree.TryDiscover(WorldTime.Seconds, player.User); //Trigger a discover, in case the user gave themselves this book with a /give command to test discovery.

            return string.Empty;
        }
    }

    public partial class OilDrillingSkillBook : SkillBook<OilDrillingSkill, OilDrillingSkillScroll> {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            this.Skill.SkillTree.Parent.StaticSkill.SkillTree.TryDiscover(WorldTime.Seconds, player.User); //Trigger a discover for the root skill, in case the user gave themselves this book with a /give command to test discovery.
            this.Skill.SkillTree.TryDiscover(WorldTime.Seconds, player.User); //Trigger a discover, in case the user gave themselves this book with a /give command to test discovery.

            return string.Empty;
        }
    }

    public partial class PaperMillingSkillBook : SkillBook<PaperMillingSkill, PaperMillingSkillScroll> {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            this.Skill.SkillTree.Parent.StaticSkill.SkillTree.TryDiscover(WorldTime.Seconds, player.User); //Trigger a discover for the root skill, in case the user gave themselves this book with a /give command to test discovery.
            this.Skill.SkillTree.TryDiscover(WorldTime.Seconds, player.User); //Trigger a discover, in case the user gave themselves this book with a /give command to test discovery.

            return string.Empty;
        }
    }

    public partial class PotterySkillBook : SkillBook<PotterySkill, PotterySkillScroll> {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            this.Skill.SkillTree.Parent.StaticSkill.SkillTree.TryDiscover(WorldTime.Seconds, player.User); //Trigger a discover for the root skill, in case the user gave themselves this book with a /give command to test discovery.
            this.Skill.SkillTree.TryDiscover(WorldTime.Seconds, player.User); //Trigger a discover, in case the user gave themselves this book with a /give command to test discovery.

            return string.Empty;
        }
    }

    public partial class ShipwrightSkillBook : SkillBook<ShipwrightSkill, ShipwrightSkillScroll> {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            this.Skill.SkillTree.Parent.StaticSkill.SkillTree.TryDiscover(WorldTime.Seconds, player.User); //Trigger a discover for the root skill, in case the user gave themselves this book with a /give command to test discovery.
            this.Skill.SkillTree.TryDiscover(WorldTime.Seconds, player.User); //Trigger a discover, in case the user gave themselves this book with a /give command to test discovery.

            return string.Empty;
        }
    }

    public partial class SmeltingSkillBook : SkillBook<SmeltingSkill, SmeltingSkillScroll> {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            this.Skill.SkillTree.Parent.StaticSkill.SkillTree.TryDiscover(WorldTime.Seconds, player.User); //Trigger a discover for the root skill, in case the user gave themselves this book with a /give command to test discovery.
            this.Skill.SkillTree.TryDiscover(WorldTime.Seconds, player.User); //Trigger a discover, in case the user gave themselves this book with a /give command to test discovery.

            return string.Empty;
        }
    }

    public partial class TailoringSkillBook : SkillBook<TailoringSkill, TailoringSkillScroll> {

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            this.Skill.SkillTree.Parent.StaticSkill.SkillTree.TryDiscover(WorldTime.Seconds, player.User); //Trigger a discover for the root skill, in case the user gave themselves this book with a /give command to test discovery.
            this.Skill.SkillTree.TryDiscover(WorldTime.Seconds, player.User); //Trigger a discover, in case the user gave themselves this book with a /give command to test discovery.

            return string.Empty;
        }
    }
}
