namespace CoFH.CookingFlexibility
{
    using Eco.Core.Plugins.Interfaces;
    ﻿using Eco.Core.Utils;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Modules;
    using Eco.Mods.TechTree;
    using Eco.Shared.Utils;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class ModPlugin : IModKitPlugin, IModInit
    {
        public string GetCategory() => "Team CoFH Mods";
        public string GetStatus() => $"Loaded CoFH Cooking Flexibiity";

        public static void Initialize()
        { }

        public static void PostInitialize()
        {
            var kitchen = Item.Get(typeof(KitchenItem));
            var kitchenAttribute = ItemAttribute.Get<AllowPluginModulesAttribute>(kitchen.Type);
            kitchenAttribute.ItemTypes = new[] { typeof(CookingUpgradeItem), typeof(AdvancedCookingUpgradeItem) };

            var stove = Item.Get(typeof(StoveItem));
            var stoveAttribute = ItemAttribute.Get<AllowPluginModulesAttribute>(stove.Type);
            stoveAttribute.ItemTypes = new[] { typeof(CookingUpgradeItem), typeof(AdvancedCookingUpgradeItem) };
        }
    }
}
