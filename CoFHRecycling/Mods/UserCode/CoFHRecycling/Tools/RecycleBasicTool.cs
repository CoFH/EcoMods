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

    public partial class RecycleBasicToolRecipe : RecipeFamily
    {
        public RecycleBasicToolRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "RecycleStoneAxe",  //noloc
                displayName: Localizer.DoStr("Recycle Stone Axe"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(StoneAxeItem), 1, true)
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<WoodPulpItem>(4)
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 0; // Defines how much experience is gained when crafted.
            
            // Defines the amount of labor required and the required skill to add labor
            this.LaborInCalories = CreateLaborInCaloriesValue(10);

            // Defines our crafting time for the recipe
            this.CraftMinutes = CreateCraftTimeValue(0.25f);

            // Perform pre/post initialization for user mods and initialize our recipe instance with the display name "Recycle Stone Tool"
            this.ModsPreInitialize();
            this.Initialize(displayText: Localizer.DoStr("Recycle Basic Tool"), recipeType: typeof(RecycleBasicToolRecipe));
            this.ModsPostInitialize();

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddRecipe(tableType: typeof(ToolBenchObject), recipe: this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class RecycleStoneHammerRecipe : Recipe
    {
        public RecycleStoneHammerRecipe()
        {
            this.Init(
                name: "RecycleStoneHammer",  //noloc
                displayName: Localizer.DoStr("Recycle Stone Hammer"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(StoneHammerItem), 1, true)
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<WoodPulpItem>(4)
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(ToolBenchObject), typeof(RecycleBasicToolRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class RecycleStoneMacheteRecipe : Recipe
    {
        public RecycleStoneMacheteRecipe()
        {
            this.Init(
                name: "RecycleStoneMachete",  //noloc
                displayName: Localizer.DoStr("Recycle Stone Machete"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(StoneMacheteItem), 1, true)
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<WoodPulpItem>(4)
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(ToolBenchObject), typeof(RecycleBasicToolRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class RecycleStonePickaxeRecipe : Recipe
    {
        public RecycleStonePickaxeRecipe()
        {
            this.Init(
                name: "RecycleStonePickaxe",  //noloc
                displayName: Localizer.DoStr("Recycle Stone Pickaxe"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(StonePickaxeItem), 1, true)
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<WoodPulpItem>(4)
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(ToolBenchObject), typeof(RecycleBasicToolRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class RecycleStoneSickleRecipe : Recipe
    {
        public RecycleStoneSickleRecipe()
        {
            this.Init(
                name: "RecycleStoneSickle",  //noloc
                displayName: Localizer.DoStr("Recycle Stone Sickle"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(StoneSickleItem), 1, true)
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<WoodPulpItem>(4)
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(ToolBenchObject), typeof(RecycleBasicToolRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class RecycleWoodenHoeRecipe : Recipe
    {
        public RecycleWoodenHoeRecipe()
        {
            this.Init(
                name: "RecycleWoodenHoe",  //noloc
                displayName: Localizer.DoStr("Recycle Wooden Hoe"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(WoodenHoeItem), 1, true)
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<WoodPulpItem>(4)
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(ToolBenchObject), typeof(RecycleBasicToolRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class RecycleWoodenShovelRecipe : Recipe
    {
        public RecycleWoodenShovelRecipe()
        {
            this.Init(
                name: "RecycleWoodenShovel",  //noloc
                displayName: Localizer.DoStr("Recycle Wooden Shovel"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(WoodenShovelItem), 1, true)
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<WoodPulpItem>(4)
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(ToolBenchObject), typeof(RecycleBasicToolRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class RecycleWoodenBowRecipe : Recipe
    {
        public RecycleWoodenBowRecipe()
        {
            this.Init(
                name: "RecycleWoodenBow",  //noloc
                displayName: Localizer.DoStr("Recycle Wooden Bow"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(WoodenBowItem), 1, true)
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<WoodPulpItem>(6),
                    new CraftingElement<PlantFibersItem>(8)
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(ToolBenchObject), typeof(RecycleBasicToolRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class RecycleFishingPoleRecipe : Recipe
    {
        public RecycleFishingPoleRecipe()
        {
            this.Init(
                name: "RecycleFishingPole",  //noloc
                displayName: Localizer.DoStr("Recycle Fishing Pole"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(FishingPoleItem), 1, true)
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<WoodPulpItem>(4),
                    new CraftingElement<PlantFibersItem>(2)
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(ToolBenchObject), typeof(RecycleBasicToolRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
