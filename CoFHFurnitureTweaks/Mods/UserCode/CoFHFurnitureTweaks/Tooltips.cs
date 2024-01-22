namespace Eco.Gameplay.Systems.NewTooltip.TooltipLibraryFiles
{
    using Eco.Core.Utils;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Economy;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Mods.TechTree;
    using Eco.Shared.Gameplay;
    using Eco.Shared.Items;
    using Eco.Shared.Localization;
    using Eco.Shared.Utils;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Eco.Shared.IoC;
    using Eco.Core.PropertyHandling;
    using Eco.Gameplay.Items.Recipes;

    [TooltipLibrary]
    public static class CoFHFurnitureTweaksTooltipLibrary
    {
        [NewTooltip(CacheAs.Instance, 500, TTCat.Controls)]
        public static LocString ControlsTooltip(this BookshelfItem item) => TextLoc.ControlsLoc($"Right-click to prevent linking to this inventory.");

        [NewTooltip(CacheAs.Instance, 500, TTCat.Controls)]
        public static LocString ControlsTooltip(this BookshelfHiddenItem item) => TextLoc.ControlsLoc($"Right-click to allow linking to this inventory.\n\n[Select on toolbar and right-click to place]");
    
        [NewTooltip(CacheAs.Instance, 500, TTCat.Controls)]
        public static LocString ControlsTooltip(this HardwoodLumberDresserItem item) => TextLoc.ControlsLoc($"Right-click to prevent linking to this inventory.");

        [NewTooltip(CacheAs.Instance, 500, TTCat.Controls)]
        public static LocString ControlsTooltip(this HardwoodLumberDresserHiddenItem item) => TextLoc.ControlsLoc($"Right-click to allow linking to this inventory.\n\n[Select on toolbar and right-click to place]");

        [NewTooltip(CacheAs.Instance, 500, TTCat.Controls)]
        public static LocString ControlsTooltip(this HewnDresserItem item) => TextLoc.ControlsLoc($"Right-click to prevent linking to this inventory.");

        [NewTooltip(CacheAs.Instance, 500, TTCat.Controls)]
        public static LocString ControlsTooltip(this HewnDresserHiddenItem item) => TextLoc.ControlsLoc($"Right-click to allow linking to this inventory.\n\n[Select on toolbar and right-click to place]");

        [NewTooltip(CacheAs.Instance, 500, TTCat.Controls)]
        public static LocString ControlsTooltip(this IceboxItem item) => TextLoc.ControlsLoc($"Right-click to prevent linking to this inventory.");

        [NewTooltip(CacheAs.Instance, 500, TTCat.Controls)]
        public static LocString ControlsTooltip(this IceboxHiddenItem item) => TextLoc.ControlsLoc($"Right-click to allow linking to this inventory.\n\n[Select on toolbar and right-click to place]");

        [NewTooltip(CacheAs.Instance, 500, TTCat.Controls)]
        public static LocString ControlsTooltip(this LumberDresserItem item) => TextLoc.ControlsLoc($"Right-click to prevent linking to this inventory.");

        [NewTooltip(CacheAs.Instance, 500, TTCat.Controls)]
        public static LocString ControlsTooltip(this LumberDresserHiddenItem item) => TextLoc.ControlsLoc($"Right-click to allow linking to this inventory.\n\n[Select on toolbar and right-click to place]");

        [NewTooltip(CacheAs.Instance, 500, TTCat.Controls)]
        public static LocString ControlsTooltip(this RefrigeratorItem item) => TextLoc.ControlsLoc($"Right-click to prevent linking to this inventory.");

        [NewTooltip(CacheAs.Instance, 500, TTCat.Controls)]
        public static LocString ControlsTooltip(this RefrigeratorHiddenItem item) => TextLoc.ControlsLoc($"Right-click to allow linking to this inventory.\n\n[Select on toolbar and right-click to place]");

        [NewTooltip(CacheAs.Instance, 500, TTCat.Controls)]
        public static LocString ControlsTooltip(this ShelfCabinetItem item) => TextLoc.ControlsLoc($"Right-click to prevent linking to this inventory.");

        [NewTooltip(CacheAs.Instance, 500, TTCat.Controls)]
        public static LocString ControlsTooltip(this ShelfCabinetHiddenItem item) => TextLoc.ControlsLoc($"Right-click to allow linking to this inventory.\n\n[Select on toolbar and right-click to place]");

        [NewTooltip(CacheAs.Instance, 500, TTCat.Controls)]
        public static LocString ControlsTooltip(this SoftwoodLumberDresserItem item) => TextLoc.ControlsLoc($"Right-click to prevent linking to this inventory.");

        [NewTooltip(CacheAs.Instance, 500, TTCat.Controls)]
        public static LocString ControlsTooltip(this SoftwoodLumberDresserHiddenItem item) => TextLoc.ControlsLoc($"Right-click to allow linking to this inventory.\n\n[Select on toolbar and right-click to place]");
    }
}