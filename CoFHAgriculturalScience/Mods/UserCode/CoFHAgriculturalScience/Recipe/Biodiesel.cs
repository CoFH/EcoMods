// namespace Eco.Mods.TechTree
// {
//     using System;
//     using System.Collections.Generic;
//     using System.ComponentModel;
//     using Eco.Gameplay.Blocks;
//     using Eco.Gameplay.Components;
//     using Eco.Gameplay.DynamicValues;
//     using Eco.Gameplay.Items;
//     using Eco.Gameplay.Objects;
//     using Eco.Gameplay.Players;
//     using Eco.Gameplay.Skills;
//     using Eco.Gameplay.Systems;
//     using Eco.Gameplay.Systems.TextLinks;
//     using Eco.Core.Items;
//     using Eco.Shared.Localization;
//     using Eco.Shared.Serialization;
//     using Eco.Shared.Utils;
//     using Eco.Shared.SharedTypes;
//     using Eco.World;
//     using Eco.World.Blocks;
//     using Eco.World.Water;
//     using Eco.Gameplay.Pipes;
//     using Eco.Gameplay.Pipes.LiquidComponents;
//     using Eco.Core.Controller;
//     using Eco.Gameplay.Items.Recipes;

//     [RequiresSkill(typeof(AgriculturalScienceSkill), 3)]
//     [Ecopedia("Blocks", "Liquids", subPageName: "Biodiesel Item")]
//     public partial class BiodieselAgSciRecipe : RecipeFamily
//     {
//         public BiodieselAgSciRecipe()
//         {
//             var recipe = new Recipe();
//             recipe.Init(
//                 name: "BiodieselAgSci",  //noloc
//                 displayName: Localizer.DoStr("Biodiesel"),

//                 // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
//                 // type of the item, the amount of the item, the skill required, and the talent used.
//                 ingredients: new List<IngredientElement>
//                 {
//                     new IngredientElement(typeof(EthanolItem), 4, typeof(AgriculturalScienceSkill), typeof(AgriculturalScienceLavishResourcesTalent)),
//                     new IngredientElement("Fat", 5, typeof(AgriculturalScienceSkill), typeof(AgriculturalScienceLavishResourcesTalent)), //noloc
//                     new IngredientElement(typeof(BarrelItem), 1, true),
//                 },

//                 // Define our recipe output items.
//                 // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
//                 // to create.
//                 items: new List<CraftingElement>
//                 {
//                     new CraftingElement<BiodieselItem>()
//                 });
//             this.Recipes = new List<Recipe> { recipe };
//             this.ExperienceOnCraft = 0.5f; // Defines how much experience is gained when crafted.
            
//             // Defines the amount of labor required and the required skill to add labor
//             this.LaborInCalories = CreateLaborInCaloriesValue(60, typeof(AgriculturalScienceSkill));

//             // Defines our crafting time for the recipe
//             this.CraftMinutes = CreateCraftTimeValue(beneficiary: typeof(BiodieselAgSciRecipe), start: 0.8f, skillType: typeof(AgriculturalScienceSkill), typeof(AgriculturalScienceFocusedSpeedTalent), typeof(AgriculturalScienceParallelSpeedTalent));

//             // Perform pre/post initialization for user mods and initialize our recipe instance with the display name "Biodiesel"
//             this.ModsPreInitialize();
//             this.Initialize(displayText: Localizer.DoStr("Biodiesel"), recipeType: typeof(BiodieselAgSciRecipe));
//             this.ModsPostInitialize();

//             // Register our RecipeFamily instance with the crafting system so it can be crafted.
//             CraftingComponent.AddRecipe(tableType: typeof(OilRefineryObject), recipe: this);
//         }

//         /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
//         partial void ModsPreInitialize();

//         /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
//         partial void ModsPostInitialize();
//     }
// }
