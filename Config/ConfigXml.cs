// Config/ConfigXml.cs
// XML model + load/save helpers for Config-XML.

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
        private static readonly string _dumpFileName = "Config_Dump.xml";

        private const string StubMarker = "CSR-STUB";

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
                // Treat as non-stub if we cannot read it; do not destroy user data.
            }

            return false;
        }

        private static void CreateStubConfig(string configPath)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(configPath)!);
            using (var fs = new FileStream(configPath, FileMode.CreateNew))
            using (var writer = new StreamWriter(fs))
            {
                writer.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                writer.WriteLine("<!-- CSR-STUB: Config.xml temp created because a default config could not be found.");
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

        /// <summary>
        /// Ensure that Config.xml exists in ModsData/ConfigXML.
        /// If missing, try to copy it from the shipped mod folder.
        /// If that also fails, create a stub Config.xml with CSR-STUB marker.
        /// </summary>
        private static void EnsureConfigFileExists(string assetPath)
        {
            var configPath = GetConfigFilePath();

            try
            {
                if (File.Exists(configPath))
                {
                    // If this is a stub and we now have a real shipped config, replace it.
                    var assetDirForStub = GetAssetDirectorySafe(assetPath);
                    if (!string.IsNullOrEmpty(assetDirForStub) && IsStubConfig(configPath))
                    {
                        var shippedPath = Path.Combine(assetDirForStub, _configFileName);
                        if (File.Exists(shippedPath))
                        {
                            Directory.CreateDirectory(Path.GetDirectoryName(configPath)!);
                            File.Copy(shippedPath, configPath, overwrite: true);
                            Mod.s_Log.Info(
                                $"Configuration: replaced stub Config.xml with shipped default at {configPath}.");
                        }
                    }

                    return;
                }

                var assetDir = GetAssetDirectorySafe(assetPath);
                if (!string.IsNullOrEmpty(assetDir))
                {
                    var shippedPath = Path.Combine(assetDir, _configFileName);
                    if (File.Exists(shippedPath))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(configPath)!);
                        File.Copy(shippedPath, configPath, overwrite: false);
                        Mod.s_Log.Info(
                            $"Configuration: copied default Config.xml from {shippedPath} to {configPath}.");
                        return;
                    }
                }

                // If we still don't have a file, create a minimal shell stub.
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
        /// Used by the Options UI button to open the active Config.xml.
        /// Ensures the file exists first.
        /// </summary>
        public static string GetConfigFilePathForUI()
        {
            var assetPath = Mod.modAsset != null ? Mod.modAsset.path : string.Empty;
            EnsureConfigFileExists(assetPath);
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
                else if (Mod.setting != null && Mod.setting.Logging)
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
        /// Ensures the file exists, copying from shipped config or creating a stub if needed.
        /// </summary>
        public static ConfigurationXml? LoadLocalConfig(string assetPath)
        {
            var configPath = GetConfigFilePath();

            try
            {
                EnsureConfigFileExists(assetPath);

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
                else if (Mod.setting != null && Mod.setting.Logging)
                {
                    Mod.s_Log.Info("PREFAB CONFIG DATA (local)");
                    foreach (PrefabXml prefab in _config.Prefabs)
                    {
                        prefab.DumpToLog();
                    }
                }

                // Save a dump copy (for debugging) to Config_Dump.xml in ModsData.
                SaveConfig();

                return _config;
            }
            catch (InvalidOperationException e)
            {
                Mod.s_Log.Warn(
                    $"LoadLocalConfig: Failed to deserialize Config.xml at {configPath}: {e.Message}. " +
                    "The file may be malformed. Use the in-game reset button or delete this file to regenerate it.");
                _config = null;
                return null;
            }
            catch (Exception e)
            {
                Mod.s_Log.Warn(
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

                // Only talk about the dump in the log if verbose logging is enabled.
                if (Mod.setting != null && Mod.setting.Logging)
                {
                    Mod.Log($"Configuration dump saved to {dumpFile}.");
                }
            }
            catch (Exception e)
            {
                // Errors are rare and worth seeing.
                Mod.s_Log.Warn(
                    $"ERROR: Cannot save configuration dump: {e.GetType().Name}: {e.Message}");
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
                        "Please reinstall the mod if problems persist.");
                    return;
                }

                var shippedPath = Path.Combine(assetDir, _configFileName);
                if (!File.Exists(shippedPath))
                {
                    Mod.s_Log.Warn(
                        $"Restore default Config.xml: shipped Config.xml not found at {shippedPath}. " +
                        "Please reinstall the mod.");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(configPath)!);
                File.Copy(shippedPath, configPath, overwrite: true);
                Mod.s_Log.Info($"Restore default Config.xml: copied from {shippedPath} to {configPath}.");
            }
            catch (Exception e)
            {
                Mod.s_Log.Warn(
                    $"Restore default Config.xml failed: {e.GetType().Name}: {e.Message}");
            }
        }
    }
}
