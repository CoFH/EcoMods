# CoFH Agricultural Science

WORK IN PROGRESS

This mod adds a new skill - Agricultural Science! It's meant to be a higher-tier skill in the Farmer tree which helps to keep crops a bit more relevant into the lategame.

Some recipes from existing professions have been relocated to this skill.

The following new recipes are added:

## New Recipes:

Bio-Epoxy:
- 6 Flaxseed Oil -> 2 Epoxy (Agricultural Science 1, Laboratory, 180 Calories, 4 Minutes)

Bio-Plastic:
- 4 Bean Paste + 1 Cellulose Fiber -> 2 Plastic (Agricultural Science 1, Laboratory, 180 Calories, 4 Minutes)

The following existing recipes have been reassigned to this skill:

### Oil Drilling:
- Biodiesel

### Cutting Edge Cooking:
- Corn Ethanol
- Wheat Ethanol

If you like what you see here, you should check out Team CoFH's Minecraft mods.
[Team CoFH Discord](https://discord.gg/uRKrnbH)

## Installation Instructions:

- Extract/copy the `/Mods` folder in this zip file into the root folder for your Eco server.

## Uninstallation Instructions:

In `/Mods/UserCode/AutoGen/Block`, remove the following file:
- Biodiesel.override.cs

In `/Mods/UserCode/AutoGen/Recipe`, remove the following files:
- CornEthanol.override.cs
- WheatEthanol.override.cs

In `/Mods/UserCode/AutoGen/WorldObject`, remove the following files:
- Laboratory.override.cs
- OilRefinery.override.cs

- Remove the `CoFHAgriculturalScience` folder from `/Mods/UserCode`