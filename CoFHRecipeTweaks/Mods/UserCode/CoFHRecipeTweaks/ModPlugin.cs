namespace CoFH.RecipeTweaks
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
        public string GetStatus() => $"Loaded CoFH Recipe Tweaks";

        public static void Initialize()
        { }

        public static void PostInitialize()
        {
            var spinMelter = Item.Get(typeof(SpinMelterItem));
            var spinMelterAttribute = ItemAttribute.Get<AllowPluginModulesAttribute>(spinMelter.Type);
            spinMelterAttribute.ItemTypes = new[] { typeof(TailoringModernUpgradeItem), typeof(GlassworkingModernUpgradeItem) };
        }
    }
}
