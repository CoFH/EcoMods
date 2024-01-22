# CoFH Furniture Tweaks

This mod does two major things:

- Allows a number of housing decoration objects to be placed on top of tables and other surfaces. Unfortunately, `.override` files are the only feasible way to do this at present - I spent a lot of time trying to NOT do it that way. Note: This feature exists in ![Off the Floor](https://mod.io/g/eco/m/off-the-floor); I actually developed this independently but being intellectually honest, there is only one way to do this at the moment so obviously generally the same lines will be commented out. If you *only* want this feature, then I recommend using that mod instead.

NOT YET IMPLEMENTED, DON'T GET EXCITED:

- Allows furniture items which have inventories to be converted to decorative versions which do not. This will actually remove their inventories. Handy if you have a bunch of these objects in your house but do not want to deal with sorting them in all of your Stockpiles or Crafting Tables.

All furniture items which have this functionality can be converted from inventory to non-inventory (and back) by right-clicking on the item in your inventory.

This feature works with the following furniture items:

- Bookshelf
- Hewn Dresser
- Icebox
- Lumber Dresser (and Variants)
- Refrigerator
- Shelf Cabinet

## Installation Instructions:

- Extract/copy the `/Mods` folder in this zip file into the root folder for your Eco server.

## Uninstallation Instructions:

In `/Mods/UserCode/AutoGen/Benefit`, remove the following files:
- CandleStand.override.cs
- CarvedPumpkin.override.cs
- GalaxyVase.override.cs
- LimestoneOtterStatue.override.cs
- LimestoneOwlStatue.override.cs
- OrangeVase.override.cs
- PlantVase.override.cs
- RedVase.override.cs
- SteelTableLamp.override.cs
- SwirlVase.override.cs
- TallowCandle.override.cs
- TallowLamp.override.cs
- WoodenTableLamp.override.cs

- Remove the `CoFHFurnitureTweaks` folder from `/Mods/UserCode`