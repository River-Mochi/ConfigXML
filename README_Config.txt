Config.xml - Service Building Changes

README_Config.txt last update: Dec. 30, 2025
SHORT GUIDE

======= EASY START =========
1. a. Options UI, select Custom > Open Folder, use Notepad++ app (or similar) to open Config.xml.
1. b. Change m_Workplaces **valueInt** number in any of the buildings in the file (below the guide), save the file and close.
1. b. Back to Options UI in game screen, click [APPLY NEW Configuration] button.
1. d. Done, now any new buildings created in the city of the one you changed will have the new maximum worker value. Old buildings retain the old values.

======== More Complex =========
2. a. IMPORTANT: never set workplace counts to 0. Use a small positive value instead (e.g. 1–5).
2. b. if you want to add new/more building types to this file, then follow these instructions.
2. c. Configuration is stored in the hierarchical form: Prefab -> Component -> Field.
3. PREFABS
   a. You need to provide Prefab's name (e.g. ElementarySchool01) and type (e.g. BuildingPrefab).
   b. Config-XML does NOT support ResourcePrefab and CompanyPrefab - please use RealEco if you want to modify them.
4. COMPONENTS
   a. You need to know Component's type (e.g. Workplace, School, PostFacility).
5. FIELDS
   a. You need to know the Field's name (e.g. m_Workplaces) and type (enum, int, float).
   b. ValueInt must be defined for int fields and enum fields.
   c. ValueFloat must be defined for float fields.
6. IMPORTANT
   a. Do NOT modify fields that hold other data types, arrays, references, etc. This may crash the game.
   b. Use local Config.xml for your own parameters.
   c. Enable Detailed logging if you want to see a very detailed log of what the mod is doing.
   d. Otherwise, LEAVE Debug Verbose logging DISABLED, OFF - long logs HURT performance.

7. Examples below, e.g., can change HighSchool01 from 30 to 50 employees. All new high schools will have higher maximum workers.
   a. Options Settings: "APPLY" must be clicked for file changes to be updated and applied.
   b. Only new buildings get the new employee numbers, you have to delete/remake old buildings for the change.
   c. If you mess up and want an all new Config.xml, use the "Reset New" button.
8. Config_Dump.xml is just a clean, serialized copy of whatever the mod successfully loaded
   a. Don't worry about this file, it's auto generated from Config.xml.
9. This Mod focuses on safely changing the **number of Workers** at all Service buildings.
   a. Use other mods if you want to change other things about Service buildings.
   b. Game will automatically scale the wages with the change of workers.
   c. Use this for worker numbers but use "Adjust School Capacity", "Adjust Transit Capacity", to adjust number of students/passengers/vehicles per building.
   d. "Magic Garbage Truck" mod is better to adjust how much garbage each truck can carry because it also handles the unload speed.
   e. Increase mail workers here, but use "Magic Mail" mod to adjust everything else about Post Offices.

====== Patch Notes and Education Complexity ======
- WorkPlace m_Complexity valueInt is type of education level mix the building requires.
   - Workplace Complexity: only main building matters :( extensions just add new workers but their Complexity is ignored :( -->
- Note: Patch 1.1.10f1 - 2024-10-24 Workplace component has new "m_MinimumWorkersLimit" property. All of these start at minimum 15
  - College01, ElementarySchool01, ElementarySchool02, ElementarySchool03, HighSchool01, HighSchool02, HighSchool03, MedicalUniversity01, TechnicalUniversity01, University01
- Experiment with job education levels or worker numbers carefully :) at worst you can use the reset button to make fresh new copy of this file

====== Migration Notes ==========
Old "RealCity" Settings file: recommended to delete with game OFF: ..\ModsSettings\RealCity
Full path usually here: C:\Users\YourName\AppData\LocalLow\Colossal Order\Cities Skylines II\ModsSettings\RealCity\
When you start the game again, go to Options and you can reset the Checkbox [x] and it will be saved to the new settings location.

Old "RealCity" Config.xml: this is the important file,
a. By default, the Mod will look for the old folder \RealCity and copy (\ModsData\RealCity\Config.xml) into the new location for your convenience (..\ModsData\ConfigXML\Config.xml).
b. If you customized the old one, then you could keep this older \RealCity file as a backup copy or delete the RealCity folder and config.xml.
c. If you never customized it, then it's fine to delete \RealCity and just use the new Config.xml that comes with Presets when the Mod is installed.
d: Full path of old file:  \Users\YourName\AppData\LocalLow\Colossal Order\Cities Skylines II\ModsData\RealCity\Config.xml
e. Copy your old building changes directly into the new ModsData\ConfigXML\Config.xml 
f. Or copy your entire old file to  "..\ModsData\ConfigXML\" 
    - however if you do this you might miss out on any extra buildings or options added to the newest Mod updated Config file.
    - Use Reset button in Options if you ever want a new Config.xml file based on the newest version released.
