namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Skills;
    using Eco.Core.Items;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.World.Blocks;
    using Eco.Gameplay.Items.Recipes;

    [RequiresSkill(typeof(OilDrillingSkill), 3)]
    [Ecopedia("Blocks", "Liquids", subPageName: "Gasoline Item")]
    public partial class BlendedGasolineRecipe : RecipeFamily
    {
        public BlendedGasolineRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "AgSciBlendedGasoline",  //noloc
                displayName: Localizer.DoStr("Blended Gasoline"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(PetroleumItem), 3, typeof(OilDrillingSkill), typeof(OilDrillingLavishResourcesTalent)),
                    new IngredientElement(typeof(EthanolItem), 2, typeof(OilDrillingSkill), typeof(OilDrillingLavishResourcesTalent)),
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<GasolineItem>()
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 0.5f; // Defines how much experience is gained when crafted.

            // Defines the amount of labor required and the required skill to add labor
            this.LaborInCalories = CreateLaborInCaloriesValue(120, typeof(OilDrillingSkill));

            // Defines our crafting time for the recipe
            this.CraftMinutes = CreateCraftTimeValue(beneficiary: typeof(BlendedGasolineRecipe), start: 0.8f, skillType: typeof(OilDrillingSkill), typeof(OilDrillingFocusedSpeedTalent), typeof(OilDrillingParallelSpeedTalent));

            // Perform pre/post initialization for user mods and initialize our recipe instance with the display name "Gasoline"
            this.ModsPreInitialize();
            this.Initialize(displayText: Localizer.DoStr("Blended Gasoline"), recipeType: typeof(BlendedGasolineRecipe));
            this.ModsPostInitialize();

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddRecipe(tableType: typeof(OilRefineryObject), recipe: this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}