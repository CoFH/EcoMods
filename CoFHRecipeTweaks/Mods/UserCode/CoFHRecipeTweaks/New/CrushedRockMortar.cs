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
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Eco.Shared.Localization;
    using Eco.Gameplay.Items.Recipes;

    [RequiresSkill(typeof(MasonrySkill), 5)]
    public partial class CrushedRockMortarRecipe : RecipeFamily
    {
        public CrushedRockMortarRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "CrushedRockMortar",  //noloc
                displayName: Localizer.DoStr("Crushed Rock Mortar"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement("CrushedRock", 1, true), //noloc
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<MortarItem>(4),
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 0.5f; // Defines how much experience is gained when crafted.
            
            // Defines the amount of labor required and the required skill to add labor
            this.LaborInCalories = CreateLaborInCaloriesValue(60, typeof(MasonrySkill));

            // Defines our crafting time for the recipe
            this.CraftMinutes = CreateCraftTimeValue(beneficiary: typeof(CrushedRockMortarRecipe), start: 0.5f, skillType: typeof(MasonrySkill), typeof(MasonryFocusedSpeedTalent), typeof(MasonryParallelSpeedTalent));

            // Perform pre/post initialization for user mods and initialize our recipe instance with the display name "Crushed Rock Mortar"
            this.ModsPreInitialize();
            this.Initialize(displayText: Localizer.DoStr("Crushed Rock Mortar"), recipeType: typeof(CrushedRockMortarRecipe));
            this.ModsPostInitialize();

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddRecipe(tableType: typeof(CementKilnObject), recipe: this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}