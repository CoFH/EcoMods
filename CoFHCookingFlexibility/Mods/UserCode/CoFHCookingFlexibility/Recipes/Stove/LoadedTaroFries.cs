namespace Eco.Mods.TechTree
{
    using System.Collections.Generic;
    using Eco.Core.Items;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Skills;
    using Eco.Shared.Localization;
    using Eco.Gameplay.Items.Recipes;

    [RequiresSkill(typeof(CookingSkill), 5)]
    [Ecopedia("Food", "Cooking", subPageName: "Loaded Taro Fries Item")]
    public partial class LoadedTaroFriesStoveRecipe : RecipeFamily
    {
        public LoadedTaroFriesStoveRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "LoadedTaroFriesStove",  //noloc
                displayName: Localizer.DoStr("Loaded Taro Fries"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(TaroFriesItem), 1, typeof(CookingSkill), typeof(CookingLavishResourcesTalent)),
                    new IngredientElement(typeof(SunCheeseItem), 2, typeof(CookingSkill), typeof(CookingLavishResourcesTalent)),
                    new IngredientElement(typeof(PreparedMeatItem), 2, typeof(CookingSkill), typeof(CookingLavishResourcesTalent)),
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<LoadedTaroFriesItem>(1)
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 1; // Defines how much experience is gained when crafted.
            
            // Defines the amount of labor required and the required skill to add labor
            this.LaborInCalories = CreateLaborInCaloriesValue(25, typeof(CookingSkill));

            // Defines our crafting time for the recipe
            this.CraftMinutes = CreateCraftTimeValue(beneficiary: typeof(LoadedTaroFriesStoveRecipe), start: 2, skillType: typeof(CookingSkill), typeof(CookingFocusedSpeedTalent), typeof(CookingParallelSpeedTalent));

            // Perform pre/post initialization for user mods and initialize our recipe instance with the display name "Loaded Taro Fries"
            this.ModsPreInitialize();
            this.Initialize(displayText: Localizer.DoStr("Loaded Taro Fries"), recipeType: typeof(LoadedTaroFriesStoveRecipe));
            this.ModsPostInitialize();

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddRecipe(tableType: typeof(StoveObject), recipe: this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
