# CoFH Farming/Fertilizers Merge

This mod removes the Fertilizers skill and rolls all of the recipes and usages into Farming. That's it.

However, to do this (and properly update the Ecopedia), it is a highly invasive mod, making use of numerous `.override` classes and even a couple of changes to files in the `__core__` folder. If you wish to uninstall this mod, *please read the uninstallation instructions carefully.* The instructions assume that you have file extensions as visible. If you do not, please enable that setting.

## Installation Instructions:

- Extract/copy the `/Mods` folder in this zip file into the root folder for your Eco server.
- Optional: You may wish to also save this `Readme.md` file for future reference.
- Note: You may see a message about two files being overwritten - `Professions;Farmer.xml` and `Professions;Profession Overview.xml`
    - If you prevent the files from being overwitten, the Ecopedia will have minor errors as it will reference a removed skill. It's not a big deal, just be aware.
    - *Important: If you update your server, these two files will be overwritten by the patch and you will need to reinstall this mod to fix the Ecopedia.*

## Uninstallation Instructions:

### Automated Uninstall:
- Inspect the `CoFHFarmingFertilizersMergeRemove` uninstall script you wish to use using a text editing program.
    - `.bat` for Windows
    - `.sh` for Linux/Mac
- Ensure that you understand exactly what the script will do and are comfortable with it.
- Ensure that the script is in your `/Mods` folder (you should see `__core__` and `UserCode` folders) and execute it.

*If you are not comfortable with the above (which is completely understandable), perform a manual uninstallation:*

### Manual Uninstall:
In `/Mods/__core__/Ecopedia/Reference`, remove the following files:
- `Professions;Farmer.xml`
- `Professions;Profession Overview.xml`

In the *same folder* (`/Mods/__core__/Ecopedia/Reference`), you will see - `Professions;Farmer.xml.backup` and `Professions;Profession Overview.xml.backup`. Rename these files to remove the `.backup` portion of the file extension.

In `/Mods/UserCode/AutoGen/Fertilizer`, remove the following files (or just the `/Fertilizer` folder):
- `BerryExtractFertilizer.override.cs`
- `BloodMealFertilizer.override.cs`
- `CamasAshFertilizer.override.cs`
- `CompositeFiller.override.cs`
- `CompostFertilizer.override.cs`
- `FiberFillerFertilizer.override.cs`
- `HideAshFertilizer.override.cs`
- `PeltFertilizer.override.cs`
- `PhosphateFertilizer.override.cs`
- `PulpFiller.override.cs`

In `/Mods/UserCode/AutoGen/Item`, remove the following files:
- `AgricultureResearchPaperModern.override.cs`
- `SoilSampler.override.cs`

In `/Mods/UserCode/AutoGen/PluginModule`, remove the following file:
- `FertilizersUpgrade.override.cs`

In `/Mods/UserCode/AutoGen/Recipe`, remove the following file:
- `CompostSpoiledFood.override.cs`

In `/Mods/UserCode/AutoGen/Tech`, remove the following file:
- `Fertilizers.override.cs`

In `/Mods/UserCode/AutoGen/WorldObject`, remove the following file:
- `FarmersTable.override.cs`

In `/Mods/UserCode/Systems`, remove the following file:
- `DifficultyBasedRecipeVariants.override.cs`
