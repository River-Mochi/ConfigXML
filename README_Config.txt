Config.xml - Service Building Changes

README_Config.txt last update: Dec. 29, 2025
IMPORTANT: Never set workplace counts to 0. Use a small positive value instead (e.g. 1–5).
SHORT GUIDE

======= EASY START =========

1. a. Change m_Workplaces **valueInt** number in any of the buildings below the guide, save the file
1. b. Click [APPLY NEW Configuration] button.
1. c. make new building in game, see more workers at that building

======== More Complex =========
2. a.  if you want to add new/more building types to this file, then follow these instructions.
2. b. Configuration is stored in the hierarchical form: Prefab -> Component -> Field.
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
