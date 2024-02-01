# CoFH Agricultural Science

This mod adds a new skill - Agricultural Science! It's meant to be a higher-tier skill in the Farmer tree which helps to keep crops a bit more relevant into the lategame.

Some recipes from existing professions have been relocated to this skill.

The following new items are added:

## New Items:

Activated Charcoal:
- Use directly on soil or a plant (like Fertilizers) to clean up Ground Pollution. Will not reduce pollution levels below 0 (I tried, it actually kills plants). Will not be used if it would have no effect.

Creosote Syrup:
- Consume to expel the contents of your stomach. Will also clear your calories. (This is actually a real thing - the Pima used this exact plant for this purpose.)

The following new recipes are added:

## New Recipes:

Activated Charcoal:
- 4 Charcoal + 1 Crushed Limestone -> 4 Activated Charcoal (Agricultural Science 4, Laboratory, 60 Calories, 2 Minutes)

Bio-Epoxy:
- 6 Flaxseed Oil -> 2 Epoxy (Agricultural Science 2, Laboratory, 180 Calories, 4 Minutes)

Bio-Plastic:
- 6 Bean Paste + 6 Cellulose Fiber -> 2 Plastic (Agricultural Science 2, Laboratory, 180 Calories, 4 Minutes)

Biodiesel:
- Same as Oil Drilling (Agricultural Science 3, Oil Refinery, 60 Calories, 0.8 Minutes)

Creosote Syrup:
- 20 Creosote Flower + 1 Ethanol -> 1 Creosote Syrup (Agricultural Science 4, Laboratory, 120 Calories, 2 Minutes)

The following existing recipes have been reassigned to this skill:

### Cutting Edge Cooking:
- Corn Ethanol
- Wheat Ethanol

If you like what you see here, you should check out Team CoFH's Minecraft mods.
[Team CoFH Discord](https://discord.gg/uRKrnbH)

## Installation Instructions:

- Extract/copy the `/Mods` folder in this zip file into the root folder for your Eco server.

## Uninstallation Instructions:

In `/Mods/UserCode/AutoGen/Recipe`, remove the following files:
- CornEthanol.override.cs
- WheatEthanol.override.cs

In `/Mods/UserCode/AutoGen/WorldObject`, remove the following files:
- Laboratory.override.cs
- OilRefinery.override.cs

- Remove the `CoFHAgriculturalScience` folder from `/Mods/UserCode`