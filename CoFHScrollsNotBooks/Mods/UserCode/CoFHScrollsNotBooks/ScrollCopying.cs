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

    public static class CopySkillScrollSettings
    {
        // How much paper to require to copy a scroll
        public const int PaperAmount = 10;
        // How much paint to require to copy a scroll
        public const int PaintAmount = 2;
    }

    [RequiresSkill(typeof(PaperMillingSkill), 5)]
    public partial class CopySkillScrollRecipe : RecipeFamily
    {
        public CopySkillScrollRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "CopyAdvancedBakingScroll",  //noloc
                displayName: Localizer.DoStr("Copy Skill Scroll (Advanced Baking)"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(AdvancedBakingSkillScroll), 1, true),
                    new IngredientElement(typeof(PaperItem), CopySkillScrollSettings.PaperAmount, typeof(PaperMillingSkill), typeof(PaperMillingLavishResourcesTalent)),
                    new IngredientElement(typeof(OilPaintItem), CopySkillScrollSettings.PaintAmount, typeof(PaperMillingSkill), typeof(PaperMillingLavishResourcesTalent))
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<AdvancedBakingSkillScroll>(2)
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 5; // Defines how much experience is gained when crafted.
            
            // Defines the amount of labor required and the required skill to add labor
            this.LaborInCalories = CreateLaborInCaloriesValue(120, typeof(PaperMillingSkill));

            // Defines our crafting time for the recipe
            this.CraftMinutes = CreateCraftTimeValue(beneficiary: typeof(CopySkillScrollRecipe), start: 2f, skillType: typeof(PaperMillingSkill), typeof(PaperMillingFocusedSpeedTalent), typeof(PaperMillingParallelSpeedTalent));

            // Perform pre/post initialization for user mods and initialize our recipe instance with the display name "Copy Skill Scroll"
            this.ModsPreInitialize();
            this.Initialize(displayText: Localizer.DoStr("Copy Skill Scroll"), recipeType: typeof(CopySkillScrollRecipe));
            this.ModsPostInitialize();

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddRecipe(tableType: typeof(SmallPaperMachineObject), recipe: this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class CopyAdvancedCookingScrollRecipe : Recipe
    {
        public CopyAdvancedCookingScrollRecipe()
        {
            this.Init(
                name: "CopyAdvancedCookingScroll",  //noloc
                displayName: Localizer.DoStr("Copy Skill Scroll (Advanced Cooking)"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(AdvancedCookingSkillScroll), 1, true),
                    new IngredientElement(typeof(PaperItem), CopySkillScrollSettings.PaperAmount, typeof(PaperMillingSkill), typeof(PaperMillingLavishResourcesTalent)),
                    new IngredientElement(typeof(OilPaintItem), CopySkillScrollSettings.PaintAmount, typeof(PaperMillingSkill), typeof(PaperMillingLavishResourcesTalent))
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<AdvancedCookingSkillScroll>(2)
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(SmallPaperMachineObject), typeof(CopySkillScrollRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class CopyAdvancedMasonryScrollRecipe : Recipe
    {
        public CopyAdvancedMasonryScrollRecipe()
        {
            this.Init(
                name: "CopyAdvancedMasonryScroll",  //noloc
                displayName: Localizer.DoStr("Copy Skill Scroll (Advanced Masonry)"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(AdvancedMasonrySkillScroll), 1, true),
                    new IngredientElement(typeof(PaperItem), CopySkillScrollSettings.PaperAmount, typeof(PaperMillingSkill), typeof(PaperMillingLavishResourcesTalent)),
                    new IngredientElement(typeof(OilPaintItem), CopySkillScrollSettings.PaintAmount, typeof(PaperMillingSkill), typeof(PaperMillingLavishResourcesTalent))
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<AdvancedMasonrySkillScroll>(2)
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(SmallPaperMachineObject), typeof(CopySkillScrollRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class CopyAdvancedSmeltingScrollRecipe : Recipe
    {
        public CopyAdvancedSmeltingScrollRecipe()
        {
            this.Init(
                name: "CopyAdvancedSmeltingScroll",  //noloc
                displayName: Localizer.DoStr("Copy Skill Scroll (Advanced Smelting)"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(AdvancedSmeltingSkillScroll), 1, true),
                    new IngredientElement(typeof(PaperItem), CopySkillScrollSettings.PaperAmount, typeof(PaperMillingSkill), typeof(PaperMillingLavishResourcesTalent)),
                    new IngredientElement(typeof(OilPaintItem), CopySkillScrollSettings.PaintAmount, typeof(PaperMillingSkill), typeof(PaperMillingLavishResourcesTalent))
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<AdvancedSmeltingSkillScroll>(2)
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(SmallPaperMachineObject), typeof(CopySkillScrollRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class CopyBakingScrollRecipe : Recipe
    {
        public CopyBakingScrollRecipe()
        {
            this.Init(
                name: "CopyBakingScroll",  //noloc
                displayName: Localizer.DoStr("Copy Skill Scroll (Baking)"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(BakingSkillScroll), 1, true),
                    new IngredientElement(typeof(PaperItem), CopySkillScrollSettings.PaperAmount, typeof(PaperMillingSkill), typeof(PaperMillingLavishResourcesTalent)),
                    new IngredientElement(typeof(OilPaintItem), CopySkillScrollSettings.PaintAmount, typeof(PaperMillingSkill), typeof(PaperMillingLavishResourcesTalent))
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<BakingSkillScroll>(2)
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(SmallPaperMachineObject), typeof(CopySkillScrollRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class CopyBasicEngineeringScrollRecipe : Recipe
    {
        public CopyBasicEngineeringScrollRecipe()
        {
            this.Init(
                name: "CopyBasicEngineeringScroll",  //noloc
                displayName: Localizer.DoStr("Copy Skill Scroll (Basic Engineering)"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(BasicEngineeringSkillScroll), 1, true),
                    new IngredientElement(typeof(PaperItem), CopySkillScrollSettings.PaperAmount, typeof(PaperMillingSkill), typeof(PaperMillingLavishResourcesTalent)),
                    new IngredientElement(typeof(OilPaintItem), CopySkillScrollSettings.PaintAmount, typeof(PaperMillingSkill), typeof(PaperMillingLavishResourcesTalent))
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<BasicEngineeringSkillScroll>(2)
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(SmallPaperMachineObject), typeof(CopySkillScrollRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class CopyButcheryScrollRecipe : Recipe
    {
        public CopyButcheryScrollRecipe()
        {
            this.Init(
                name: "CopyButcheryScroll",  //noloc
                displayName: Localizer.DoStr("Copy Skill Scroll (Butchery)"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(ButcherySkillScroll), 1, true),
                    new IngredientElement(typeof(PaperItem), CopySkillScrollSettings.PaperAmount, typeof(PaperMillingSkill), typeof(PaperMillingLavishResourcesTalent)),
                    new IngredientElement(typeof(OilPaintItem), CopySkillScrollSettings.PaintAmount, typeof(PaperMillingSkill), typeof(PaperMillingLavishResourcesTalent))
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<ButcherySkillScroll>(2)
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(SmallPaperMachineObject), typeof(CopySkillScrollRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class CopyCarpentryScrollRecipe : Recipe
    {
        public CopyCarpentryScrollRecipe()
        {
            this.Init(
                name: "CopyCarpentryScroll",  //noloc
                displayName: Localizer.DoStr("Copy Skill Scroll (Carpentry)"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(CarpentrySkillScroll), 1, true),
                    new IngredientElement(typeof(PaperItem), CopySkillScrollSettings.PaperAmount, typeof(PaperMillingSkill), typeof(PaperMillingLavishResourcesTalent)),
                    new IngredientElement(typeof(OilPaintItem), CopySkillScrollSettings.PaintAmount, typeof(PaperMillingSkill), typeof(PaperMillingLavishResourcesTalent))
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<CarpentrySkillScroll>(2)
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(SmallPaperMachineObject), typeof(CopySkillScrollRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class CopyCompositesScrollRecipe : Recipe
    {
        public CopyCompositesScrollRecipe()
        {
            this.Init(
                name: "CopyCompositesScroll",  //noloc
                displayName: Localizer.DoStr("Copy Skill Scroll (Composites)"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(CompositesSkillScroll), 1, true),
                    new IngredientElement(typeof(PaperItem), CopySkillScrollSettings.PaperAmount, typeof(PaperMillingSkill), typeof(PaperMillingLavishResourcesTalent)),
                    new IngredientElement(typeof(OilPaintItem), CopySkillScrollSettings.PaintAmount, typeof(PaperMillingSkill), typeof(PaperMillingLavishResourcesTalent))
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<CompositesSkillScroll>(2)
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(SmallPaperMachineObject), typeof(CopySkillScrollRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class CopyCookingScrollRecipe : Recipe
    {
        public CopyCookingScrollRecipe()
        {
            this.Init(
                name: "CopyCookingScroll",  //noloc
                displayName: Localizer.DoStr("Copy Skill Scroll (Cooking)"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(CookingSkillScroll), 1, true),
                    new IngredientElement(typeof(PaperItem), CopySkillScrollSettings.PaperAmount, typeof(PaperMillingSkill), typeof(PaperMillingLavishResourcesTalent)),
                    new IngredientElement(typeof(OilPaintItem), CopySkillScrollSettings.PaintAmount, typeof(PaperMillingSkill), typeof(PaperMillingLavishResourcesTalent))
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<CookingSkillScroll>(2)
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(SmallPaperMachineObject), typeof(CopySkillScrollRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class CopyCuttingEdgeCookingScrollRecipe : Recipe
    {
        public CopyCuttingEdgeCookingScrollRecipe()
        {
            this.Init(
                name: "CopyCuttingEdgeCookingScroll",  //noloc
                displayName: Localizer.DoStr("Copy Skill Scroll (Cutting Edge Cooking)"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(CuttingEdgeCookingSkillScroll), 1, true),
                    new IngredientElement(typeof(PaperItem), CopySkillScrollSettings.PaperAmount, typeof(PaperMillingSkill), typeof(PaperMillingLavishResourcesTalent)),
                    new IngredientElement(typeof(OilPaintItem), CopySkillScrollSettings.PaintAmount, typeof(PaperMillingSkill), typeof(PaperMillingLavishResourcesTalent))
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<CuttingEdgeCookingSkillScroll>(2)
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(SmallPaperMachineObject), typeof(CopySkillScrollRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class CopyElectronicsScrollRecipe : Recipe
    {
        public CopyElectronicsScrollRecipe()
        {
            this.Init(
                name: "CopyElectronicsScroll",  //noloc
                displayName: Localizer.DoStr("Copy Skill Scroll (Electronics)"),

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
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(SmallPaperMachineObject), typeof(CopySkillScrollRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class CopyFarmingScrollRecipe : Recipe
    {
        public CopyFarmingScrollRecipe()
        {
            this.Init(
                name: "CopyFarmingScroll",  //noloc
                displayName: Localizer.DoStr("Copy Skill Scroll (Farming)"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(FarmingSkillScroll), 1, true),
                    new IngredientElement(typeof(PaperItem), CopySkillScrollSettings.PaperAmount, typeof(PaperMillingSkill), typeof(PaperMillingLavishResourcesTalent)),
                    new IngredientElement(typeof(OilPaintItem), CopySkillScrollSettings.PaintAmount, typeof(PaperMillingSkill), typeof(PaperMillingLavishResourcesTalent))
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<FarmingSkillScroll>(2)
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(SmallPaperMachineObject), typeof(CopySkillScrollRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    // public partial class CopyFertilizersScrollRecipe : Recipe
    // {
    //     public CopyFertilizersScrollRecipe()
    //     {
    //         this.Init(
    //             name: "CopyFertilizersScroll",  //noloc
    //             displayName: Localizer.DoStr("Copy Skill Scroll (Fertilizers)"),

    //             // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
    //             // type of the item, the amount of the item, the skill required, and the talent used.
    //             ingredients: new List<IngredientElement>
    //             {
    //                 new IngredientElement(typeof(FertilizersSkillScroll), 1, true),
    //                 new IngredientElement(typeof(PaperItem), CopySkillScrollSettings.PaperAmount, typeof(PaperMillingSkill), typeof(PaperMillingLavishResourcesTalent)),
    //                 new IngredientElement(typeof(OilPaintItem), CopySkillScrollSettings.PaintAmount, typeof(PaperMillingSkill), typeof(PaperMillingLavishResourcesTalent))
    //             },

    //             // Define our recipe output items.
    //             // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
    //             // to create.
    //             items: new List<CraftingElement>
    //             {
    //                 new CraftingElement<FertilizersSkillScroll>(2)
    //             });
    //         // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
    //         this.ModsPostInitialize();
    //         CraftingComponent.AddTagProduct(typeof(SmallPaperMachineObject), typeof(CopySkillScrollRecipe), this);
    //     }

    //     /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
    //     partial void ModsPostInitialize();
    // }

    public partial class CopyGlassworkingScrollRecipe : Recipe
    {
        public CopyGlassworkingScrollRecipe()
        {
            this.Init(
                name: "CopyGlassworkingScroll",  //noloc
                displayName: Localizer.DoStr("Copy Skill Scroll (Glassworking)"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(GlassworkingSkillScroll), 1, true),
                    new IngredientElement(typeof(PaperItem), CopySkillScrollSettings.PaperAmount, typeof(PaperMillingSkill), typeof(PaperMillingLavishResourcesTalent)),
                    new IngredientElement(typeof(OilPaintItem), CopySkillScrollSettings.PaintAmount, typeof(PaperMillingSkill), typeof(PaperMillingLavishResourcesTalent))
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<GlassworkingSkillScroll>(2)
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(SmallPaperMachineObject), typeof(CopySkillScrollRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class CopyIndustryScrollRecipe : Recipe
    {
        public CopyIndustryScrollRecipe()
        {
            this.Init(
                name: "CopyIndustryScroll",  //noloc
                displayName: Localizer.DoStr("Copy Skill Scroll (Industry)"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(IndustrySkillScroll), 1, true),
                    new IngredientElement(typeof(PaperItem), CopySkillScrollSettings.PaperAmount, typeof(PaperMillingSkill), typeof(PaperMillingLavishResourcesTalent)),
                    new IngredientElement(typeof(OilPaintItem), CopySkillScrollSettings.PaintAmount, typeof(PaperMillingSkill), typeof(PaperMillingLavishResourcesTalent))
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<IndustrySkillScroll>(2)
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(SmallPaperMachineObject), typeof(CopySkillScrollRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class CopyMasonryScrollRecipe : Recipe
    {
        public CopyMasonryScrollRecipe()
        {
            this.Init(
                name: "CopyMasonryScroll",  //noloc
                displayName: Localizer.DoStr("Copy Skill Scroll (Masonry)"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(MasonrySkillScroll), 1, true),
                    new IngredientElement(typeof(PaperItem), CopySkillScrollSettings.PaperAmount, typeof(PaperMillingSkill), typeof(PaperMillingLavishResourcesTalent)),
                    new IngredientElement(typeof(OilPaintItem), CopySkillScrollSettings.PaintAmount, typeof(PaperMillingSkill), typeof(PaperMillingLavishResourcesTalent))
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<MasonrySkillScroll>(2)
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(SmallPaperMachineObject), typeof(CopySkillScrollRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class CopyMechanicsScrollRecipe : Recipe
    {
        public CopyMechanicsScrollRecipe()
        {
            this.Init(
                name: "CopyMechanicsScroll",  //noloc
                displayName: Localizer.DoStr("Copy Skill Scroll (Mechanics)"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(MechanicsSkillScroll), 1, true),
                    new IngredientElement(typeof(PaperItem), CopySkillScrollSettings.PaperAmount, typeof(PaperMillingSkill), typeof(PaperMillingLavishResourcesTalent)),
                    new IngredientElement(typeof(OilPaintItem), CopySkillScrollSettings.PaintAmount, typeof(PaperMillingSkill), typeof(PaperMillingLavishResourcesTalent))
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<MechanicsSkillScroll>(2)
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(SmallPaperMachineObject), typeof(CopySkillScrollRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class CopyMillingScrollRecipe : Recipe
    {
        public CopyMillingScrollRecipe()
        {
            this.Init(
                name: "CopyMillingScroll",  //noloc
                displayName: Localizer.DoStr("Copy Skill Scroll (Milling)"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(MillingSkillScroll), 1, true),
                    new IngredientElement(typeof(PaperItem), CopySkillScrollSettings.PaperAmount, typeof(PaperMillingSkill), typeof(PaperMillingLavishResourcesTalent)),
                    new IngredientElement(typeof(OilPaintItem), CopySkillScrollSettings.PaintAmount, typeof(PaperMillingSkill), typeof(PaperMillingLavishResourcesTalent))
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<MillingSkillScroll>(2)
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(SmallPaperMachineObject), typeof(CopySkillScrollRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class CopyOilDrillingScrollRecipe : Recipe
    {
        public CopyOilDrillingScrollRecipe()
        {
            this.Init(
                name: "CopyOilDrillingScroll",  //noloc
                displayName: Localizer.DoStr("Copy Skill Scroll (Oil Drilling)"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(OilDrillingSkillScroll), 1, true),
                    new IngredientElement(typeof(PaperItem), CopySkillScrollSettings.PaperAmount, typeof(PaperMillingSkill), typeof(PaperMillingLavishResourcesTalent)),
                    new IngredientElement(typeof(OilPaintItem), CopySkillScrollSettings.PaintAmount, typeof(PaperMillingSkill), typeof(PaperMillingLavishResourcesTalent))
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<OilDrillingSkillScroll>(2)
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(SmallPaperMachineObject), typeof(CopySkillScrollRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class CopyPaperMillingScrollRecipe : Recipe
    {
        public CopyPaperMillingScrollRecipe()
        {
            this.Init(
                name: "CopyPaperMillingScroll",  //noloc
                displayName: Localizer.DoStr("Copy Skill Scroll (Paper Milling)"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(PaperMillingSkillScroll), 1, true),
                    new IngredientElement(typeof(PaperItem), CopySkillScrollSettings.PaperAmount, typeof(PaperMillingSkill), typeof(PaperMillingLavishResourcesTalent)),
                    new IngredientElement(typeof(OilPaintItem), CopySkillScrollSettings.PaintAmount, typeof(PaperMillingSkill), typeof(PaperMillingLavishResourcesTalent))
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<PaperMillingSkillScroll>(2)
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(SmallPaperMachineObject), typeof(CopySkillScrollRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class CopyPotteryScrollRecipe : Recipe
    {
        public CopyPotteryScrollRecipe()
        {
            this.Init(
                name: "CopyPotteryScroll",  //noloc
                displayName: Localizer.DoStr("Copy Skill Scroll (Pottery)"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(PotterySkillScroll), 1, true),
                    new IngredientElement(typeof(PaperItem), CopySkillScrollSettings.PaperAmount, typeof(PaperMillingSkill), typeof(PaperMillingLavishResourcesTalent)),
                    new IngredientElement(typeof(OilPaintItem), CopySkillScrollSettings.PaintAmount, typeof(PaperMillingSkill), typeof(PaperMillingLavishResourcesTalent))
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<PotterySkillScroll>(2)
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(SmallPaperMachineObject), typeof(CopySkillScrollRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class CopySmeltingScrollRecipe : Recipe
    {
        public CopySmeltingScrollRecipe()
        {
            this.Init(
                name: "CopySmeltingScroll",  //noloc
                displayName: Localizer.DoStr("Copy Skill Scroll (Smelting)"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(SmeltingSkillScroll), 1, true),
                    new IngredientElement(typeof(PaperItem), CopySkillScrollSettings.PaperAmount, typeof(PaperMillingSkill), typeof(PaperMillingLavishResourcesTalent)),
                    new IngredientElement(typeof(OilPaintItem), CopySkillScrollSettings.PaintAmount, typeof(PaperMillingSkill), typeof(PaperMillingLavishResourcesTalent))
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<SmeltingSkillScroll>(2)
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(SmallPaperMachineObject), typeof(CopySkillScrollRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class CopyTailoringScrollRecipe : Recipe
    {
        public CopyTailoringScrollRecipe()
        {
            this.Init(
                name: "CopyTailoringScroll",  //noloc
                displayName: Localizer.DoStr("Copy Skill Scroll (Tailoring)"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(TailoringSkillScroll), 1, true),
                    new IngredientElement(typeof(PaperItem), CopySkillScrollSettings.PaperAmount, typeof(PaperMillingSkill), typeof(PaperMillingLavishResourcesTalent)),
                    new IngredientElement(typeof(OilPaintItem), CopySkillScrollSettings.PaintAmount, typeof(PaperMillingSkill), typeof(PaperMillingLavishResourcesTalent))
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<TailoringSkillScroll>(2)
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(SmallPaperMachineObject), typeof(CopySkillScrollRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class CopyShipwrightScrollRecipe : Recipe
    {
        public CopyShipwrightScrollRecipe()
        {
            this.Init(
                name: "CopyShipwrightScroll",  //noloc
                displayName: Localizer.DoStr("Copy Skill Scroll (Shipwright)"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(ShipwrightSkillScroll), 1, true),
                    new IngredientElement(typeof(PaperItem), CopySkillScrollSettings.PaperAmount, typeof(PaperMillingSkill), typeof(PaperMillingLavishResourcesTalent)),
                    new IngredientElement(typeof(OilPaintItem), CopySkillScrollSettings.PaintAmount, typeof(PaperMillingSkill), typeof(PaperMillingLavishResourcesTalent))
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<ShipwrightSkillScroll>(2)
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(SmallPaperMachineObject), typeof(CopySkillScrollRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    #region MODDED

    public partial class CopyAgriculturalScienceScrollRecipe : Recipe
    {
        public CopyAgriculturalScienceScrollRecipe()
        {
            this.Init(
                name: "CopyAgriculturalScienceScroll",  //noloc
                displayName: Localizer.DoStr("Copy Skill Scroll (Agricultural Science)"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(AgriculturalScienceSkillScroll), 1, true),
                    new IngredientElement(typeof(PaperItem), CopySkillScrollSettings.PaperAmount, typeof(PaperMillingSkill), typeof(PaperMillingLavishResourcesTalent)),
                    new IngredientElement(typeof(OilPaintItem), CopySkillScrollSettings.PaintAmount, typeof(PaperMillingSkill), typeof(PaperMillingLavishResourcesTalent))
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<AgriculturalScienceSkillScroll>(2)
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(SmallPaperMachineObject), typeof(CopySkillScrollRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    #endregion
}
