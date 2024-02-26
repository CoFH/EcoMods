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
    using Eco.Gameplay.Settlements.ClaimStakes;
    using Eco.Gameplay.Items.Recipes;

    [RequiresSkill(typeof(AgriculturalScienceSkill), 3)]
    public partial class ExtractCelluloseRecipe : RecipeFamily
    {
        public ExtractCelluloseRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "ExtractCellulose",  //noloc
                displayName: Localizer.DoStr("Extract Cellulose"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement("Crop", 8, typeof(AgriculturalScienceSkill), typeof(AgriculturalScienceLavishResourcesTalent)),
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<PlantFibersItem>(6),
                });
            this.Recipes = new List<Recipe> { recipe };
            
            // Defines the amount of labor required and the required skill to add labor
            this.LaborInCalories = CreateLaborInCaloriesValue(25, typeof(AgriculturalScienceSkill));

            // Defines our crafting time for the recipe
            this.CraftMinutes = CreateCraftTimeValue(beneficiary: typeof(ExtractCelluloseRecipe), start: 1, skillType: typeof(AgriculturalScienceSkill), typeof(AgriculturalScienceFocusedSpeedTalent), typeof(AgriculturalScienceParallelSpeedTalent));

            // Perform pre/post initialization for user mods and initialize our recipe instance with the display name "Extract Cellulose"
            this.ModsPreInitialize();
            this.Initialize(displayText: Localizer.DoStr("Extract Cellulose"), recipeType: typeof(ExtractCelluloseRecipe));
            this.ModsPostInitialize();

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddRecipe(tableType: typeof(LaboratoryObject), recipe: this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
