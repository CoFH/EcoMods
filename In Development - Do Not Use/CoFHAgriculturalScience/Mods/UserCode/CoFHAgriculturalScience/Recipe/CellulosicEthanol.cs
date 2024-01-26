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

    [RequiresSkill(typeof(AgriculturalScienceSkill), 5)]
    public partial class CellulosicEthanolRecipe : RecipeFamily
    {
        public CellulosicEthanolRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "AgSciCellulosicEthanol",  //noloc
                displayName: Localizer.DoStr("Cellulosic Ethanol"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement("NaturalFiber", 40, typeof(AgriculturalScienceSkill), typeof(AgriculturalScienceLavishResourcesTalent)),
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<EthanolItem>(1),
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 1.0f; // Defines how much experience is gained when crafted.
            
            // Defines the amount of labor required and the required skill to add labor
            this.LaborInCalories = CreateLaborInCaloriesValue(120, typeof(AgriculturalScienceSkill));

            // Defines our crafting time for the recipe
            this.CraftMinutes = CreateCraftTimeValue(beneficiary: typeof(CellulosicEthanolRecipe), start: 2, skillType: typeof(AgriculturalScienceSkill), typeof(AgriculturalScienceFocusedSpeedTalent), typeof(AgriculturalScienceParallelSpeedTalent));

            // Perform pre/post initialization for user mods and initialize our recipe instance with the display name "Cellulosic Ethanol"
            this.ModsPreInitialize();
            this.Initialize(displayText: Localizer.DoStr("Cellulosic Ethanol"), recipeType: typeof(CellulosicEthanolRecipe));
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
