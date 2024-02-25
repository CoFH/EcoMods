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

    [RequiresSkill(typeof(GlassworkingSkill), 3)]
    [Ecopedia("Items", "Products", subPageName: "Fiberglass Item")]
    public partial class SpunFiberglassRecipe : RecipeFamily
    {
        public SpunFiberglassRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "SpunFiberglass",  //noloc
                displayName: Localizer.DoStr("Spun Fiberglass"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(PlasticItem), 8, typeof(GlassworkingSkill), typeof(GlassworkingLavishResourcesTalent)),
                    new IngredientElement(typeof(GlassItem), 3, typeof(GlassworkingSkill), typeof(GlassworkingLavishResourcesTalent)),
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<FiberglassItem>(2)
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 1; // Defines how much experience is gained when crafted.
            
            // Defines the amount of labor required and the required skill to add labor
            this.LaborInCalories = CreateLaborInCaloriesValue(60, typeof(GlassworkingSkill));

            // Defines our crafting time for the recipe
            this.CraftMinutes = CreateCraftTimeValue(beneficiary: typeof(SpunFiberglassRecipe), start: 1.5f, skillType: typeof(GlassworkingSkill), typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent));

            // Perform pre/post initialization for user mods and initialize our recipe instance with the display name "Spun Fiberglass"
            this.ModsPreInitialize();
            this.Initialize(displayText: Localizer.DoStr("Spun Fiberglass"), recipeType: typeof(SpunFiberglassRecipe));
            this.ModsPostInitialize();

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            // CHANGED BY CoFHRecipeTweaks: CraftingComponent.AddRecipe(tableType: typeof(ElectronicsAssemblyObject), recipe: this);
            CraftingComponent.AddRecipe(tableType: typeof(SpinMelterObject), recipe: this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}