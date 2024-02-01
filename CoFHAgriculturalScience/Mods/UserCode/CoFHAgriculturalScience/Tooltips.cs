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
    public static class CoFHAgriculturalScienceTooltipLibrary
    {
        [NewTooltip(CacheAs.Instance, 0, TTCat.Details)]
        public static LocString NegativeTooltip(this CreosoteSyrupItem item) => TextLoc.NegativeLoc($"INDUCES VOMITING");

        [NewTooltip(CacheAs.Instance, 500, TTCat.Controls)]
        public static LocString ControlsTooltip(this CreosoteSyrupItem item) => TextLoc.ControlsLoc($"[Right-click to consume]");
    }
}