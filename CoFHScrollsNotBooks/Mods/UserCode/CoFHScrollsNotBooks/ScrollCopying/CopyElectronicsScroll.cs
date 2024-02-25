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

    [RequiresSkill(typeof(PaperMillingSkill), 6)]
    public partial class SkillScrollCopyElectronicsRecipe : RecipeFamily
    {
        public SkillScrollCopyElectronicsRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "SkillScrollCopyElectronics",  //noloc
                displayName: Localizer.DoStr("Skill Scroll Copy (Electronics)"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(ElectronicsSkillScroll), 1, true),
                    new IngredientElement(typeof(PaperItem), CopySkillScrollSettings.PaperAmount, typeof(PaperMillingSkill), typeof(PaperMillingLavishResourcesTalent)),
                    new IngredientElement(typeof(OilPaintItem), CopySkillScrollSettings.PaintAmount, typeof(PaperMillingSkill), typeof(PaperMillingLavishResourcesTalent))
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<ElectronicsSkillScroll>(2)
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 5; // Defines how much experience is gained when crafted.
            
            // Defines the amount of labor required and the required skill to add labor
            this.LaborInCalories = CreateLaborInCaloriesValue(120, typeof(PaperMillingSkill));

            // Defines our crafting time for the recipe
            this.CraftMinutes = CreateCraftTimeValue(beneficiary: typeof(SkillScrollCopyElectronicsRecipe), start: 2f, skillType: typeof(PaperMillingSkill), typeof(PaperMillingFocusedSpeedTalent), typeof(PaperMillingParallelSpeedTalent));

            // Perform pre/post initialization for user mods and initialize our recipe instance with the display name "Skill Scroll Copy (Electronics)"
            this.ModsPreInitialize();
            this.Initialize(displayText: Localizer.DoStr("Skill Scroll Copy (Electronics)"), recipeType: typeof(SkillScrollCopyElectronicsRecipe));
            this.ModsPostInitialize();

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddRecipe(tableType: typeof(SmallPaperMachineObject), recipe: this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
