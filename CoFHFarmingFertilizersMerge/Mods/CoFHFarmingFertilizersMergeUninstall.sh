#!/bin/bash

uninstall()
{
    echo Uninstalling CoFH Farming/Fertilizer Merge Mod . . .
    echo Fixing Ecopedia Entries . . .

    rm "__core__/Ecopedia/Reference/Professions;Farmer.xml"
    rm "__core__/Ecopedia/Reference/Professions;Profession Overview.xml"

    mv "__core__/Ecopedia/Reference/Professions;Farmer.xml.backup" "__core__/Ecopedia/Reference/Professions;Farmer.xml"
    mv "__core__/Ecopedia/Reference/Professions;Profession Overview.xml.backup" "__core__/Ecopedia/Reference/Professions;Profession Overview.xml"

    echo Removing Mod Files . . .

    rm "UserCode/AutoGen/Fertilizer/"*.override.cs

    rm "UserCode/AutoGen/Item/AgricultureResearchPaperModern.override.cs"
    rm "UserCode/AutoGen/Item/SoilSampler.override.cs"

    rm "UserCode/AutoGen/PluginModule/FertilizersUpgrade.override.cs"

    rm "UserCode/AutoGen/Recipe/CompostSpoiledFood.override.cs"

    rm "UserCode/AutoGen/Tech/Fertilizers.override.cs"

    rm "UserCode/AutoGen/WorldObject/FarmersTable.override.cs"

    rm "UserCode/Systems/DifficultyBasedRecipeVariants.override.cs"

    echo Removing empty folders . . .

    touch "UserCode/CoFHtmp"

    find UserCode -empty -type d -delete

    rm "UserCode/CoFHtmp"

    echo Uninstaller will delete itself on completion. Thank you for using the mod!

    rm "CoFHFarmingFertilizersMergeUninstall"*
}

while true; do
    read -p "Please confirm uninstallation of the CoFH Farming/Fertilizer Merge Mod (Enter Y to confirm or N to cancel.) " yn
    case $yn in
        [Yy] ) uninstall; break;;
        [Nn] ) exit;;
        * ) echo "Please answer [Y]es or [N]o.";;
    esac
done
