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
        [NewTooltip(CacheAs.Instance, 50, TTCat.Controls)]
        public static LocString RightClickTooltip(this BookshelfItem item) => TextLoc.WhisperLightLoc($"Right-click to prevent linking to this inventory.");

        [NewTooltip(CacheAs.Instance, 50, TTCat.Controls)]
        public static LocString RightClickTooltip(this BookshelfHiddenItem item) => TextLoc.WhisperLightLoc($"Right-click to allow linking to this inventory.");

        [NewTooltip(CacheAs.Instance, 500, TTCat.Controls)]
        public static LocString PlaceTooltip(this BookshelfHiddenItem item) => TextLoc.ControlsLoc($"[Select on toolbar and right-click to place]");
    
        [NewTooltip(CacheAs.Instance, 50, TTCat.Controls)]
        public static LocString RightClickTooltip(this HardwoodLumberDresserItem item) => TextLoc.WhisperLightLoc($"Right-click to prevent linking to this inventory.");

        [NewTooltip(CacheAs.Instance, 50, TTCat.Controls)]
        public static LocString RightClickTooltip(this HardwoodLumberDresserHiddenItem item) => TextLoc.WhisperLightLoc($"Right-click to allow linking to this inventory.");

        [NewTooltip(CacheAs.Instance, 500, TTCat.Controls)]
        public static LocString PlaceTooltip(this HardwoodLumberDresserHiddenItem item) => TextLoc.ControlsLoc($"[Select on toolbar and right-click to place]");

        [NewTooltip(CacheAs.Instance, 50, TTCat.Controls)]
        public static LocString RightClickTooltip(this HewnDresserItem item) => TextLoc.WhisperLightLoc($"Right-click to prevent linking to this inventory.");

        [NewTooltip(CacheAs.Instance, 50, TTCat.Controls)]
        public static LocString RightClickTooltip(this HewnDresserHiddenItem item) => TextLoc.WhisperLightLoc($"Right-click to allow linking to this inventory.");

        [NewTooltip(CacheAs.Instance, 500, TTCat.Controls)]
        public static LocString PlaceTooltip(this HewnDresserHiddenItem item) => TextLoc.ControlsLoc($"[Select on toolbar and right-click to place]");

        [NewTooltip(CacheAs.Instance, 50, TTCat.Controls)]
        public static LocString RightClickTooltip(this IceboxItem item) => TextLoc.WhisperLightLoc($"Right-click to prevent linking to this inventory.");

        [NewTooltip(CacheAs.Instance, 50, TTCat.Controls)]
        public static LocString RightClickTooltip(this IceboxHiddenItem item) => TextLoc.WhisperLightLoc($"Right-click to allow linking to this inventory.");

        [NewTooltip(CacheAs.Instance, 500, TTCat.Controls)]
        public static LocString PlaceTooltip(this IceboxHiddenItem item) => TextLoc.ControlsLoc($"[Select on toolbar and right-click to place]");

        [NewTooltip(CacheAs.Instance, 50, TTCat.Controls)]
        public static LocString RightClickTooltip(this LumberDresserItem item) => TextLoc.WhisperLightLoc($"Right-click to prevent linking to this inventory.");

        [NewTooltip(CacheAs.Instance, 50, TTCat.Controls)]
        public static LocString RightClickTooltip(this LumberDresserHiddenItem item) => TextLoc.WhisperLightLoc($"Right-click to allow linking to this inventory.");

        [NewTooltip(CacheAs.Instance, 500, TTCat.Controls)]
        public static LocString PlaceTooltip(this LumberDresserHiddenItem item) => TextLoc.ControlsLoc($"[Select on toolbar and right-click to place]");

        [NewTooltip(CacheAs.Instance, 50, TTCat.Controls)]
        public static LocString RightClickTooltip(this RefrigeratorItem item) => TextLoc.WhisperLightLoc($"Right-click to prevent linking to this inventory.");

        [NewTooltip(CacheAs.Instance, 50, TTCat.Controls)]
        public static LocString RightClickTooltip(this RefrigeratorHiddenItem item) => TextLoc.WhisperLightLoc($"Right-click to allow linking to this inventory.");

        [NewTooltip(CacheAs.Instance, 500, TTCat.Controls)]
        public static LocString PlaceTooltip(this RefrigeratorHiddenItem item) => TextLoc.ControlsLoc($"[Select on toolbar and right-click to place]");

        [NewTooltip(CacheAs.Instance, 50, TTCat.Controls)]
        public static LocString RightClickTooltip(this ShelfCabinetItem item) => TextLoc.WhisperLightLoc($"Right-click to prevent linking to this inventory.");

        [NewTooltip(CacheAs.Instance, 50, TTCat.Controls)]
        public static LocString RightClickTooltip(this ShelfCabinetHiddenItem item) => TextLoc.WhisperLightLoc($"Right-click to allow linking to this inventory.");

        [NewTooltip(CacheAs.Instance, 500, TTCat.Controls)]
        public static LocString PlaceTooltip(this ShelfCabinetHiddenItem item) => TextLoc.ControlsLoc($"[Select on toolbar and right-click to place]");

        [NewTooltip(CacheAs.Instance, 50, TTCat.Controls)]
        public static LocString RightClickTooltip(this SoftwoodLumberDresserItem item) => TextLoc.WhisperLightLoc($"Right-click to prevent linking to this inventory.");

        [NewTooltip(CacheAs.Instance, 50, TTCat.Controls)]
        public static LocString RightClickTooltip(this SoftwoodLumberDresserHiddenItem item) => TextLoc.WhisperLightLoc($"Right-click to allow linking to this inventory.");

        [NewTooltip(CacheAs.Instance, 500, TTCat.Controls)]
        public static LocString PlaceTooltip(this SoftwoodLumberDresserHiddenItem item) => TextLoc.ControlsLoc($"[Select on toolbar and right-click to place]");
    }
}