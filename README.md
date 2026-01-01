# Config-XML Mod

- This mod allows for virtually any changes to Service buildings.
- At the moment, it mainly **increases number of workers in City Services buildings** and does other small adjustments (see below for details).
- It does so by changing Prefab parameters during the game start-up, so no changes to game systems are required.
- In the long term this can serve as a foundation for **tuning and balancing any parameter**.
- I encourage contribution to the mod by raising issues and/or PRs on GitHub with proposed changes and rationale behind such changes.

Number of configured buildings and extensions: **222**.


## Features

### Version 0.6
- All buildings have more workplaces and some have changed requirements as for what education levels are required for the jobs.
- There is no formula used, all have been set manually taking into consideration various aspects.
- Some have only slightly more workers, but some have many more. You need to take a look into Config.xml to find out about specific buildings.

### Building configuration
- The configuration is kept in the `Config.xml` file that comes with the mod.
- The file is loaded when the game starts or when you click “APPLY new configuration now” in options.
- For existing buildings, you need to rebuild them to see new values.
- New mod versions should not overwrite your custom Config.xml in ModsData/ConfigXML.
- If you want a clean starting point, use the "Reset new Config.xml" button in options.

### Customizing the parameters
- As for now the mod allows to change any parameter that is stored as either an integer number (so Enums too) or a float number. This covers like 90% of params :)
- It allows to change a singular field in a specific component within a prefab.
- To apply your own changes, you need to know a) prefab's name - almost all are already in the Config.xml, so just find what you need b) component type c) field name and type.

### Turning the mod on/off on existing cities
- Service buildings have some of their params set when plopped (e.g. workplaces). The new params will be applied to new buildings.
- You need to rebuild existing buildings in order to fully apply new params.
- Conversly, when the mod is deactivated, the buildings will retain their modded params. New buildings will have again vanilla params.
- This mod is Safe for city saves and can be removed at any time.

### 11 Languages
* English, Français French, Deutsch German, Español Spanish, Italian
* 简体中文 Simplified Chinese, Português Brazilian, Polski Polish
* 한국어 Korean, 日本語 Japanese, 繁體中文 Traditional Chinese

## Technical
### Requirements and Compatibility
- The mod does NOT modify save files or game systems.

### Known Issues
- Nothing at the moment.

### [Changelog](./CHANGELOG.md)

### Support
- Mod can be installed from [Paradox Mods]("https://mods.paradoxplaza.com/authors/River-mochi/cities_skylines_2?games=cities_skylines_2&orderBy=desc&sortBy=best&time=alltime")
- Please report bugs and issues on [GitHub](https://github.com/River-Mochi/ConfigXML).
- There is also [Paradox Forum](https://forum.paradoxplaza.com/forum/threads/config-xml.1878625/)
- or [Discord](https://discord.gg/HTav7ARPs2)