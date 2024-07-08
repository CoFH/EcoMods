namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Settlements;
    using Eco.Gameplay.Systems;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Core.Items;
    using Eco.World;
    using Eco.World.Blocks;
    using Eco.Gameplay.Pipes;
    using Eco.Core.Controller;
    using Eco.Gameplay.Items.Recipes;

    public partial class AgricultureResearchPaperModernRecipe : RecipeFamily
    {
        partial void ModsPreInitialize()
        {
            var ingredients = this.Recipes[0].Ingredients;
            ingredients.Add(new IngredientElement(typeof(PaperItem), 20, typeof(FarmingSkill), typeof(FarmingLavishResourcesTalent)));
        }
    }

    public partial class CulinaryResearchPaperModernRecipe : RecipeFamily
    {
        partial void ModsPreInitialize()
        {
            var ingredients = this.Recipes[0].Ingredients;
            ingredients.Add(new IngredientElement(typeof(PaperItem), 20, typeof(AdvancedCookingSkill), typeof(AdvancedCookingLavishResourcesTalent)));
        }
    }

    public partial class DendrologyResearchPaperModernRecipe : RecipeFamily
    {
        partial void ModsPreInitialize()
        {
            var ingredients = this.Recipes[0].Ingredients;
            ingredients.Add(new IngredientElement(typeof(PaperItem), 20, typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)));
        }
    }

    public partial class EngineeringResearchPaperModernRecipe : RecipeFamily
    {
        partial void ModsPreInitialize()
        {
            var ingredients = this.Recipes[0].Ingredients;
            ingredients.Add(new IngredientElement(typeof(PaperItem), 20, typeof(MechanicsSkill), typeof(MechanicsLavishResourcesTalent)));
        }
    }

    public partial class GeologyResearchPaperModernRecipe : RecipeFamily
    {
        partial void ModsPreInitialize()
        {
            var ingredients = this.Recipes[0].Ingredients;
            ingredients.Add(new IngredientElement(typeof(PaperItem), 20, typeof(PotterySkill), typeof(PotteryLavishResourcesTalent)));
        }
    }

    public partial class GeologyResearchPaperModernGlassRecipe : RecipeFamily
    {
        partial void ModsPreInitialize()
        {
            var ingredients = this.Recipes[0].Ingredients;
            ingredients.Add(new IngredientElement(typeof(PaperItem), 20, typeof(GlassworkingSkill), typeof(GlassworkingLavishResourcesTalent)));
        }
    }

    public partial class MetallurgyResearchPaperModernRecipe : RecipeFamily
    {
        partial void ModsPreInitialize()
        {
            var ingredients = this.Recipes[0].Ingredients;
            ingredients.Add(new IngredientElement(typeof(PaperItem), 20, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingLavishResourcesTalent)));
        }
    }
}