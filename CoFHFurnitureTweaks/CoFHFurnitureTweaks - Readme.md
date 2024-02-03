# CoFH Furniture Tweaks

This mod does a few major things:

- Allows a number of housing decoration objects to be placed on top of tables and other surfaces. Unfortunately, `.override` files are the only feasible way to do this at present - I spent a lot of time trying to NOT do it that way. Note: This feature exists in [Off the Floor](https://mod.io/g/eco/m/off-the-floor); I actually developed this independently but being intellectually honest, there is only one good way to do this at the moment so obviously generally the same lines will be commented out. If you *only* want this feature, then I recommend using that mod instead.

- Allows a number of lights (Candles, Wall Lights, Paper Lanterns) to be placed outside and remain functional by removing the room requirement from them. Larger lights (streetlamp, etc.) already had this ability and still provided housing value, while not actually taking up any space. Seems fair for other lights to do it too.

- Lights which use "Fat" as a fuel (Candle-based lights) now have a ShelfLifeMultiplier increase. By default, this is 10.0; you can configure the value in the `/UserCode/CoFHFurnitureTweaks/ModConfig.cs` file.

- Allows furniture items which have inventories to have keep them hidden from other inventories (this prevents linking *to* them - you can still see nearby inventories when you use the objects). Handy if you have a bunch of these objects in your house but do not want to deal with sorting them in all of your Stockpiles or Crafting Tables. All furniture items which have this functionality can be converted between the two variants (Normal/Hidden) by right-clicking on the item in your inventory.

This feature works with the following furniture items:

- Bookshelf
- Hewn Dresser
- Icebox
- Lumber Dresser (and Variants)
- Refrigerator
- Shelf Cabinet

If you like what you see here, you should check out Team CoFH's Minecraft mods.
[Team CoFH Discord](https://discord.gg/uRKrnbH)

## Installation Instructions:

- Extract/copy the `/Mods` folder in this zip file into the root folder for your Eco server.

## Uninstallation Instructions:

In `/Mods/UserCode/AutoGen/Benefit`, remove the following files:

- `CandleStand.override.cs`
- `CarvedPumpkin.override.cs`
- `CeilingCandle.override.cs`
- `ElectricWallLamp.override.cs`
- `GalaxyVase.override.cs`
- `LargeFestivePaperLantern.override.cs`
- `LargePaperLantern.override.cs`
- `LimestoneOtterStatue.override.cs`
- `LimestoneOwlStatue.override.cs`
- `OrangeVase.override.cs`
- `PlantVase.override.cs`
- `PurpleVase.override.cs`
- `RedVase.override.cs`
- `SmallPaperLantern.override.cs`
- `SteelTableLamp.override.cs`
- `SwirlVase.override.cs`
- `TallowCandle.override.cs`
- `TallowLamp.override.cs`
- `TallowWallLamp.override.cs`
- `WallCandle.override.cs`
- `WoodenTableLamp.override.cs`

- Remove the `CoFHFurnitureTweaks` folder from `/Mods/UserCode`
