// File: Config/ConfigToolXml.IO.cs
// Purpose: ConfigToolXml IO + migration + load/save helpers for Config-XML.
// Notes:
// - Do not dump the entire config (all prefabs/components/fields) to the logger on load.

namespace ConfigXML
{
    using System;                   // Exception, InvalidOperationException, StringComparison
    using System.IO;                // Path, File, Directory, FileStream
    using System.Reflection;        // Assembly
    using System.Xml.Serialization; // XmlSerializer

    public static partial class ConfigToolXml
    {
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

            return Path.GetDirectoryName(basePath);
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

            Mod.Warn(
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

                if (!overwriteIfDifferent || string.IsNullOrEmpty(shippedReadme) || !File.Exists(shippedReadme))
                {
                    return;
                }

                string shippedText;
                string existingText;

                try
                {
                    shippedText = File.ReadAllText(shippedReadme);
                    existingText = File.ReadAllText(readmePath);
                }
                catch
                {
                    return;
                }

                if (!string.Equals(existingText, shippedText, StringComparison.Ordinal))
                {
                    File.WriteAllText(readmePath, shippedText);
                    Mod.Log($"{Mod.ModTag} README updated: {readmePath}");
                }
            }
            catch (Exception e)
            {
                Mod.Warn($"EnsureReadmeExists failed: {e.GetType().Name}: {e.Message}");
            }
        }

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
                    if (!string.IsNullOrEmpty(shippedPath) && File.Exists(shippedPath) && IsStubConfig(configPath))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(configPath)!);
                        File.Copy(shippedPath, configPath, overwrite: true);
                        Mod.Log($"Configuration: replaced stub Config.xml with shipped default at {configPath}.");
                    }

                    if (!string.IsNullOrEmpty(shippedPath) && File.Exists(shippedPath) && IsFileEmptyOrWhitespace(configPath))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(configPath)!);
                        File.Copy(shippedPath, configPath, overwrite: true);
                        Mod.Warn($"Configuration: replaced empty Config.xml with shipped default at {configPath}.");
                    }

                    return;
                }

                var oldPath = GetOldConfigFilePath();
                if (File.Exists(oldPath))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(configPath)!);
                    File.Copy(oldPath, configPath, overwrite: false);
                    Mod.Log($"{Mod.ModTag} Migrated old Config.xml\nfrom {oldPath}\nto {configPath}.");
                    return;
                }

                if (!string.IsNullOrEmpty(shippedPath) && File.Exists(shippedPath))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(configPath)!);
                    File.Copy(shippedPath, configPath, overwrite: false);
                    Mod.Log($"Configuration: copied default Config.xml from {shippedPath} to {configPath}.");
                    return;
                }

                if (!File.Exists(configPath))
                {
                    CreateStubConfig(configPath);
                }
            }
            catch (Exception e)
            {
                Mod.Warn($"EnsureConfigFileExists failed: {e.GetType().Name}: {e.Message}");
            }
        }

        public static void EnsureModsDataSeeded(string assetPath)
        {
            EnsureConfigFileExists(assetPath);
            EnsureReadmeExists(assetPath, overwriteIfDifferent: true);
        }

        public static string GetConfigFilePathForUI()
        {
            var assetPath = Mod.modAsset != null ? Mod.modAsset.path : string.Empty;
            EnsureModsDataSeeded(assetPath);
            return GetConfigFilePath();
        }

        public static ConfigurationXml? LoadPresetConfig(string assetPath)
        {
            try
            {
                var assetDir = GetAssetDirectorySafe(assetPath);
                if (string.IsNullOrEmpty(assetDir))
                {
                    Mod.Warn("LoadPresetConfig: could not determine mod folder; falling back to local Config.xml.");
                    return LoadLocalConfig(assetPath);
                }

                var shippedPath = Path.Combine(assetDir, _configFileName);
                if (!File.Exists(shippedPath))
                {
                    Mod.Warn($"LoadPresetConfig: shipped Config.xml not found at {shippedPath}; falling back to local Config.xml.");
                    return LoadLocalConfig(assetPath);
                }

                var serializer = new XmlSerializer(typeof(ConfigurationXml));
                using (var fs = new FileStream(shippedPath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    _config = (ConfigurationXml)serializer.Deserialize(fs);
                }

                if (_config == null || _config.Prefabs == null || _config.Prefabs.Count == 0)
                {
                    Mod.Warn($"LoadPresetConfig: configuration loaded from {shippedPath} but Prefabs list is empty; nothing to apply.");
                }

                return _config;
            }
            catch (Exception e)
            {
                Mod.Warn($"LoadPresetConfig: failed to load configuration: {e.GetType().Name}: {e.Message}");
                _config = null;
                return null;
            }
        }

        public static ConfigurationXml? LoadLocalConfig(string assetPath)
        {
            var configPath = GetConfigFilePath();

            try
            {
                EnsureModsDataSeeded(assetPath);

                if (!File.Exists(configPath))
                {
                    Mod.Warn($"LoadLocalConfig: configuration file not found at {configPath}; no configuration will be applied.");
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
                    Mod.Warn("LoadLocalConfig: configuration loaded but Prefabs list is empty; nothing to apply.");
                }

                SaveConfig(); // keep dump snapshot, but do not log it

                return _config;
            }
            catch (InvalidOperationException e)
            {
                Mod.Warn(
                    $"LoadLocalConfig: failed to deserialize Config.xml at {configPath}: {e.Message}. " +
                    "File may be malformed. Options:\n" +
                    "1) Use the mod Reset Default button\n" +
                    "2) Delete this Config.xml to regenerate on next start\n" +
                    "3) Reinstall the mod.");
                _config = null;
                return null;
            }
            catch (Exception e)
            {
                Mod.Warn($"LoadLocalConfig: cannot load configuration: {e.GetType().Name}: {e.Message}");
                _config = null;
                return null;
            }
        }

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
            }
            catch (Exception e)
            {
                Mod.Warn($"ERROR: cannot save Config_Dump.xml: {e.GetType().Name}: {e.Message}");
            }
        }

        public static void RestoreDefaultConfigForUI(string assetPath)
        {
            try
            {
                var configPath = GetConfigFilePath();
                var assetDir = GetAssetDirectorySafe(assetPath);

                if (string.IsNullOrEmpty(assetDir))
                {
                    Mod.Warn(
                        "Restore default Config.xml: could not determine mod folder. " +
                        "Please reinstall the mod if problems persist.");
                    return;
                }

                var shippedPath = Path.Combine(assetDir, _configFileName);
                if (!File.Exists(shippedPath))
                {
                    Mod.Warn(
                        $"Restore default Config.xml: shipped Config.xml not found at\n{shippedPath}\n" +
                        $"Please reinstall {Mod.ModId}.");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(configPath)!);
                File.Copy(shippedPath, configPath, overwrite: true);
                Mod.Log($"Restore Default Config.xml: copied\nfrom {shippedPath}\nto {configPath}.");

                EnsureReadmeExists(assetPath, overwriteIfDifferent: true);
            }
            catch (Exception e)
            {
                Mod.Warn($"Restore Default Config.xml failed: {e.GetType().Name}: {e.Message}");
            }
        }
    }
}
