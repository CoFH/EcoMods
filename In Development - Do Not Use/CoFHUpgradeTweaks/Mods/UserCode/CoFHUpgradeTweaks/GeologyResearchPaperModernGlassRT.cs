namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Core.Controller;
    using Eco.Gameplay.Items.Recipes;

    [RequiresSkill(typeof(GlassworkingSkill), 1)]
    public partial class GeologyResearchPaperModernGlassRTRecipe : RecipeFamily
    {
        public GeologyResearchPaperModernGlassRTRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "GeologyResearchPaperModernGlass",  //noloc
                displayName: Localizer.DoStr("Geology Research Paper Modern Glass"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(GlassItem), 30, typeof(GlassworkingSkill), typeof(GlassworkingLavishResourcesTalent)),
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<GeologyResearchPaperModernItem>(1),
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 6; // Defines how much experience is gained when crafted.
            
            // Defines the amount of labor required and the required skill to add labor
            this.LaborInCalories = CreateLaborInCaloriesValue(600, typeof(GlassworkingSkill));

            // Defines our crafting time for the recipe
            this.CraftMinutes = CreateCraftTimeValue(beneficiary: typeof(GeologyResearchPaperModernGlassRTRecipe), start: 1, skillType: typeof(GlassworkingSkill), typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent));

            // Perform pre/post initialization for user mods and initialize our recipe instance with the display name "Geology Research Paper Modern Glass"
            this.ModsPreInitialize();
            this.Initialize(displayText: Localizer.DoStr("Geology Research Paper Modern Glass"), recipeType: typeof(GeologyResearchPaperModernGlassRTRecipe));
            this.ModsPostInitialize();

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddRecipe(tableType: typeof(ResearchTableObject), recipe: this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        void ModsPreInitialize()
        {
            var ingredients = this.Recipes[0].Ingredients;
            ingredients.Add(new IngredientElement(typeof(PaperItem), 20, true));
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
