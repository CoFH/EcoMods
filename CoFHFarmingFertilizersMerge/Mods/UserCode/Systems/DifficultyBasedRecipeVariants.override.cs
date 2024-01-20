// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.TechTree
{
    using Eco.Core.Plugins.Interfaces;
    using Eco.Gameplay.Items.Recipes;
    using Eco.Gameplay.Players;

    /// <summary> Registers recipe variants for different difficulty settings. </summary>
    public class DifficultyBasedRecipeVariants : IModInit
    {
        public static void PostInitialize()
        {
            // Normal recipe for lower collaboration settings. Uses defaults found in Tech Tree
			// Endgame Goal world object recipes
            RecipeVariant.RegisterDefault<ComputerLabRecipe>(DifficultyConfig.EndgameRecipesNormal);
            RecipeVariant.RegisterDefault<LaserRecipe>(DifficultyConfig.EndgameRecipesNormal);
            // Techtree skillbook recipes
            RecipeVariant.RegisterDefault<AdvancedBakingSkillBookRecipe>(DifficultyConfig.SkillbookRecipesNormal);
            RecipeVariant.RegisterDefault<AdvancedCookingSkillBookRecipe>(DifficultyConfig.SkillbookRecipesNormal);
            RecipeVariant.RegisterDefault<AdvancedMasonrySkillBookRecipe>(DifficultyConfig.SkillbookRecipesNormal);
            RecipeVariant.RegisterDefault<AdvancedSmeltingSkillBookRecipe>(DifficultyConfig.SkillbookRecipesNormal);
            RecipeVariant.RegisterDefault<BakingSkillBookRecipe>(DifficultyConfig.SkillbookRecipesNormal);
            RecipeVariant.RegisterDefault<BasicEngineeringSkillBookRecipe>(DifficultyConfig.SkillbookRecipesNormal);
            RecipeVariant.RegisterDefault<ButcherySkillBookRecipe>(DifficultyConfig.SkillbookRecipesNormal);
            RecipeVariant.RegisterDefault<CarpentrySkillBookRecipe>(DifficultyConfig.SkillbookRecipesNormal);
            RecipeVariant.RegisterDefault<CompositesSkillBookRecipe>(DifficultyConfig.SkillbookRecipesNormal);
            RecipeVariant.RegisterDefault<CookingSkillBookRecipe>(DifficultyConfig.SkillbookRecipesNormal);
            RecipeVariant.RegisterDefault<CuttingEdgeCookingSkillBookRecipe>(DifficultyConfig.SkillbookRecipesNormal);
            RecipeVariant.RegisterDefault<ElectronicsSkillBookRecipe>(DifficultyConfig.SkillbookRecipesNormal);
            RecipeVariant.RegisterDefault<FarmingSkillBookRecipe>(DifficultyConfig.SkillbookRecipesNormal);
            // RecipeVariant.RegisterDefault<FertilizersSkillBookRecipe>(DifficultyConfig.SkillbookRecipesNormal);
            RecipeVariant.RegisterDefault<GlassworkingSkillBookRecipe>(DifficultyConfig.SkillbookRecipesNormal);
            RecipeVariant.RegisterDefault<IndustrySkillBookRecipe>(DifficultyConfig.SkillbookRecipesNormal);
            RecipeVariant.RegisterDefault<MasonrySkillBookRecipe>(DifficultyConfig.SkillbookRecipesNormal);
            RecipeVariant.RegisterDefault<MechanicsSkillBookRecipe>(DifficultyConfig.SkillbookRecipesNormal);
            RecipeVariant.RegisterDefault<MillingSkillBookRecipe>(DifficultyConfig.SkillbookRecipesNormal);
            RecipeVariant.RegisterDefault<OilDrillingSkillBookRecipe>(DifficultyConfig.SkillbookRecipesNormal);
            RecipeVariant.RegisterDefault<PaperMillingSkillBookRecipe>(DifficultyConfig.SkillbookRecipesNormal);
            RecipeVariant.RegisterDefault<PotterySkillBookRecipe>(DifficultyConfig.SkillbookRecipesNormal);
            RecipeVariant.RegisterDefault<SmeltingSkillBookRecipe>(DifficultyConfig.SkillbookRecipesNormal);
            RecipeVariant.RegisterDefault<TailoringSkillBookRecipe>(DifficultyConfig.SkillbookRecipesNormal);



            // Expensive recipes for higher collaboration settings. All costs are static
            RecipeVariant.Register<ComputerLabRecipe>(DifficultyConfig.EndgameRecipesExpensive, new[]
            {
                new IngredientElement(typeof(AdvancedMasonryUpgradeItem), 1, true),
                new IngredientElement(typeof(CompositesUpgradeItem), 1, true),
                new IngredientElement(typeof(ElectronicsUpgradeItem), 1, true),
                new IngredientElement(typeof(IndustryUpgradeItem), 1, true),
                new IngredientElement(typeof(OilDrillingUpgradeItem), 1, true),
                new IngredientElement(typeof(AdvancedSmeltingUpgradeItem), 1, true),
                new IngredientElement(typeof(AdvancedCircuitItem), 100, true),
                new IngredientElement(typeof(PlasticItem), 100, true),
                new IngredientElement(typeof(ReinforcedConcreteItem), 200, true),
                new IngredientElement("CompositeLumber", 200, true)

            });
            RecipeVariant.Register<LaserRecipe>(DifficultyConfig.EndgameRecipesExpensive, new[]
            {
                new IngredientElement(typeof(GoldBarItem), 80, true),
                new IngredientElement(typeof(SteelBarItem), 80, true),
                new IngredientElement(typeof(FramedGlassItem), 80, true),
                new IngredientElement(typeof(AdvancedCircuitItem), 40, true),
                new IngredientElement(typeof(ElectricMotorItem), 2, true),
                new IngredientElement(typeof(RadiatorItem), 10, true)
            });
			// Expensive skill book recipes for higher collaboration settings. All costs are static
			RecipeVariant.Register<AdvancedBakingSkillBookRecipe>(DifficultyConfig.SkillbookRecipesExpensive, new[]
            {
                new IngredientElement(typeof(CulinaryResearchPaperAdvancedItem), 30, true),
                new IngredientElement(typeof(DendrologyResearchPaperModernItem), 15, true),
                new IngredientElement(typeof(GeologyResearchPaperModernItem), 15, true),
                new IngredientElement("Basic Research", 45, true),
                new IngredientElement("Advanced Research", 20, true),
                new IngredientElement("Modern Research", 20, true),
            });
			RecipeVariant.Register<AdvancedCookingSkillBookRecipe>(DifficultyConfig.SkillbookRecipesExpensive, new[]
            {
                new IngredientElement(typeof(CulinaryResearchPaperAdvancedItem), 30, true),
                new IngredientElement(typeof(DendrologyResearchPaperModernItem), 15, true),
                new IngredientElement(typeof(GeologyResearchPaperModernItem), 15, true),
                new IngredientElement("Basic Research", 45, true),
                new IngredientElement("Advanced Research", 15, true),
                new IngredientElement("Modern Research", 15, true),
            });
            RecipeVariant.Register<AdvancedMasonrySkillBookRecipe>(DifficultyConfig.SkillbookRecipesExpensive, new[]
            {
                new IngredientElement(typeof(GeologyResearchPaperAdvancedItem), 30, true),
                new IngredientElement(typeof(GeologyResearchPaperModernItem), 15, true),
                new IngredientElement(typeof(MetallurgyResearchPaperModernItem), 15, true),
                new IngredientElement(typeof(EngineeringResearchPaperModernItem), 15, true),
                new IngredientElement("Basic Research", 45, true),
                new IngredientElement("Advanced Research", 15, true),
            });
			RecipeVariant.Register<AdvancedSmeltingSkillBookRecipe>(DifficultyConfig.SkillbookRecipesExpensive, new[]
            {
                new IngredientElement(typeof(MetallurgyResearchPaperBasicItem), 30, true),
                new IngredientElement(typeof(MetallurgyResearchPaperAdvancedItem), 30, true),
                new IngredientElement("Basic Research", 15, true),
            });
			RecipeVariant.Register<BakingSkillBookRecipe>(DifficultyConfig.SkillbookRecipesExpensive, new[]
            {
                new IngredientElement(typeof(CulinaryResearchPaperBasicItem), 15, true),
                new IngredientElement(typeof(MetallurgyResearchPaperBasicItem), 10, true),
                new IngredientElement("Basic Research", 15, true),
            });
			RecipeVariant.Register<BasicEngineeringSkillBookRecipe>(DifficultyConfig.SkillbookRecipesExpensive, new[]
            {
                new IngredientElement(typeof(DendrologyResearchPaperAdvancedItem), 6, true),
                new IngredientElement("Basic Research", 10, true),
            });
			RecipeVariant.Register<ButcherySkillBookRecipe>(DifficultyConfig.SkillbookRecipesExpensive, new[]
            {
                new IngredientElement(typeof(CulinaryResearchPaperBasicItem), 6, true),
            });
			RecipeVariant.Register<CarpentrySkillBookRecipe>(DifficultyConfig.SkillbookRecipesExpensive, new[]
            {
                new IngredientElement(typeof(DendrologyResearchPaperBasicItem), 6, true),
            });
			RecipeVariant.Register<CompositesSkillBookRecipe>(DifficultyConfig.SkillbookRecipesExpensive, new[]
            {
                new IngredientElement(typeof(DendrologyResearchPaperAdvancedItem), 30, true),
                new IngredientElement(typeof(DendrologyResearchPaperModernItem), 15, true),
                new IngredientElement(typeof(MetallurgyResearchPaperModernItem), 15, true),
                new IngredientElement(typeof(EngineeringResearchPaperModernItem), 15, true),
                new IngredientElement("Basic Research", 45, true),
                new IngredientElement("Advanced Research", 15, true),
            });
			RecipeVariant.Register<CookingSkillBookRecipe>(DifficultyConfig.SkillbookRecipesExpensive, new[]
            {
                new IngredientElement(typeof(CulinaryResearchPaperBasicItem), 15, true),
                new IngredientElement(typeof(MetallurgyResearchPaperBasicItem), 10, true),
                new IngredientElement("Basic Research", 15, true),
            });
			RecipeVariant.Register<CuttingEdgeCookingSkillBookRecipe>(DifficultyConfig.SkillbookRecipesExpensive, new[]
            {
                new IngredientElement(typeof(CulinaryResearchPaperAdvancedItem), 30, true),
                new IngredientElement(typeof(CulinaryResearchPaperModernItem), 30, true),
                new IngredientElement(typeof(MetallurgyResearchPaperModernItem), 15, true),
                new IngredientElement(typeof(AgricultureResearchPaperModernItem), 15, true),
                new IngredientElement("Basic Research", 45, true),
                new IngredientElement("Advanced Research", 15, true),
            });
			RecipeVariant.Register<ElectronicsSkillBookRecipe>(DifficultyConfig.SkillbookRecipesExpensive, new[]
            {
                new IngredientElement(typeof(MetallurgyResearchPaperAdvancedItem), 15, true),
                new IngredientElement(typeof(EngineeringResearchPaperModernItem), 15, true),
                new IngredientElement(typeof(MetallurgyResearchPaperModernItem), 30, true),
                new IngredientElement("Basic Research", 45, true),
                new IngredientElement("Advanced Research", 30, true),
                new IngredientElement("Modern Research", 30, true),
            });
			RecipeVariant.Register<FarmingSkillBookRecipe>(DifficultyConfig.SkillbookRecipesExpensive, new[]
            {
                new IngredientElement(typeof(GatheringResearchPaperBasicItem), 4, true),
                new IngredientElement(typeof(GeologyResearchPaperBasicItem), 2, true),
            });
			RecipeVariant.Register<GlassworkingSkillBookRecipe>(DifficultyConfig.SkillbookRecipesExpensive, new[]
            {
                new IngredientElement(typeof(GeologyResearchPaperBasicItem), 20, true),
                new IngredientElement(typeof(GeologyResearchPaperAdvancedItem), 10, true),
                new IngredientElement(typeof(EngineeringResearchPaperAdvancedItem), 10, true),
                new IngredientElement("Basic Research", 15, true),
            });
			RecipeVariant.Register<IndustrySkillBookRecipe>(DifficultyConfig.SkillbookRecipesExpensive, new[]
            {
                new IngredientElement(typeof(EngineeringResearchPaperAdvancedItem), 10, typeof(MechanicsSkill)),
                new IngredientElement(typeof(EngineeringResearchPaperModernItem), 20, typeof(MechanicsSkill)),
                new IngredientElement(typeof(MetallurgyResearchPaperModernItem), 20, typeof(MechanicsSkill)),
                new IngredientElement("Basic Research", 30, typeof(MechanicsSkill)),
                new IngredientElement("Advanced Research", 20, typeof(MechanicsSkill)),
                new IngredientElement("Modern Research", 10, typeof(MechanicsSkill)),
            });
			RecipeVariant.Register<MasonrySkillBookRecipe>(DifficultyConfig.SkillbookRecipesExpensive, new[]
            {
                new IngredientElement(typeof(GeologyResearchPaperBasicItem), 6, true),
            });
			RecipeVariant.Register<MechanicsSkillBookRecipe>(DifficultyConfig.SkillbookRecipesExpensive, new[]
            {
                new IngredientElement(typeof(EngineeringResearchPaperAdvancedItem), 15, true),
                new IngredientElement(typeof(MetallurgyResearchPaperAdvancedItem), 15, true),
                new IngredientElement("Basic Research", 30, true),
                new IngredientElement("Advanced Research", 10, true),
            });
			RecipeVariant.Register<MillingSkillBookRecipe>(DifficultyConfig.SkillbookRecipesExpensive, new[]
            {
                new IngredientElement(typeof(DendrologyResearchPaperBasicItem), 10, true),
                new IngredientElement(typeof(GeologyResearchPaperBasicItem), 10, true),
                new IngredientElement(typeof(CulinaryResearchPaperBasicItem), 10, true),
                new IngredientElement(typeof(GatheringResearchPaperBasicItem), 5, true),
                new IngredientElement("Basic Research", 15, true),
            });
			RecipeVariant.Register<OilDrillingSkillBookRecipe>(DifficultyConfig.SkillbookRecipesExpensive, new[]
            {
                new IngredientElement(typeof(AgricultureResearchPaperAdvancedItem), 20, true),
                new IngredientElement(typeof(GeologyResearchPaperModernItem), 20, true),
                new IngredientElement(typeof(DendrologyResearchPaperModernItem), 20, true),
                new IngredientElement(typeof(EngineeringResearchPaperModernItem), 20, true),
                new IngredientElement("Basic Research", 45, true),
                new IngredientElement("Advanced Research", 30, true),
            });
			RecipeVariant.Register<PaperMillingSkillBookRecipe>(DifficultyConfig.SkillbookRecipesExpensive, new[]
            {
                new IngredientElement(typeof(DendrologyResearchPaperAdvancedItem), 10, true),
                new IngredientElement("Basic Research", 10, true),
            });
			RecipeVariant.Register<PotterySkillBookRecipe>(DifficultyConfig.SkillbookRecipesExpensive, new[]
            {
                new IngredientElement(typeof(GeologyResearchPaperBasicItem), 15, true),
                new IngredientElement(typeof(GeologyResearchPaperAdvancedItem), 10, true),
                new IngredientElement(typeof(EngineeringResearchPaperAdvancedItem), 10, true),
                new IngredientElement("Basic Research", 15, true),
            });
			RecipeVariant.Register<SmeltingSkillBookRecipe>(DifficultyConfig.SkillbookRecipesExpensive, new[]
            {
                new IngredientElement(typeof(MetallurgyResearchPaperBasicItem), 15, true),
                new IngredientElement(typeof(DendrologyResearchPaperAdvancedItem), 10, true),
                new IngredientElement(typeof(GeologyResearchPaperAdvancedItem), 10, true),
                new IngredientElement("Basic Research", 10, true),
            });
            RecipeVariant.Register<ShipwrightSkillBookRecipe>(DifficultyConfig.SkillbookRecipesExpensive, new[]
            {
                new IngredientElement(typeof(DendrologyResearchPaperBasicItem), 10, true),
                new IngredientElement(typeof(GatheringResearchPaperBasicItem), 10, true),
                new IngredientElement("Basic Research", 15, true), //noloc
            });
            RecipeVariant.Register<TailoringSkillBookRecipe>(DifficultyConfig.SkillbookRecipesExpensive, new[]
            {
                new IngredientElement(typeof(GatheringResearchPaperBasicItem), 10, true),
                new IngredientElement("Basic Research", 10, true),
            });
        }
    }
}
