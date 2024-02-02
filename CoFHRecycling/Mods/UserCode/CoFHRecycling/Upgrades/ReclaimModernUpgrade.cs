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

    public partial class ReclaimModernUpgradeRecipe : RecipeFamily
    {
        public ReclaimModernUpgradeRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "ReclaimAdvancedMasonryUpgrade",  //noloc
                displayName: Localizer.DoStr("Reclaim Modern Upgrade (Advanced Masonry)"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(AdvancedMasonryUpgradeItem), 1, true)
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<ModernUpgradeLvl4Item>(1)
                });
            this.Recipes = new List<Recipe> { recipe };
            
            // Defines the amount of labor required and the required skill to add labor
            this.LaborInCalories = CreateLaborInCaloriesValue(3000);

            // Defines our crafting time for the recipe
            this.CraftMinutes = CreateCraftTimeValue(7.5f);

            // Perform pre/post initialization for user mods and initialize our recipe instance with the display name "Reclaim Modern Upgrade"
            this.ModsPreInitialize();
            this.Initialize(displayText: Localizer.DoStr("Reclaim Modern Upgrade"), recipeType: typeof(ReclaimModernUpgradeRecipe));
            this.ModsPostInitialize();

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddRecipe(tableType: typeof(LaboratoryObject), recipe: this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class ReclaimCompositesUpgrade : Recipe
    {
        public ReclaimCompositesUpgrade()
        {
            this.Init(
                name: "ReclaimCompositesUpgrade",  //noloc
                displayName: Localizer.DoStr("Reclaim Modern Upgrade (Composites)"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(CompositesUpgradeItem), 1, true)
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<ModernUpgradeLvl4Item>(1)
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(LaboratoryObject), typeof(ReclaimModernUpgradeRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class ReclaimCuttingEdgeCookingUpgrade : Recipe
    {
        public ReclaimCuttingEdgeCookingUpgrade()
        {
            this.Init(
                name: "ReclaimCuttingEdgeCookingUpgrade",  //noloc
                displayName: Localizer.DoStr("Reclaim Modern Upgrade (Cutting Edge Cooking)"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(CuttingEdgeCookingUpgradeItem), 1, true)
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<ModernUpgradeLvl4Item>(1)
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(LaboratoryObject), typeof(ReclaimModernUpgradeRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class ReclaimElectronicsUpgrade : Recipe
    {
        public ReclaimElectronicsUpgrade()
        {
            this.Init(
                name: "ReclaimElectronicsUpgrade",  //noloc
                displayName: Localizer.DoStr("Reclaim Modern Upgrade (Electronics)"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(ElectronicsUpgradeItem), 1, true)
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<ModernUpgradeLvl4Item>(1)
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(LaboratoryObject), typeof(ReclaimModernUpgradeRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class ReclaimGlassworkingModernUpgrade : Recipe
    {
        public ReclaimGlassworkingModernUpgrade()
        {
            this.Init(
                name: "ReclaimGlassworkingModernUpgrade",  //noloc
                displayName: Localizer.DoStr("Reclaim Modern Upgrade (Glassworking)"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(GlassworkingModernUpgradeItem), 1, true)
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<ModernUpgradeLvl4Item>(1)
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(LaboratoryObject), typeof(ReclaimModernUpgradeRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class ReclaimIndustryUpgrade : Recipe
    {
        public ReclaimIndustryUpgrade()
        {
            this.Init(
                name: "ReclaimIndustryUpgrade",  //noloc
                displayName: Localizer.DoStr("Reclaim Modern Upgrade (Industry)"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(IndustryUpgradeItem), 1, true)
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<ModernUpgradeLvl4Item>(1)
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(LaboratoryObject), typeof(ReclaimModernUpgradeRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class ReclaimMechanicsModernUpgrade : Recipe
    {
        public ReclaimMechanicsModernUpgrade()
        {
            this.Init(
                name: "ReclaimMechanicsModernUpgrade",  //noloc
                displayName: Localizer.DoStr("Reclaim Modern Upgrade (Mechanics)"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(MechanicsModernUpgradeItem), 1, true)
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<ModernUpgradeLvl4Item>(1)
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(LaboratoryObject), typeof(ReclaimModernUpgradeRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class ReclaimMiningModernUpgrade : Recipe
    {
        public ReclaimMiningModernUpgrade()
        {
            this.Init(
                name: "ReclaimMiningModernUpgrade",  //noloc
                displayName: Localizer.DoStr("Reclaim Modern Upgrade (Mining)"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(MiningModernUpgradeItem), 1, true)
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<ModernUpgradeLvl4Item>(1)
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(LaboratoryObject), typeof(ReclaimModernUpgradeRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class ReclaimOilDrillingUpgrade : Recipe
    {
        public ReclaimOilDrillingUpgrade()
        {
            this.Init(
                name: "ReclaimOilDrillingUpgrade",  //noloc
                displayName: Localizer.DoStr("Reclaim Modern Upgrade (Oil Drilling)"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(OilDrillingUpgradeItem), 1, true)
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<ModernUpgradeLvl4Item>(1)
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(LaboratoryObject), typeof(ReclaimModernUpgradeRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class ReclaimTailoringModernUpgrade : Recipe
    {
        public ReclaimTailoringModernUpgrade()
        {
            this.Init(
                name: "ReclaimTailoringModernUpgrade",  //noloc
                displayName: Localizer.DoStr("Reclaim Modern Upgrade (Tailoring)"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(TailoringModernUpgradeItem), 1, true)
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<ModernUpgradeLvl4Item>(1)
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(LaboratoryObject), typeof(ReclaimModernUpgradeRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    #region MODDED

    public partial class ReclaimAgriculturalScienceUpgrade : Recipe
    {
        public ReclaimAgriculturalScienceUpgrade()
        {
            this.Init(
                name: "ReclaimAgriculturalScienceUpgrade",  //noloc
                displayName: Localizer.DoStr("Reclaim Modern Upgrade (Agricultural Science)"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(AgriculturalScienceUpgradeItem), 1, true)
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<ModernUpgradeLvl4Item>(1)
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(LaboratoryObject), typeof(ReclaimModernUpgradeRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    #endregion
}
