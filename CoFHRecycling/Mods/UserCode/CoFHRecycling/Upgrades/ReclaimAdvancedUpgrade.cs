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

    public partial class ReclaimAdvancedUpgradeRecipe : RecipeFamily
    {
        public ReclaimAdvancedUpgradeRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "ReclaimAdvancedBakingUpgrade",  //noloc
                displayName: Localizer.DoStr("Reclaim Advanced Upgrade (Advanced Baking)"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(AdvancedBakingUpgradeItem), 1, true)
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<AdvancedUpgradeLvl4Item>(1)
                });
            this.Recipes = new List<Recipe> { recipe };
            
            // Defines the amount of labor required and the required skill to add labor
            this.LaborInCalories = CreateLaborInCaloriesValue(3000);

            // Defines our crafting time for the recipe
            this.CraftMinutes = CreateCraftTimeValue(7.5f);

            // Perform pre/post initialization for user mods and initialize our recipe instance with the display name "Reclaim Advanced Upgrade"
            this.ModsPreInitialize();
            this.Initialize(displayText: Localizer.DoStr("Reclaim Advanced Upgrade"), recipeType: typeof(ReclaimAdvancedUpgradeRecipe));
            this.ModsPostInitialize();

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddRecipe(tableType: typeof(LaboratoryObject), recipe: this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class ReclaimAdvancedCookingUpgrade : Recipe
    {
        public ReclaimAdvancedCookingUpgrade()
        {
            this.Init(
                name: "ReclaimAdvancedCookingUpgrade",  //noloc
                displayName: Localizer.DoStr("Reclaim Advanced Upgrade (Advanced Cooking)"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(AdvancedCookingUpgradeItem), 1, true)
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<AdvancedUpgradeLvl4Item>(1)
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(LaboratoryObject), typeof(ReclaimAdvancedUpgradeRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class ReclaimAdvancedSmeltingUpgrade : Recipe
    {
        public ReclaimAdvancedSmeltingUpgrade()
        {
            this.Init(
                name: "ReclaimAdvancedSmeltingUpgrade",  //noloc
                displayName: Localizer.DoStr("Reclaim Advanced Upgrade (Advanced Smelting)"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(AdvancedSmeltingUpgradeItem), 1, true)
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<AdvancedUpgradeLvl4Item>(1)
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(LaboratoryObject), typeof(ReclaimAdvancedUpgradeRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class ReclaimBakingUpgrade : Recipe
    {
        public ReclaimBakingUpgrade()
        {
            this.Init(
                name: "ReclaimBakingUpgrade",  //noloc
                displayName: Localizer.DoStr("Reclaim Advanced Upgrade (Baking)"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(BakingUpgradeItem), 1, true)
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<AdvancedUpgradeLvl4Item>(1)
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(LaboratoryObject), typeof(ReclaimAdvancedUpgradeRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class ReclaimCarpentryAdvancedUpgrade : Recipe
    {
        public ReclaimCarpentryAdvancedUpgrade()
        {
            this.Init(
                name: "ReclaimCarpentryAdvancedUpgrade",  //noloc
                displayName: Localizer.DoStr("Reclaim Advanced Upgrade (Carpentry)"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(CarpentryAdvancedUpgradeItem), 1, true)
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<AdvancedUpgradeLvl4Item>(1)
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(LaboratoryObject), typeof(ReclaimAdvancedUpgradeRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class ReclaimCookingUpgrade : Recipe
    {
        public ReclaimCookingUpgrade()
        {
            this.Init(
                name: "ReclaimCookingUpgrade",  //noloc
                displayName: Localizer.DoStr("Reclaim Advanced Upgrade (Cooking)"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(CookingUpgradeItem), 1, true)
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<AdvancedUpgradeLvl4Item>(1)
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(LaboratoryObject), typeof(ReclaimAdvancedUpgradeRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class ReclaimGlassworkingAdvancedUpgrade : Recipe
    {
        public ReclaimGlassworkingAdvancedUpgrade()
        {
            this.Init(
                name: "ReclaimGlassworkingAdvancedUpgrade",  //noloc
                displayName: Localizer.DoStr("Reclaim Advanced Upgrade (Glassworking)"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(GlassworkingAdvancedUpgradeItem), 1, true)
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<AdvancedUpgradeLvl4Item>(1)
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(LaboratoryObject), typeof(ReclaimAdvancedUpgradeRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class ReclaimLoggingAdvancedUpgrade : Recipe
    {
        public ReclaimLoggingAdvancedUpgrade()
        {
            this.Init(
                name: "ReclaimLoggingAdvancedUpgrade",  //noloc
                displayName: Localizer.DoStr("Reclaim Advanced Upgrade (Logging)"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(LoggingAdvancedUpgradeItem), 1, true)
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<AdvancedUpgradeLvl4Item>(1)
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(LaboratoryObject), typeof(ReclaimAdvancedUpgradeRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class ReclaimMasonryAdvancedUpgrade : Recipe
    {
        public ReclaimMasonryAdvancedUpgrade()
        {
            this.Init(
                name: "ReclaimMasonryAdvancedUpgrade",  //noloc
                displayName: Localizer.DoStr("Reclaim Advanced Upgrade (Masonry)"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(MasonryAdvancedUpgradeItem), 1, true)
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<AdvancedUpgradeLvl4Item>(1)
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(LaboratoryObject), typeof(ReclaimAdvancedUpgradeRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class ReclaimMechanicsAdvancedUpgrade : Recipe
    {
        public ReclaimMechanicsAdvancedUpgrade()
        {
            this.Init(
                name: "ReclaimMechanicsAdvancedUpgrade",  //noloc
                displayName: Localizer.DoStr("Reclaim Advanced Upgrade (Mechanics)"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(MechanicsAdvancedUpgradeItem), 1, true)
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<AdvancedUpgradeLvl4Item>(1)
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(LaboratoryObject), typeof(ReclaimAdvancedUpgradeRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class ReclaimMiningAdvancedUpgrade : Recipe
    {
        public ReclaimMiningAdvancedUpgrade()
        {
            this.Init(
                name: "ReclaimMiningAdvancedUpgrade",  //noloc
                displayName: Localizer.DoStr("Reclaim Advanced Upgrade (Mining)"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(MiningAdvancedUpgradeItem), 1, true)
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<AdvancedUpgradeLvl4Item>(1)
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(LaboratoryObject), typeof(ReclaimAdvancedUpgradeRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class ReclaimPotteryUpgrade : Recipe
    {
        public ReclaimPotteryUpgrade()
        {
            this.Init(
                name: "ReclaimPotteryUpgrade",  //noloc
                displayName: Localizer.DoStr("Reclaim Advanced Upgrade (Pottery)"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(PotteryUpgradeItem), 1, true)
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<AdvancedUpgradeLvl4Item>(1)
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(LaboratoryObject), typeof(ReclaimAdvancedUpgradeRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class ReclaimShipwrightAdvancedUpgrade : Recipe
    {
        public ReclaimShipwrightAdvancedUpgrade()
        {
            this.Init(
                name: "ReclaimShipwrightAdvancedUpgrade",  //noloc
                displayName: Localizer.DoStr("Reclaim Advanced Upgrade (Shipwright)"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(ShipwrightAdvancedUpgradeItem), 1, true)
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<AdvancedUpgradeLvl4Item>(1)
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(LaboratoryObject), typeof(ReclaimAdvancedUpgradeRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class ReclaimSmeltingUpgrade : Recipe
    {
        public ReclaimSmeltingUpgrade()
        {
            this.Init(
                name: "ReclaimSmeltingUpgrade",  //noloc
                displayName: Localizer.DoStr("Reclaim Advanced Upgrade (Smelting)"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(SmeltingUpgradeItem), 1, true)
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<AdvancedUpgradeLvl4Item>(1)
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(LaboratoryObject), typeof(ReclaimAdvancedUpgradeRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}