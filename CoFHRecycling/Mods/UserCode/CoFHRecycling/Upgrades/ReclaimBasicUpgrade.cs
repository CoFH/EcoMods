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

    public partial class ReclaimBasicUpgradeRecipe : RecipeFamily
    {
        public ReclaimBasicUpgradeRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "ReclaimBasicEngineeringUpgrade",  //noloc
                displayName: Localizer.DoStr("Reclaim Basic Upgrade (Basic Engineering)"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(BasicEngineeringUpgradeItem), 1, true)
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<BasicUpgradeLvl4Item>(1)
                });
            this.Recipes = new List<Recipe> { recipe };
            
            // Defines the amount of labor required and the required skill to add labor
            this.LaborInCalories = CreateLaborInCaloriesValue(1500);

            // Defines our crafting time for the recipe
            this.CraftMinutes = CreateCraftTimeValue(5);

            // Perform pre/post initialization for user mods and initialize our recipe instance with the display name "Reclaim Basic Upgrade"
            this.ModsPreInitialize();
            this.Initialize(displayText: Localizer.DoStr("Reclaim Basic Upgrade"), recipeType: typeof(ReclaimBasicUpgradeRecipe));
            this.ModsPostInitialize();

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddRecipe(tableType: typeof(ResearchTableObject), recipe: this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class ReclaimButcheryUpgrade : Recipe
    {
        public ReclaimButcheryUpgrade()
        {
            this.Init(
                name: "ReclaimButcheryUpgrade",  //noloc
                displayName: Localizer.DoStr("Reclaim Basic Upgrade (Butchery)"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(ButcheryUpgradeItem), 1, true)
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<BasicUpgradeLvl4Item>(1)
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(ResearchTableObject), typeof(ReclaimBasicUpgradeRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class ReclaimCampfireCookingUpgrade : Recipe
    {
        public ReclaimCampfireCookingUpgrade()
        {
            this.Init(
                name: "ReclaimCampfireCookingUpgrade",  //noloc
                displayName: Localizer.DoStr("Reclaim Basic Upgrade (Campfire Cooking)"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(CampfireCookingUpgradeItem), 1, true)
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<BasicUpgradeLvl4Item>(1)
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(ResearchTableObject), typeof(ReclaimBasicUpgradeRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class ReclaimCarpentryBasicUpgrade : Recipe
    {
        public ReclaimCarpentryBasicUpgrade()
        {
            this.Init(
                name: "ReclaimCarpentryBasicUpgrade",  //noloc
                displayName: Localizer.DoStr("Reclaim Basic Upgrade (Carpentry)"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(CarpentryBasicUpgradeItem), 1, true)
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<BasicUpgradeLvl4Item>(1)
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(ResearchTableObject), typeof(ReclaimBasicUpgradeRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class ReclaimFarmingUpgrade : Recipe
    {
        public ReclaimFarmingUpgrade()
        {
            this.Init(
                name: "ReclaimFarmingUpgrade",  //noloc
                displayName: Localizer.DoStr("Reclaim Basic Upgrade (Farming)"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(FarmingUpgradeItem), 1, true)
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<BasicUpgradeLvl4Item>(1)
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(ResearchTableObject), typeof(ReclaimBasicUpgradeRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class ReclaimFertilizersUpgrade : Recipe
    {
        public ReclaimFertilizersUpgrade()
        {
            this.Init(
                name: "ReclaimFertilizersUpgrade",  //noloc
                displayName: Localizer.DoStr("Reclaim Basic Upgrade (Fertilizers)"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(FertilizersUpgradeItem), 1, true)
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<BasicUpgradeLvl4Item>(1)
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(ResearchTableObject), typeof(ReclaimBasicUpgradeRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class ReclaimGatheringBasicUpgrade : Recipe
    {
        public ReclaimGatheringBasicUpgrade()
        {
            this.Init(
                name: "ReclaimGatheringBasicUpgrade",  //noloc
                displayName: Localizer.DoStr("Reclaim Basic Upgrade (Gathering)"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(GatheringBasicUpgradeItem), 1, true)
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<BasicUpgradeLvl4Item>(1)
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(ResearchTableObject), typeof(ReclaimBasicUpgradeRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class ReclaimHuntingUpgrade : Recipe
    {
        public ReclaimHuntingUpgrade()
        {
            this.Init(
                name: "ReclaimHuntingUpgrade",  //noloc
                displayName: Localizer.DoStr("Reclaim Basic Upgrade (Hunting)"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(HuntingUpgradeItem), 1, true)
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<BasicUpgradeLvl4Item>(1)
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(ResearchTableObject), typeof(ReclaimBasicUpgradeRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class ReclaimLoggingUpgrade : Recipe
    {
        public ReclaimLoggingUpgrade()
        {
            this.Init(
                name: "ReclaimLoggingBasicUpgrade",  //noloc
                displayName: Localizer.DoStr("Reclaim Basic Upgrade (Logging)"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(LoggingBasicUpgradeItem), 1, true)
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<BasicUpgradeLvl4Item>(1)
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(ResearchTableObject), typeof(ReclaimBasicUpgradeRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class ReclaimMasonryUpgrade : Recipe
    {
        public ReclaimMasonryUpgrade()
        {
            this.Init(
                name: "ReclaimMasonryBasicUpgrade",  //noloc
                displayName: Localizer.DoStr("Reclaim Basic Upgrade (Masonry)"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(MasonryBasicUpgradeItem), 1, true)
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<BasicUpgradeLvl4Item>(1)
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(ResearchTableObject), typeof(ReclaimBasicUpgradeRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class ReclaimMillingUpgrade : Recipe
    {
        public ReclaimMillingUpgrade()
        {
            this.Init(
                name: "ReclaimMillingUpgrade",  //noloc
                displayName: Localizer.DoStr("Reclaim Basic Upgrade (Milling)"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(MillingUpgradeItem), 1, true)
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<BasicUpgradeLvl4Item>(1)
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(ResearchTableObject), typeof(ReclaimBasicUpgradeRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class ReclaimMiningBasicUpgrade : Recipe
    {
        public ReclaimMiningBasicUpgrade()
        {
            this.Init(
                name: "ReclaimMiningBasicUpgrade",  //noloc
                displayName: Localizer.DoStr("Reclaim Basic Upgrade (Mining)"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(MiningBasicUpgradeItem), 1, true)
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<BasicUpgradeLvl4Item>(1)
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(ResearchTableObject), typeof(ReclaimBasicUpgradeRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class ReclaimPaperMillingUpgrade : Recipe
    {
        public ReclaimPaperMillingUpgrade()
        {
            this.Init(
                name: "ReclaimPaperMillingBasicUpgrade",  //noloc
                displayName: Localizer.DoStr("Reclaim Basic Upgrade (Paper Milling)"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(PaperMillingUpgradeItem), 1, true)
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<BasicUpgradeLvl4Item>(1)
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(ResearchTableObject), typeof(ReclaimBasicUpgradeRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class ReclaimShipwrightBasicUpgrade : Recipe
    {
        public ReclaimShipwrightBasicUpgrade()
        {
            this.Init(
                name: "ReclaimShipwrightBasicUpgrade",  //noloc
                displayName: Localizer.DoStr("Reclaim Basic Upgrade (Shipwright)"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(ShipwrightBasicUpgradeItem), 1, true)
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<BasicUpgradeLvl4Item>(1)
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(ResearchTableObject), typeof(ReclaimBasicUpgradeRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class ReclaimTailoringUpgrade : Recipe
    {
        public ReclaimTailoringUpgrade()
        {
            this.Init(
                name: "ReclaimTailoringUpgrade",  //noloc
                displayName: Localizer.DoStr("Reclaim Basic Upgrade (Tailoring)"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(TailoringUpgradeItem), 1, true)
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<BasicUpgradeLvl4Item>(1)
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(ResearchTableObject), typeof(ReclaimBasicUpgradeRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}