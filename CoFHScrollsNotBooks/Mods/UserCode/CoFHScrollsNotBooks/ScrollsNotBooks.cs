using Eco.Core.Items;
using Eco.Gameplay.Items;
using Eco.Gameplay.Items.Recipes;
using Eco.Shared.Localization;
using Eco.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Eco.Mods.TechTree
{
    public static class SkillScrollSettings
    {
        // How many scrolls should be created per craft
        public const int OutputAmount = 3;
    }

    public partial class AdvancedBakingSkillBookRecipe
    {
        partial void ModsPreInitialize()
        {
            Recipes[0].Products.Clear();
            Recipes[0].Products.Add(new CraftingElement<AdvancedBakingSkillScroll>(SkillScrollSettings.OutputAmount));
        }

        partial void ModsPostInitialize()
        {
            RecipeName = $"{Recipes[0].Name.AddSpacesBetweenCapitals()} Skill Scroll";
        }
    }

    public partial class AdvancedCookingSkillBookRecipe
    {
        partial void ModsPreInitialize()
        {

            Recipes[0].Products.Clear();
            Recipes[0].Products.Add(new CraftingElement<AdvancedCookingSkillScroll>(SkillScrollSettings.OutputAmount));
        }

        partial void ModsPostInitialize()
        {
            RecipeName = $"{Recipes[0].Name.AddSpacesBetweenCapitals()} Skill Scroll";
        }
    }

    public partial class AdvancedMasonrySkillBookRecipe
    {
        partial void ModsPreInitialize()
        {
            Recipes[0].Products.Clear();
            Recipes[0].Products.Add(new CraftingElement<AdvancedMasonrySkillScroll>(SkillScrollSettings.OutputAmount));
        }

        partial void ModsPostInitialize()
        {
            RecipeName = $"{Recipes[0].Name.AddSpacesBetweenCapitals()} Skill Scroll";
        }
    }

    public partial class AdvancedSmeltingSkillBookRecipe
    {
        partial void ModsPreInitialize()
        {
            Recipes[0].Products.Clear();
            Recipes[0].Products.Add(new CraftingElement<AdvancedSmeltingSkillScroll>(SkillScrollSettings.OutputAmount));
        }

        partial void ModsPostInitialize()
        {
            RecipeName = $"{Recipes[0].Name.AddSpacesBetweenCapitals()} Skill Scroll";
        }
    }

    public partial class BakingSkillBookRecipe
    {
        partial void ModsPreInitialize()
        {
            Recipes[0].Products.Clear();
            Recipes[0].Products.Add(new CraftingElement<BakingSkillScroll>(SkillScrollSettings.OutputAmount));
        }

        partial void ModsPostInitialize()
        {
            RecipeName = $"{Recipes[0].Name.AddSpacesBetweenCapitals()} Skill Scroll";
        }
    }

    public partial class BasicEngineeringSkillBookRecipe
    {
        partial void ModsPreInitialize()
        {
            Recipes[0].Products.Clear();
            Recipes[0].Products.Add(new CraftingElement<BasicEngineeringSkillScroll>(SkillScrollSettings.OutputAmount));
        }

        partial void ModsPostInitialize()
        {
            RecipeName = $"{Recipes[0].Name.AddSpacesBetweenCapitals()} Skill Scroll";
        }
    }

    public partial class ButcherySkillBookRecipe
    {
        partial void ModsPreInitialize()
        {
            Recipes[0].Products.Clear();
            Recipes[0].Products.Add(new CraftingElement<ButcherySkillScroll>(SkillScrollSettings.OutputAmount));
        }

        partial void ModsPostInitialize()
        {
            RecipeName = $"{Recipes[0].Name.AddSpacesBetweenCapitals()} Skill Scroll";
        }
    }

    public partial class CarpentrySkillBookRecipe
    {
        partial void ModsPreInitialize()
        {
            Recipes[0].Products.Clear();
            Recipes[0].Products.Add(new CraftingElement<CarpentrySkillScroll>(SkillScrollSettings.OutputAmount));
        }

        partial void ModsPostInitialize()
        {
            RecipeName = $"{Recipes[0].Name.AddSpacesBetweenCapitals()} Skill Scroll";
        }
    }

    public partial class CompositesSkillBookRecipe
    {
        partial void ModsPreInitialize()
        {
            Recipes[0].Products.Clear();
            Recipes[0].Products.Add(new CraftingElement<CompositesSkillScroll>(SkillScrollSettings.OutputAmount));
        }

        partial void ModsPostInitialize()
        {
            RecipeName = $"{Recipes[0].Name.AddSpacesBetweenCapitals()} Skill Scroll";
        }
    }

    public partial class CookingSkillBookRecipe
    {
        partial void ModsPreInitialize()
        {
            Recipes[0].Products.Clear();
            Recipes[0].Products.Add(new CraftingElement<CookingSkillScroll>(SkillScrollSettings.OutputAmount));
        }

        partial void ModsPostInitialize()
        {
            RecipeName = $"{Recipes[0].Name.AddSpacesBetweenCapitals()} Skill Scroll";
        }
    }

    public partial class CuttingEdgeCookingSkillBookRecipe
    {
        partial void ModsPreInitialize()
        {
            Recipes[0].Products.Clear();
            Recipes[0].Products.Add(new CraftingElement<CuttingEdgeCookingSkillScroll>(SkillScrollSettings.OutputAmount));
        }

        partial void ModsPostInitialize()
        {
            RecipeName = $"{Recipes[0].Name.AddSpacesBetweenCapitals()} Skill Scroll";
        }
    }

    public partial class ElectronicsSkillBookRecipe
    {
        partial void ModsPreInitialize()
        {
            Recipes[0].Products.Clear();
            Recipes[0].Products.Add(new CraftingElement<ElectronicsSkillScroll>(SkillScrollSettings.OutputAmount));
        }

        partial void ModsPostInitialize()
        {
            RecipeName = $"{Recipes[0].Name.AddSpacesBetweenCapitals()} Skill Scroll";
        }
    }

    public partial class FarmingSkillBookRecipe
    {
        partial void ModsPreInitialize()
        {
            Recipes[0].Products.Clear();
            Recipes[0].Products.Add(new CraftingElement<FarmingSkillScroll>(SkillScrollSettings.OutputAmount));
        }

        partial void ModsPostInitialize()
        {
            RecipeName = $"{Recipes[0].Name.AddSpacesBetweenCapitals()} Skill Scroll";
        }
    }

    // public partial class FertilizersSkillBookRecipe
    // {
    //     partial void ModsPreInitialize()
    //     {
    //         Recipes[0].Products.Clear();
    //         Recipes[0].Products.Add(new CraftingElement<FertilizersSkillScroll>(SkillScrollSettings.OutputAmount));
    //     }

    //     partial void ModsPostInitialize()
    //     {
    //         RecipeName = $"{Recipes[0].Name.AddSpacesBetweenCapitals()} Skill Scroll";
    //     }
    // }

    public partial class GlassworkingSkillBookRecipe
    {
        partial void ModsPreInitialize()
        {
            Recipes[0].Products.Clear();
            Recipes[0].Products.Add(new CraftingElement<GlassworkingSkillScroll>(SkillScrollSettings.OutputAmount));
        }

        partial void ModsPostInitialize()
        {
            RecipeName = $"{Recipes[0].Name.AddSpacesBetweenCapitals()} Skill Scroll";
        }
    }

    public partial class IndustrySkillBookRecipe
    {
        partial void ModsPreInitialize()
        {
            Recipes[0].Products.Clear();
            Recipes[0].Products.Add(new CraftingElement<IndustrySkillScroll>(SkillScrollSettings.OutputAmount));
        }

        partial void ModsPostInitialize()
        {
            RecipeName = $"{Recipes[0].Name.AddSpacesBetweenCapitals()} Skill Scroll";
        }
    }

    public partial class MasonrySkillBookRecipe
    {
        partial void ModsPreInitialize()
        {
            Recipes[0].Products.Clear();
            Recipes[0].Products.Add(new CraftingElement<MasonrySkillScroll>(SkillScrollSettings.OutputAmount));
        }

        partial void ModsPostInitialize()
        {
            RecipeName = $"{Recipes[0].Name.AddSpacesBetweenCapitals()} Skill Scroll";
        }
    }

    public partial class MechanicsSkillBookRecipe
    {
        partial void ModsPreInitialize()
        {
            Recipes[0].Products.Clear();
            Recipes[0].Products.Add(new CraftingElement<MechanicsSkillScroll>(SkillScrollSettings.OutputAmount));
        }

        partial void ModsPostInitialize()
        {
            RecipeName = $"{Recipes[0].Name.AddSpacesBetweenCapitals()} Skill Scroll";
        }
    }

    public partial class MillingSkillBookRecipe
    {
        partial void ModsPreInitialize()
        {
            Recipes[0].Products.Clear();
            Recipes[0].Products.Add(new CraftingElement<MillingSkillScroll>(SkillScrollSettings.OutputAmount));
        }

        partial void ModsPostInitialize()
        {
            RecipeName = $"{Recipes[0].Name.AddSpacesBetweenCapitals()} Skill Scroll";
        }
    }

    public partial class OilDrillingSkillBookRecipe
    {
        partial void ModsPreInitialize()
        {
            Recipes[0].Products.Clear();
            Recipes[0].Products.Add(new CraftingElement<OilDrillingSkillScroll>(SkillScrollSettings.OutputAmount));
        }

        partial void ModsPostInitialize()
        {
            RecipeName = $"{Recipes[0].Name.AddSpacesBetweenCapitals()} Skill Scroll";
        }
    }

    public partial class PaperMillingSkillBookRecipe
    {
        partial void ModsPreInitialize()
        {
            Recipes[0].Products.Clear();
            Recipes[0].Products.Add(new CraftingElement<PaperMillingSkillScroll>(SkillScrollSettings.OutputAmount));
        }

        partial void ModsPostInitialize()
        {
            RecipeName = $"{Recipes[0].Name.AddSpacesBetweenCapitals()} Skill Scroll";
        }
    }

    public partial class PotterySkillBookRecipe
    {
        partial void ModsPreInitialize()
        {
            Recipes[0].Products.Clear();
            Recipes[0].Products.Add(new CraftingElement<PotterySkillScroll>(SkillScrollSettings.OutputAmount));
        }

        partial void ModsPostInitialize()
        {
            RecipeName = $"{Recipes[0].Name.AddSpacesBetweenCapitals()} Skill Scroll";
        }
    }

    public partial class SmeltingSkillBookRecipe
    {
        partial void ModsPreInitialize()
        {
            Recipes[0].Products.Clear();
            Recipes[0].Products.Add(new CraftingElement<SmeltingSkillScroll>(SkillScrollSettings.OutputAmount));
        }

        partial void ModsPostInitialize()
        {
            RecipeName = $"{Recipes[0].Name.AddSpacesBetweenCapitals()} Skill Scroll";
        }
    }

    public partial class TailoringSkillBookRecipe
    {
        partial void ModsPreInitialize()
        {
            Recipes[0].Products.Clear();
            Recipes[0].Products.Add(new CraftingElement<TailoringSkillScroll>(SkillScrollSettings.OutputAmount));
        }

        partial void ModsPostInitialize()
        {
            RecipeName = $"{Recipes[0].Name.AddSpacesBetweenCapitals()} Skill Scroll";
        }
    }

    public partial class ShipwrightSkillBookRecipe
    {
        partial void ModsPreInitialize()
        {
            Recipes[0].Products.Clear();
            Recipes[0].Products.Add(new CraftingElement<ShipwrightSkillScroll>(SkillScrollSettings.OutputAmount));
        }

        partial void ModsPostInitialize()
        {
            RecipeName = $"{Recipes[0].Name.AddSpacesBetweenCapitals()} Skill Scroll";
        }
    }

    #region MODDED

    public partial class AgriculturalScienceSkillBookRecipe
    {
        partial void ModsPreInitialize()
        {
            Recipes[0].Products.Clear();
            Recipes[0].Products.Add(new CraftingElement<AgriculturalScienceSkillScroll>(SkillScrollSettings.OutputAmount));
        }

        partial void ModsPostInitialize()
        {
            RecipeName = $"{Recipes[0].Name.AddSpacesBetweenCapitals()} Skill Scroll";
        }
    }

    #endregion
}
