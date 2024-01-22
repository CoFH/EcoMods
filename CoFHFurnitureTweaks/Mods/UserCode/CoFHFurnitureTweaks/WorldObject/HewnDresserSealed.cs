﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated from WorldObjectTemplate.tt />

namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Core.Items;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Components.Auth;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Economy;
    using Eco.Gameplay.Housing;
    using Eco.Gameplay.Interactions;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Modules;
    using Eco.Gameplay.Minimap;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Occupancy;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Property;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Gameplay.Pipes.LiquidComponents;
    using Eco.Gameplay.Pipes.Gases;
    using Eco.Shared;
    using Eco.Shared.Math;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.View;
    using Eco.Shared.Items;
    using Eco.Shared.Networking;
    using Eco.Gameplay.Pipes;
    using Eco.World.Blocks;
    using Eco.Gameplay.Housing.PropertyValues;
    using Eco.Gameplay.Civics.Objects;
    using Eco.Gameplay.Settlements;
    using Eco.Gameplay.Systems.NewTooltip;
    using Eco.Core.Controller;
    using Eco.Core.Utils;
	using Eco.Gameplay.Components.Storage;
    using static Eco.Gameplay.Housing.PropertyValues.HomeFurnishingValue;
    using Eco.Gameplay.Items.Recipes;

    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    // [RequireComponent(typeof(LinkComponent))]
    [RequireComponent(typeof(HousingComponent))]
    // [RequireComponent(typeof(PublicStorageComponent))]
    [RequireComponent(typeof(OccupancyRequirementComponent))]
    // [RequireComponent(typeof(WardrobeComponent))]
    [RequireComponent(typeof(ForSaleComponent))]
    [RequireComponent(typeof(RoomRequirementsComponent))]
    [RequireRoomContainment]
    [RequireRoomVolume(12)]
    [Tag("Usable")]
    [Ecopedia("Housing Objects", "Bedroom", subPageName: "Hewn Dresser Item")]
    public partial class HewnDresserSealedObject : WorldObject, IRepresentsItem
    {
        public virtual Type RepresentedItemType => typeof(HewnDresserSealedItem);
        public override LocString DisplayName => Localizer.DoStr("Hewn Dresser (Sealed)");
        public override TableTextureMode TableTexture => TableTextureMode.Wood;

        protected override void Initialize()
        {
            this.ModsPreInitialize();
            this.GetComponent<HousingComponent>().HomeValue = HewnDresserSealedItem.homeValue;
            // var storage = this.GetComponent<PublicStorageComponent>();
            // storage.Initialize(16);
            // storage.Storage.AddInvRestriction(new ClothItemRestriction());
            // storage.Storage.AddInvRestriction(new NotCarriedRestriction()); // can't store block or large items
            // var wardrobe = this.GetComponent<WardrobeComponent>();
            // wardrobe.Initialize();
            this.ModsPostInitialize();
        }

        /// <summary>Hook for mods to customize WorldObject before initialization. You can change housing values here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize WorldObject after initialization.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Hewn Dresser (Sealed)")]
    [LocDescription("A rough hewn wooden dresser that lets you store your clothing and quickly switch between a designated outfit and whatever you are currently wearing.")]
    [Ecopedia("Housing Objects", "Bedroom", createAsSubPage: true)]
    [Tag("Housing")]
    [Weight(2000)] // Defines how heavy HewnDresser is.
    public partial class HewnDresserSealedItem : WorldObjectItem<HewnDresserSealedObject>
    {
        protected override OccupancyContext GetOccupancyContext => new SideAttachedContext( 0  | DirectionAxisFlags.Down , WorldObject.GetOccupancyInfo(this.WorldObjectType));
        public override HomeFurnishingValue HomeValue => homeValue;
        public static readonly HomeFurnishingValue homeValue = new HomeFurnishingValue()
        {
            ObjectName                              = typeof(HewnDresserSealedObject).UILink(),
            Category                                = HousingConfig.GetRoomCategory("Bedroom"),
            BaseValue                               = 1,
            TypeForRoomLimit                        = Localizer.DoStr("Dresser"),
            DiminishingReturnMultiplier                = 0.5f
            
        };

        static HewnDresserSealedItem()
        {
            WorldObject.AddOccupancy<HewnDresserSealedObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0)),
                new BlockOccupancy(new Vector3i(0, 0, 1)),
                new BlockOccupancy(new Vector3i(1, 0, 0)),
                new BlockOccupancy(new Vector3i(1, 0, 1)),
            });
        }

    }
}
