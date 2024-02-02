namespace CoFH.AgriculturalScience
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
        public string GetStatus() => $"Loaded CoFH Agricultural Science";

        public static void Initialize()
        { }

        public static void PostInitialize()
        {
            var laboratory = Item.Get(typeof(LaboratoryItem));
            var laboratoryAttribute = ItemAttribute.Get<AllowPluginModulesAttribute>(laboratory.Type);
            laboratoryAttribute.ItemTypes = new[] { typeof(CuttingEdgeCookingUpgradeItem), typeof(AgriculturalScienceUpgradeItem) };

            var refinery = Item.Get(typeof(OilRefineryItem));
            var refineryAttribute = ItemAttribute.Get<AllowPluginModulesAttribute>(refinery.Type);
            refineryAttribute.ItemTypes = new[] { typeof(OilDrillingUpgradeItem), typeof(AgriculturalScienceUpgradeItem) };
        }
    }
}
