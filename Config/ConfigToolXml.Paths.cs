// File: Config/ConfigToolXml.Paths.cs
// Purpose: ConfigXml shared fields + path helpers for Config-XML.

namespace ConfigXML
{
    using System.IO;     // Path, Directory, File
    using UnityEngine;   // Application.persistentDataPath

    public static partial class ConfigToolXml
    {
        // File names
        private static readonly string _configFileName = "Config.xml";
        private static readonly string _dumpFileName = "Config_Dump.xml";   // snapshot
        private static readonly string _readmeFileName = "README_Config.txt";

        // One-time migration from old mod folder.
        private const string OldModId = "RealCity";

        // Stub marker line that makes it safe to detect placeholder configs.
        private const string StubMarker = "CFG-STUB";

        private static ConfigurationXml? _config;

        public static ConfigurationXml? Config => _config;

        // --------------------
        // Path helpers
        // --------------------

        private static string GetConfigDirectory()
        {
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

        // --------------------------------------------
        // Resolved path helpers (match load behavior)
        // --------------------------------------------

        internal static string GetCustomConfigPathResolved(string assetPath)
        {
            EnsureModsDataSeeded(assetPath);
            return GetConfigFilePath();
        }

        // Back-compat name (older code used “local” to mean ModsData CUSTOM).
        internal static string GetLocalConfigPathResolved(string assetPath)
        {
            return GetCustomConfigPathResolved(assetPath);
        }

        internal static string GetPresetConfigPathResolved(string assetPath)
        {
            // Mirrors LoadPresetConfig(): if we can't find shipped, we fall back to CUSTOM.
            var assetDir = GetAssetDirectorySafe(assetPath);
            if (string.IsNullOrEmpty(assetDir))
            {
                return GetCustomConfigPathResolved(assetPath);
            }

            var shippedPath = Path.Combine(assetDir, _configFileName);
            if (!File.Exists(shippedPath))
            {
                return GetCustomConfigPathResolved(assetPath);
            }

            return shippedPath;
        }
    }
}
