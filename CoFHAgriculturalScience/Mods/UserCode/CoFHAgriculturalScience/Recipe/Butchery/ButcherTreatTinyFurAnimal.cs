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

    [RequiresSkill(typeof(ButcherySkill), 3)]
    public partial class ButcherTreatTinyFurAnimalRecipe : RecipeFamily
    {
        public ButcherTreatTinyFurAnimalRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "ButcherTreatTinyFurAnimal",  //noloc
                displayName: Localizer.DoStr("Butcher/Treat Tiny Fur Animal"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement("TinyFurCarcass", 1, typeof(ButcherySkill), typeof(ButcheryLavishResourcesTalent)), //noloc
                    new IngredientElement(typeof(CitricAcidItem), 1, typeof(ButcherySkill), typeof(ButcheryLavishResourcesTalent)),
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<RawMeatItem>(2),
                    new CraftingElement<FurPeltItem>(2),
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 2; // Defines how much experience is gained when crafted.
            
            // Defines the amount of labor required and the required skill to add labor
            this.LaborInCalories = CreateLaborInCaloriesValue(35, typeof(ButcherySkill));

            // Defines our crafting time for the recipe
            this.CraftMinutes = CreateCraftTimeValue(beneficiary: typeof(ButcherTreatTinyFurAnimalRecipe), start: 0.5f, skillType: typeof(ButcherySkill), typeof(ButcheryFocusedSpeedTalent), typeof(ButcheryParallelSpeedTalent));

            // Perform pre/post initialization for user mods and initialize our recipe instance with the display name "Butcher/Treat Tiny Fur Animal"
            this.ModsPreInitialize();
            this.Initialize(displayText: Localizer.DoStr("Butcher/Treat Tiny Fur Animal"), recipeType: typeof(ButcherTreatTinyFurAnimalRecipe));
            this.ModsPostInitialize();

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddRecipe(tableType: typeof(ButcheryTableObject), recipe: this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
