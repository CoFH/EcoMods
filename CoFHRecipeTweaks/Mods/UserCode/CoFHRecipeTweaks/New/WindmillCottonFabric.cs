namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using Eco.Core.Items;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Components.Auth;
    using Eco.Gameplay.Housing;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.Items;
    using Eco.Gameplay.Housing.PropertyValues;
    using Eco.Gameplay.Systems.NewTooltip;
    using Eco.Gameplay.Items.Recipes;

    public partial class WindmillCottonFabricRecipe : Recipe
    {
        public WindmillCottonFabricRecipe()
        {
            this.Init(
                name: "WindmillCotton",  //noloc
                displayName: Localizer.DoStr("Windmill"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(CottonFabricItem), 12, typeof(BasicEngineeringSkill), typeof(BasicEngineeringLavishResourcesTalent)),
                    new IngredientElement("HewnLog", 15, typeof(BasicEngineeringSkill), typeof(BasicEngineeringLavishResourcesTalent)), //noloc
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<WindmillItem>()
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(CarpentryTableObject), typeof(WindmillRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

}
