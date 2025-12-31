## Changelog

- v0.6.2 (2025-12-29)
  - Renamed mod to **Config-XML**.
  - Added Japanese (日本語) and Traditional Chinese (繁體中文) translations.
  - Added Italian
  - One-time migration: existing **RealCity Config.xml** is automatically copied to the new **ConfigXML** folder if present.
  - Adds README_Config.txt next to Config.xml (readme is auto-updated when the shipped README changes).
  - Improved Config.xml safety:
    - Creates Config.xml on first run if missing.
    - Automatically repairs missing or empty config files.
    - Stub configs are replaced with a valid default when available.

 
- v0.5.0 (2025-11-23)
  - Complete refactor and rebrand as **City Services Redux**.
  - Updated config and code for game patch **1.4.\***.
  - New Options UI: presets vs custom Config.xml, reset buttons, and verbose logging toggle.
  - Safer Config.xml handling with stub detection and automatic recovery.
  - Added debug helpers (prefab status dump, config dump)
  - multi-language support (EN, DE, FR, ES, PT-BR, ZH-CN).

- v0.4.1 (2024-04-15)
  - Support for fields of type: byte, short, uint.

- v0.4 (2024-04-03)
  - Mod allows now to change almost any parameter of City Services buildings.

- v0.3 (2024-03-27)
  - Mod migrated to PDXMods platform and updated for v1.1.0 of the game.

- v0.2 (2024-03-20)
  - Mod updated for v1.1 of the game.
  
- v0.1 (2024-03-08)
  - Initial build.
