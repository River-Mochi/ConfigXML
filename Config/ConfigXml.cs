// File: Config/ConfigXml.cs
// Purpose: XML model + load/save helpers for Config-XML.

namespace ConfigXML
{
    using System;                     // Exception
    using System.Collections.Generic; // List<T>
    using System.IO;                  // Path, File, Directory, FileStream
    using System.Reflection;          // Assembly
    using System.Xml.Serialization;   // XmlSerializer, Xml* attributes
    using UnityEngine;                // Application.persistentDataPath

    [XmlRoot("Configuration")]
    public class ConfigurationXml
    {
        [XmlElement("Prefab")]
        public List<PrefabXml> Prefabs
        {
            get; set;
        } = new List<PrefabXml>();

        public bool TryGetPrefab(string name, out PrefabXml prefab)
        {
            prefab = default!;
            foreach (PrefabXml item in Prefabs)
            {
                if (item.Name == name)
                {
                    prefab = item;
                    return true;
                }
            }

            return false;
        }
    }

    public class PrefabXml
    {
        [XmlAttribute("type")]
        public string Type
        {
            get; set;
        } = string.Empty;

        [XmlAttribute("name")]
        public string Name
        {
            get; set;
        } = string.Empty;

        [XmlElement("Component")]
        public List<ComponentXml> Components
        {
            get; set;
        } = new List<ComponentXml>();

        public override string ToString()
        {
            return $"PrefabXml: {Type}.{Name}";
        }

        public void DumpToLog()
        {
            Mod.s_Log.Info(ToString());
            foreach (ComponentXml component in Components)
            {
                component.DumpToLog();
            }
        }

        internal bool TryGetComponent(string name, out ComponentXml component)
        {
            component = default!;
            foreach (ComponentXml item in Components)
            {
                if (item.Name == name)
                {
                    component = item;
                    return true;
                }
            }

            return false;
        }
    }

    public class ComponentXml
    {
        [XmlAttribute("name")]
        public string Name
        {
            get; set;
        } = string.Empty;

        [XmlElement("Field")]
        public List<FieldXml> Fields
        {
            get; set;
        } = new List<FieldXml>();

        public override string ToString()
        {
            return $"ComponentXml: {Name}";
        }

        public void DumpToLog()
        {
            Mod.s_Log.Info(ToString());
            foreach (FieldXml field in Fields)
            {
                Mod.s_Log.Info(field.ToString());
            }
        }

        internal bool TryGetField(string name, out FieldXml field)
        {
            field = default!;
            foreach (FieldXml item in Fields)
            {
                if (item.Name == name)
                {
                    field = item;
                    return true;
                }
            }

            return false;
        }
    }

    public class FieldXml
    {
        [XmlAttribute("name")]
        public string Name
        {
            get; set;
        } = string.Empty;

        // STRING is the default value.
        [XmlAttribute(AttributeName = "value", DataType = "string")]
        public string Value
        {
            get; set;
        } = string.Empty;

        // INTEGER

        [XmlIgnore]
        public bool ValueIntSpecified
        {
            get; set;
        }

        [XmlIgnore]
        public int? ValueInt
        {
            get; set;
        }

        [XmlAttribute("valueInt")]
        public int XmlValueInt
        {
            get => ValueInt.GetValueOrDefault();
            set
            {
                ValueInt = value;
                ValueIntSpecified = true;
            }
        }

        // FLOAT

        [XmlIgnore]
        public bool ValueFloatSpecified
        {
            get; set;
        }

        [XmlIgnore]
        public float? ValueFloat
        {
            get; set;
        }

        [XmlAttribute(AttributeName = "valueFloat", DataType = "float")]
        public float XmlValueFloat
        {
            get => ValueFloat.GetValueOrDefault();
            set
            {
                ValueFloat = value;
                ValueFloatSpecified = true;
            }
        }

        public override string ToString()
        {
            var res = $"{Name}=";
            if (ValueInt.HasValue)
            {
                res += $" {ValueInt} (int)";
            }

            if (ValueFloat.HasValue)
            {
                res += $" {ValueFloat} (float)";
            }

            if (!string.IsNullOrEmpty(Value))
            {
                res += $" {Value}";
            }

            return res;
        }
    }

    public static class ConfigToolXml
    {
        private static readonly string _configFileName = "Config.xml";
        private static readonly string _dumpFileName = "Config_Dump.xml";   // snapshot

        // README lives next to Config.xml in ModsData/ConfigXML/
        private static readonly string _readmeFileName = "README_Config.txt";

        // One-time migration from old mod folder.
        private const string OldModId = "RealCity";

        private const string StubMarker = "CFG-STUB";

        private static ConfigurationXml? _config;

        public static ConfigurationXml? Config => _config;

        // --------------------
        // Path helpers
        // --------------------

        private static string GetConfigDirectory()
        {
            // Equivalent to EnvPath.kUserDataPath but without needing Colossal.PSI:
            //   C:\Users\<user>\AppData\LocalLow\Colossal Order\Cities Skylines II
            var root = Application.persistentDataPath;
            var dir = Path.Combine(root, "ModsData", Mod.ModId);
            Directory.CreateDirectory(dir);
            return dir;
        }

        internal static string GetConfigFilePath()
        {
            var dir = GetConfigDirectory();
            return Path.Combine(dir, _configFileName);
        }

        private static string GetOldConfigFilePath()
        {
            var root = Application.persistentDataPath;
            return Path.Combine(root, "ModsData", OldModId, _configFileName);
        }

        private static string GetReadmeFilePath()
        {
            var dir = GetConfigDirectory();
            return Path.Combine(dir, _readmeFileName);
        }

        private static string GetConfigDumpFilePath()
        {
            var dir = GetConfigDirectory();
            return Path.Combine(dir, _dumpFileName);
        }

        private static string? GetAssetDirectorySafe(string assetPath)
        {
            var basePath = assetPath;

            if (string.IsNullOrEmpty(basePath))
            {
                try
                {
                    basePath = Assembly.GetExecutingAssembly().Location;
                }
                catch (Exception)
                {
                    basePath = string.Empty;
                }
            }

            if (string.IsNullOrEmpty(basePath))
            {
                return null;
            }

            var assetDir = Path.GetDirectoryName(basePath);
            return assetDir;
        }

        private static bool IsStubConfig(string path)
        {
            try
            {
                if (!File.Exists(path))
                {
                    return false;
                }

                using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (var reader = new StreamReader(fs))
                {
                    for (var i = 0; i < 5 && !reader.EndOfStream; i++)
                    {
                        var line = reader.ReadLine();
                        if (line != null &&
                            line.IndexOf(StubMarker, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception)
            {
                // Treat as non-stub if it can't be read; do not destroy user data.
            }

            return false;
        }

        private static bool IsFileEmptyOrWhitespace(string path)
        {
            try
            {
                if (!File.Exists(path))
                {
                    return false;
                }

                using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (var reader = new StreamReader(fs))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            return false;
                        }
                    }
                }

                return true;
            }
            catch
            {
                // Do NOT assume it's empty if it can not be read.
                return false;
            }
        }

        private static void CreateStubConfig(string configPath)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(configPath)!);
            using (var fs = new FileStream(configPath, FileMode.CreateNew))
            using (var writer = new StreamWriter(fs))
            {
                writer.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                writer.WriteLine("<!-- CFG-STUB: Config.xml temp created because a default config could not be found.");
                writer.WriteLine("     The mod will not change any buildings while this temp stub is active.");
                writer.WriteLine("     Reinstall the mod or use the in-game reset button to get a real working Config.xml. -->");
                writer.WriteLine("<Configuration>");
                writer.WriteLine("  <!-- No prefabs defined. This stub is safe but does nothing. -->");
                writer.WriteLine("</Configuration>");
            }

            Mod.s_Log.Warn(
                $"Configuration: created temp stub Config.xml at {configPath}. " +
                "The mod will not apply any changes until a real config file is restored.");
        }

        private static void EnsureReadmeExists(string assetPath, bool overwriteIfDifferent)
        {
            var readmePath = GetReadmeFilePath();

            try
            {
                var assetDir = GetAssetDirectorySafe(assetPath);
                var shippedReadme = !string.IsNullOrEmpty(assetDir)
                    ? Path.Combine(assetDir, _readmeFileName)
                    : null;

                Directory.CreateDirectory(Path.GetDirectoryName(readmePath)!);

                // If missing: create from shipped, else small fallback.
                if (!File.Exists(readmePath))
                {
                    if (!string.IsNullOrEmpty(shippedReadme) && File.Exists(shippedReadme))
                    {
                        File.Copy(shippedReadme, readmePath, overwrite: false);
                    }
                    else
                    {
                        File.WriteAllText(
                            readmePath,
                            "Config-XML README\r\n\r\n" +
                            "This folder contains Config.xml for custom service building tweaks.\r\n" +
                            "Edit Config.xml and use APPLY in Options to reload.\r\n");
                    }

                    return;
                }

                // If shipped README can not be located, nothing to compare/update.
                if (!overwriteIfDifferent || string.IsNullOrEmpty(shippedReadme) || !File.Exists(shippedReadme))
                {
                    return;
                }

                // Compare contents; only write if actually different.
                // README is small, a full read is fine and avoids repeated writes.
                string shippedText;
                string existingText;

                try
                {
                    shippedText = File.ReadAllText(shippedReadme);
                    existingText = File.ReadAllText(readmePath);
                }
                catch
                {
                    // If reading fails for any reason, do not overwrite user file.
                    return;
                }

                if (!string.Equals(existingText, shippedText, StringComparison.Ordinal))
                {
                    File.WriteAllText(readmePath, shippedText);
                    Mod.s_Log.Info($"{Mod.ModTag} README updated: {readmePath}");
                }
            }
            catch (Exception e)
            {
                Mod.s_Log.Warn($"EnsureReadmeExists failed: {e.GetType().Name}: {e.Message}");
            }
        }

        /// <summary>
        /// Ensure that Config.xml exists in ModsData/ConfigXML.
        /// Migration rules:
        /// - If ConfigXML/Config.xml exists:
        ///     - If it's a stub and shipped config exists => replace stub.
        ///     - If it's empty/whitespace and shipped config exists => replace empty file.
        /// - Else if old RealCity/Config.xml exists => copy old as-is to new location.
        /// - Else if shipped Config.xml exists => copy shipped.
        /// - Else create stub.
        /// </summary>
        private static void EnsureConfigFileExists(string assetPath)
        {
            var configPath = GetConfigFilePath();

            try
            {
                var assetDir = GetAssetDirectorySafe(assetPath);
                var shippedPath = !string.IsNullOrEmpty(assetDir)
                    ? Path.Combine(assetDir, _configFileName)
                    : null;

                if (File.Exists(configPath))
                {
                    // If stub and shipped exists, replace.
                    if (!string.IsNullOrEmpty(shippedPath) && File.Exists(shippedPath) && IsStubConfig(configPath))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(configPath)!);
                        File.Copy(shippedPath, configPath, overwrite: true);
                        Mod.s_Log.Info(
                            $"Configuration: replaced stub Config.xml with shipped default at {configPath}.");
                    }

                    // If file exists but is empty/whitespace, replace with shipped default (safe repair).
                    if (!string.IsNullOrEmpty(shippedPath) && File.Exists(shippedPath) && IsFileEmptyOrWhitespace(configPath))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(configPath)!);
                        File.Copy(shippedPath, configPath, overwrite: true);
                        Mod.s_Log.Warn(
                            $"Configuration: replaced empty Config.xml with shipped default at {configPath}.");
                    }

                    return;
                }

                // One-time migration: old RealCity config -> new ConfigXML location (as-is).
                var oldPath = GetOldConfigFilePath();
                if (File.Exists(oldPath))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(configPath)!);
                    File.Copy(oldPath, configPath, overwrite: false);
                    Mod.s_Log.Info($"Configuration: migrated old Config.xml\n from {oldPath}\n to {configPath}.");
                    return;
                }

                // Copy shipped default if available.
                if (!string.IsNullOrEmpty(shippedPath) && File.Exists(shippedPath))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(configPath)!);
                    File.Copy(shippedPath, configPath, overwrite: false);
                    Mod.s_Log.Info(
                        $"Configuration: copied default Config.xml from {shippedPath} to {configPath}.");
                    return;
                }

                // If a file is still not available, create a minimal shell stub for safety.
                if (!File.Exists(configPath))
                {
                    CreateStubConfig(configPath);
                }
            }
            catch (Exception e)
            {
                Mod.s_Log.Warn($"EnsureConfigFileExists failed: {e.GetType().Name}: {e.Message}");
            }
        }

        /// <summary>
        /// Ensure ModsData/ConfigXML contains Config.xml and README.
        /// Call on startup if the folder should be present even for preset-only players.
        /// </summary>
        public static void EnsureModsDataSeeded(string assetPath)
        {
            EnsureConfigFileExists(assetPath);

            // Ensure README exists; update only if shipped README content has changed.
            EnsureReadmeExists(assetPath, overwriteIfDifferent: true);
        }

        /// <summary>
        /// Used by the Options UI button to open the active Config.xml.
        /// Ensures the file exists first (and README is present/up-to-date).
        /// </summary>
        public static string GetConfigFilePathForUI()
        {
            var assetPath = Mod.modAsset != null ? Mod.modAsset.path : string.Empty;
            EnsureModsDataSeeded(assetPath);
            return GetConfigFilePath();
        }

        /// <summary>
        /// Loads prefab config data from the shipped Config.xml next to the mod DLL.
        /// Falls back to local Config.xml if needed.
        /// </summary>
        public static ConfigurationXml? LoadPresetConfig(string assetPath)
        {
            try
            {
                var assetDir = GetAssetDirectorySafe(assetPath);
                if (string.IsNullOrEmpty(assetDir))
                {
                    Mod.s_Log.Warn("LoadPresetConfig: Could not determine mod folder; falling back to local Config.xml.");
                    return LoadLocalConfig(assetPath);
                }

                var shippedPath = Path.Combine(assetDir, _configFileName);
                if (!File.Exists(shippedPath))
                {
                    Mod.s_Log.Warn(
                        $"LoadPresetConfig: Shipped Config.xml not found at {shippedPath}; falling back to local Config.xml.");
                    return LoadLocalConfig(assetPath);
                }

                var serializer = new XmlSerializer(typeof(ConfigurationXml));
                using (var fs = new FileStream(shippedPath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    _config = (ConfigurationXml)serializer.Deserialize(fs);
                }

                if (_config == null || _config.Prefabs == null || _config.Prefabs.Count == 0)
                {
                    Mod.s_Log.Warn(
                        $"LoadPresetConfig: Configuration loaded from {shippedPath} but Prefabs list is empty; nothing to apply.");
                }
                else if (Mod.setting != null && Mod.setting.VerboseLogs)
                {
                    Mod.s_Log.Info("PREFAB CONFIG DATA (preset)");
                    foreach (PrefabXml prefab in _config.Prefabs)
                    {
                        prefab.DumpToLog();
                    }
                }

                return _config;
            }
            catch (Exception e)
            {
                Mod.s_Log.Warn(
                    $"LoadPresetConfig: failed to load configuration: {e.GetType().Name}: {e.Message}");
                _config = null;
                return null;
            }
        }

        /// <summary>
        /// Loads prefab config data from ModsData/ConfigXML/Config.xml (local custom file).
        /// Ensures the file exists, migrating from old RealCity config, copying shipped config,
        /// or creating a stub if needed.
        /// </summary>
        public static ConfigurationXml? LoadLocalConfig(string assetPath)
        {
            var configPath = GetConfigFilePath();

            try
            {
                EnsureModsDataSeeded(assetPath);

                if (!File.Exists(configPath))
                {
                    Mod.s_Log.Warn(
                        $"LoadLocalConfig: Configuration file not found at {configPath}; no configuration will be applied.");
                    _config = null;
                    return null;
                }

                var serializer = new XmlSerializer(typeof(ConfigurationXml));
                using (var fs = new FileStream(configPath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    _config = (ConfigurationXml)serializer.Deserialize(fs);
                }

                if (_config == null || _config.Prefabs == null || _config.Prefabs.Count == 0)
                {
                    Mod.s_Log.Warn("LoadLocalConfig: Configuration loaded but Prefabs list is empty; nothing to apply.");
                }
                else if (Mod.setting != null && Mod.setting.VerboseLogs)
                {
                    Mod.s_Log.Info("PREFAB CONFIG DATA (local)");
                    foreach (PrefabXml prefab in _config.Prefabs)
                    {
                        prefab.DumpToLog();
                    }
                }

                // Save a dump copy (for debugging) to Config_Dump.xml in ModsData.
                SaveConfig(); // Snapshot confirms the serializer output matches expected.

                return _config;
            }
            catch (InvalidOperationException e)
            {
                Mod.Warn(
                    $"LoadLocalConfig: Failed to deserialize Config.xml at {configPath}: {e.Message}. " +
                    "The file may be malformed. Use the in-game reset button or delete this file to regenerate it.");
                _config = null;
                return null;
            }
            catch (Exception e)
            {
                Mod.Warn(
                    $"LoadLocalConfig: Cannot load configuration, exception {e.GetType().Name}: {e.Message}");
                _config = null;
                return null;
            }
        }

        /// <summary>
        /// Saves a dump copy of the currently loaded configuration to Config_Dump.xml in ModsData.
        /// </summary>
        public static void SaveConfig()
        {
            try
            {
                if (_config == null)
                {
                    return;
                }

                var dumpFile = GetConfigDumpFilePath();
                var serializer = new XmlSerializer(typeof(ConfigurationXml));
                using (var fs = new FileStream(dumpFile, FileMode.Create))
                {
                    serializer.Serialize(fs, _config);
                }

                if (Mod.setting != null && Mod.setting.VerboseLogs) // note in Verbose Logs only.
                {
                    Mod.Log($"Configuration dump saved to {dumpFile}.");
                }
            }
            catch (Exception e)
            {
                // Errors are rare and worth seeing.
                Mod.s_Log.Warn(
                    $"ERROR: Cannot save Config_dump: {e.GetType().Name}: {e.Message}");
            }
        }

        /// <summary>
        /// Overwrite ModsData/ConfigXML/Config.xml with the shipped Config.xml next to the DLL, if available.
        /// Used by the in-game reset buttons.
        /// </summary>
        public static void RestoreDefaultConfigForUI(string assetPath)
        {
            try
            {
                var configPath = GetConfigFilePath();
                var assetDir = GetAssetDirectorySafe(assetPath);

                if (string.IsNullOrEmpty(assetDir))
                {
                    Mod.s_Log.Warn(
                        "Restore default Config.xml: could not determine mod folder. " +
                        "Please Reinstall the mod if problems persist.");
                    return;
                }

                var shippedPath = Path.Combine(assetDir, _configFileName);
                if (!File.Exists(shippedPath))
                {
                    Mod.Warn(
                        $"Restore default Config.xml: shipped Config.xml not found at\n{shippedPath}\n" +
                        $"Please Reinstall {Mod.ModId}.");

                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(configPath)!);
                File.Copy(shippedPath, configPath, overwrite: true);
                Mod.s_Log.Info($"Restore Default Config.xml: copied from\n {shippedPath}\n to {configPath}.");

                // Also refresh README on reset (keeps docs up-to-date).
                EnsureReadmeExists(assetPath, overwriteIfDifferent: true);
            }
            catch (Exception e)
            {
                Mod.s_Log.Warn(
                    $"Restore Default Config.xml Failed: {e.GetType().Name}: {e.Message}");
            }
        }
    }
}
