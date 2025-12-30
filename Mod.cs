// File: Mod.cs
// Purpose: Entry point for ConfigXML [CFG].

namespace ConfigXML
{
    using Colossal;                      // IDictionarySource
    using Colossal.IO.AssetDatabase;     // AssetDatabase.LoadSettings
    using Colossal.Localization;         // LocalizationManager
    using Colossal.Logging;              // ILog, LogManager
    using Game;                          // UpdateSystem
    using Game.Modding;                  // IMod
    using Game.SceneFlow;                // GameManager, ExecutableAsset
    using System;
    using System.Reflection;

    public sealed class Mod : IMod
    {
        // ---- PUBLIC CONSTANTS / METADATA ----

        public const string ModId = "ConfigXML";
        public const string ModName = "Config-XML";
        public const string ModTag = "[CFG]";

        /// <summary>
        /// Read Version number from assembly (3-part).
        /// </summary>
        public static readonly string ModVersion =
            Assembly.GetExecutingAssembly().GetName().Version?.ToString(3) ?? "1.0.0";

        /// <summary>
        /// Single shared logger for this mod
        /// </summary>
        public static readonly ILog s_Log =
            LogManager.GetLogger(ModId).SetShowsErrorsInUI(false);

        /// <summary>
        /// Mod instance
        /// </summary>
        public static Mod instance
        {
            get;
            private set;
        } = null!;

        /// <summary>
        /// Executable asset for this mod (needed for Config.xml seeding path).
        /// </summary>
        public static ExecutableAsset modAsset
        {
            get;
            private set;
        } = null!;

        /// <summary>
        /// Global settings instance
        /// </summary>
        public static Setting setting
        {
            get;
            private set;
        } = null!;

        // ---- PRIVATE STATE ----

        private static bool s_BannerLogged;

        // --------------------------------------------------------------------
        // IMod
        // --------------------------------------------------------------------

        public void OnLoad(UpdateSystem updateSystem)
        {
            instance = this;

            // One-time log banner
            if (!s_BannerLogged)
            {
                s_BannerLogged = true;
                s_Log.Info($"{ModName} {ModTag} v{ModVersion} OnLoad");
            }

            GameManager? gameManager = GameManager.instance;
            if (gameManager == null)
            {
                s_Log.Error("GameManager.instance is null in Mod.OnLoad.");
                return;
            }

            // Resolve ExecutableAsset (needed so ConfigTool knows the mod path).
            if (gameManager.modManager.TryGetExecutableAsset(this, out ExecutableAsset asset))
            {
#if DEBUG
                s_Log.Info($"{asset.name} v{asset.version} mod asset at {asset.path}"); // Full path to DLL
#endif
                modAsset = asset;
            }
            else
            {
                s_Log.Warn("Failed to resolve mod ExecutableAsset; Config.xml seeding may be skipped.");
            }

            // Settings must exist before locales so labels resolve correctly.
            Setting s = new Setting(this);
            setting = s;

            // Register locales
            AddLocaleSource("en-US", new LocaleEN(s));

            // Ready for future locales
            AddLocaleSource("de-DE", new LocaleDE(s));
            AddLocaleSource("es-ES", new LocaleES(s));
            AddLocaleSource("fr-FR", new LocaleFR(s));
            // AddLocaleSource("it-IT",    new LocaleIT(s));
            AddLocaleSource("ja-JP", new LocaleJA(s));
            AddLocaleSource("ko-KR", new LocaleKO(s));
            AddLocaleSource("pl-PL", new LocalePL(s));
            AddLocaleSource("pt-BR", new LocalePT_BR(s));
            AddLocaleSource("zh-HANS", new LocaleZH_CN(s));
            AddLocaleSource("zh-HANT", new LocaleZH_HANT(s));
            // AddLocaleSource("vi-VN", new LocaleVI(settings));

            // Load persisted settings or create defaults on first run.
            AssetDatabase.global.LoadSettings("ConfigSettings", s, new Setting(this));

            // Register in Options UI.
            s.RegisterInOptionsUI();

            // Ensure the settings asset is actually written.
            s._Hidden = false;

            // Seed ModsData/ConfigXML/ (Config.xml + README) even for preset-only players.
            // - Migrates old RealCity config if needed
            // - Repairs stub/empty config if needed
            // - Refreshes README each update
            try
            {
                var assetPath = modAsset != null ? modAsset.path : string.Empty;
                ConfigToolXml.EnsureModsDataSeeded(assetPath);
            }
            catch (Exception ex)
            {
                s_Log.Warn($"EnsureModsDataSeeded failed: {ex.GetType().Name}: {ex.Message}");
            }

            // Read and apply prefab configuration.
            ConfigTool.ReadAndApply();
        }

        public void OnDispose()
        {
            s_Log.Info(nameof(OnDispose));

            if (setting != null)
            {
                setting.UnregisterInOptionsUI();
                setting = null!;
            }
        }

        // --------------------------------------------------------------------
        // Debug helper
        // --------------------------------------------------------------------

        public static void DumpObjectData(object objectToDump)
        {
            if (objectToDump == null)
            {
                SafeLogInfo("Object: <null>");
                return;
            }

            SafeLogInfo("Object: " + objectToDump);

            Type type = objectToDump.GetType();

            FieldInfo[] fields = type.GetFields(
                BindingFlags.Public
                | BindingFlags.NonPublic
                | BindingFlags.Instance);

            foreach (FieldInfo field in fields)
            {
                SafeLogInfo(" " + field.Name + ": " + field.GetValue(objectToDump));
            }

            PropertyInfo[] properties = type.GetProperties(
                BindingFlags.Public
                | BindingFlags.NonPublic
                | BindingFlags.Instance);

            foreach (PropertyInfo property in properties)
            {
                SafeLogInfo(" " + property.Name + ": " + property.GetValue(objectToDump));
            }
        }

        // --------------------------------------------------------------------
        // Logging helpers – protect against logging-related exceptions.
        // --------------------------------------------------------------------

        /// <summary>
        /// Always log (Info). For important messages.
        /// </summary>
        public static void Log(string message)
        {
            SafeLogInfo(message);
        }

        /// <summary>
        /// Verbose logging: only logs when the in-game checkbox is enabled.
        /// </summary>
        public static void LogIf(string message)
        {
            if (setting == null || !setting.Logging)
            {
                return;
            }

            SafeLogInfo(message);
        }

        private static void SafeLogInfo(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                return;
            }

            try
            {
                s_Log.Info(message);
            }
            catch (Exception)
            {
                // Swallow logging failures so they never surface to the player.
            }
        }

        // --------------------------------------------------------------------
        // Localization helper
        // --------------------------------------------------------------------

        /// <summary>
        /// Wrapper around LocalizationManager.AddSource that catches exceptions
        /// so localization issues can't crash the mod.
        /// </summary>
        private static void AddLocaleSource(string localeId, IDictionarySource source)
        {
            if (string.IsNullOrEmpty(localeId))
            {
                return;
            }

            LocalizationManager? lm = GameManager.instance?.localizationManager;
            if (lm == null)
            {
                s_Log.Warn($"AddLocaleSource: No LocalizationManager; cannot add source for '{localeId}'.");
                return;
            }

            try
            {
                lm.AddSource(localeId, source);
            }
            catch (Exception ex)
            {
                s_Log.Warn(
                    $"AddLocaleSource: AddSource for '{localeId}' failed: {ex.GetType().Name}: {ex.Message}");
            }
        }
    }
}
