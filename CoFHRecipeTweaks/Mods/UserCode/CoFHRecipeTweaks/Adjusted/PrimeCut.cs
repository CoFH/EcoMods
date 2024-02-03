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
    using Eco.Shared.Localization;
    using Eco.Gameplay.Items.Recipes;

    public partial class PrimeCutRecipe : RecipeFamily
    {
        partial void ModsPreInitialize()
        {
            var products = this.Recipes[0].Products;
            products.Add(new CraftingElement<ScrapMeatItem>(8));
        }
    }
}
