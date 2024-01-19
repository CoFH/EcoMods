@echo off

title CoFH Farming/Fertilizer Merge Uninstall

:prompt
set /P c=Please confirm uninstallation of the CoFH Farming/Fertilizer Merge Mod (Enter Y to confirm or N to cancel.) 
if /I "%c%" EQU "Y" goto :confirm
if /I "%c%" EQU "N" goto :cancel
echo "Please answer [Y]es or [N]o."
goto :prompt

:confirm

echo Uninstalling CoFH Farming/Fertilizer Merge Mod . . .
echo Fixing Ecopedia Entries . . .

del ".\__core__\Ecopedia\Reference\Professions;Farmer.xml"
del ".\__core__\Ecopedia\Reference\Professions;Profession Overview.xml"

ren ".\__core__\Ecopedia\Reference\Professions;Farmer.xml.backup" "Professions;Farmer.xml"
ren ".\__core__\Ecopedia\Reference\Professions;Profession Overview.xml.backup" "Professions;Profession Overview.xml"

echo Removing Mod Files . . .

del ".\UserCode\AutoGen\Fertilizer\*.override.cs"

del ".\UserCode\AutoGen\Item\AgricultureResearchPaperModern.override.cs"
del ".\UserCode\AutoGen\Item\SoilSampler.override.cs"

del ".\UserCode\AutoGen\PluginModule\FertilizersUpgrade.override.cs"

del ".\UserCode\AutoGen\Recipe\CompostSpoiledFood.override.cs"

del ".\UserCode\AutoGen\Tech\Fertilizers.override.cs"

del ".\UserCode\AutoGen\WorldObject\FarmersTable.override.cs"

del ".\UserCode\Systems\DifficultyBasedRecipeVariants.override.cs"

echo Removing empty folders . . .

type NUL > ".\UserCode\CoFHtmp"

for /f "delims=" %%d in ('dir /s /b /ad ^| sort /r') do 2>NUL rd "%%d"

del ".\UserCode\CoFHtmp"

echo Uninstaller will delete itself on completion (You must press a key). Thank you for using the mod!

pause

del ".\CoFHFarmingFertilizersMergeUninstall.*"

:cancel
