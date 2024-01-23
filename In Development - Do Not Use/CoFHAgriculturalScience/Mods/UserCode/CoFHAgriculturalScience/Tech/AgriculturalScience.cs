namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using Eco.Core.Items;
    using Eco.Core.Utils;
    using Eco.Core.Utils.AtomicAction;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Property;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Services;
    using Eco.Shared.Utils;
    using Eco.Gameplay.Systems.NewTooltip;
    using Eco.Core.Controller;
    using Eco.Gameplay.Items.Recipes;

    [Serialized]
    [LocDisplayName("Agricultural Science")]
    [LocDescription("Biomass can be used for more than just food. Converting it into other useful forms is a huge step for any society. Levels up by crafting related recipes.")]
    [Ecopedia("Professions", "Farmer", createAsSubPage: true)]
    [RequiresSkill(typeof(FarmerSkill), 0), Tag("Farmer Specialty"), Tier(4)]
    [Tag("Specialty")]
    [Tag("Teachable")]
    public partial class AgriculturalScienceSkill : Skill
    {
        public override void OnLevelUp(User user)
        {
            user.Skillset.AddExperience(typeof(SelfImprovementSkill), 20, Localizer.DoStr("for leveling up another specialization."));
        }

        public static MultiplicativeStrategy MultiplicativeStrategy =
            new MultiplicativeStrategy(new float[] { 
                1,
                1 - 0.2f,
                1 - 0.25f,
                1 - 0.3f,
                1 - 0.35f,
                1 - 0.4f,
                1 - 0.45f,
                1 - 0.5f,
            });
        public override MultiplicativeStrategy MultiStrategy => MultiplicativeStrategy;

        public static AdditiveStrategy AdditiveStrategy =
            new AdditiveStrategy(new float[] { 
                0,
                0.5f,
                0.55f,
                0.6f,
                0.65f,
                0.7f,
                0.75f,
                0.8f,
            });
        public override AdditiveStrategy AddStrategy => AdditiveStrategy;
        public override int MaxLevel { get { return 7; } }
        public override int Tier { get { return 2; } }
    }

    [Serialized]
    [Weight(1000)]
    [LocDisplayName("Agricultural Science Skill Book")]
    [Ecopedia("Items", "Skill Books", createAsSubPage: true)]
    public partial class AgriculturalScienceSkillBook : SkillBook<AgriculturalScienceSkill, AgriculturalScienceSkillScroll> {}

    [Serialized]
    [Weight(100)]
    [LocDisplayName("Agricultural Science Skill Scroll")]
    public partial class AgriculturalScienceSkillScroll : SkillScroll<AgriculturalScienceSkill, AgriculturalScienceSkillBook> {}

    [RequiresSkill(typeof(FarmerSkill), 1)]
    [Ecopedia("Professions", "Farmer", subPageName: "Agricultural Science Skill Book Item")]
    public partial class AgriculturalScienceSkillBookRecipe : RecipeFamily
    {
        public AgriculturalScienceSkillBookRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "AgriculturalScience",  //noloc
                displayName: Localizer.DoStr("Agricultural Science Skill Book"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(AgricultureResearchPaperAdvancedItem), 10, typeof(FarmerSkill)),
                    new IngredientElement(typeof(AgricultureResearchPaperModernItem), 10, typeof(FarmerSkill)),
                    new IngredientElement(typeof(GeologyResearchPaperModernItem), 10, typeof(FarmerSkill)),
                    new IngredientElement(typeof(DendrologyResearchPaperModernItem), 10, typeof(FarmerSkill)),
                    new IngredientElement("Basic Research", 30, typeof(FarmerSkill)), //noloc
                    new IngredientElement("Advanced Research", 20, typeof(FarmerSkill)), //noloc
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<AgriculturalScienceSkillBook>()
                });
            this.Recipes = new List<Recipe> { recipe };

            // Defines the amount of labor required and the required skill to add labor
            this.LaborInCalories = CreateLaborInCaloriesValue(6000, typeof(FarmerSkill));

            // Defines our crafting time for the recipe
            this.CraftMinutes = CreateCraftTimeValue(beneficiary: typeof(AgriculturalScienceSkillBookRecipe), start: 30, skillType: typeof(FarmerSkill));

            // Perform pre/post initialization for user mods and initialize our recipe instance with the display name "Agricultural Science Skill Book"
            this.ModsPreInitialize();
            this.Initialize(displayText: Localizer.DoStr("Agricultural Science Skill Book"), recipeType: typeof(AgriculturalScienceSkillBookRecipe));
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