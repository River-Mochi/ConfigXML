// File: Mod.cs
// Purpose: Entry point for ConfigXML [CFG].

namespace ConfigXML
{
    using Colossal;                  // IDictionarySource
    using Colossal.IO.AssetDatabase; // AssetDatabase.LoadSettings
    using Colossal.Localization;     // LocalizationManager
    using Colossal.Logging;          // ILog, LogManager
    using Game;                      // UpdateSystem
    using Game.Modding;              // IMod
    using Game.SceneFlow;            // GameManager, ExecutableAsset
    using System;                    // Exception, Type
    using System.Reflection;          // Assembly, FieldInfo, PropertyInfo

    public sealed class Mod : IMod
    {
        public const string ModId = "ConfigXML";
        public const string ModName = "Config-XML";
        public const string ModTag = "[CFG]";

        public static readonly string ModVersion =
            Assembly.GetExecutingAssembly().GetName().Version?.ToString(3) ?? "1.0.0";

        public static readonly ILog s_Log =
            LogManager.GetLogger(ModId).SetShowsErrorsInUI(false);

        public static Mod? instance { get; private set; }

        // Nullable: resolution can fail depending on load context.
        public static ExecutableAsset? modAsset { get; private set; }

        // Nullable to avoid null-forgiving patterns.
        public static Setting? setting { get; private set; }

        private static bool s_BannerLogged;

        public void OnLoad(UpdateSystem updateSystem)
        {
            instance = this;

            if (!s_BannerLogged)    // one-time banner
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

            // Resolve mod asset path (helps locate shipped Config.xml / README).
            try
            {
                if (gameManager.modManager.TryGetExecutableAsset(this, out ExecutableAsset resolved))
                {
                    modAsset = resolved;

#if DEBUG
                    s_Log.Info($"{resolved.name} v{resolved.version} mod asset at {resolved.path}");
#endif
                }
                else
                {
                    // Not fatal: ConfigToolXml can fall back to assembly location.
                    s_Log.Warn("Failed to resolve mod ExecutableAsset; falling back to assembly location for shipped files.");
                }
            }
            catch (Exception ex)
            {
                s_Log.Warn($"TryGetExecutableAsset failed: {ex.GetType().Name}: {ex.Message}");
            }

            // Create settings before locales so localized UI resolves correctly.
            var s = new Setting(this);
            setting = s;

            AddLocaleSource("en-US", new LocaleEN(s));
            AddLocaleSource("de-DE", new LocaleDE(s));
            AddLocaleSource("es-ES", new LocaleES(s));
            AddLocaleSource("fr-FR", new LocaleFR(s));
            // AddLocaleSource("it-IT", new LocaleIT(s));
            AddLocaleSource("ja-JP", new LocaleJA(s));
            AddLocaleSource("ko-KR", new LocaleKO(s));
            AddLocaleSource("pl-PL", new LocalePL(s));
            AddLocaleSource("pt-BR", new LocalePT_BR(s));
            AddLocaleSource("zh-HANS", new LocaleZH_CN(s));
            AddLocaleSource("zh-HANT", new LocaleZH_HANT(s));
            // AddLocaleSource("vi-VN", new LocaleVI(s));

            // Load persisted settings (or defaults on first run).
            AssetDatabase.global.LoadSettings("ConfigSettings", s, new Setting(this));

            s.RegisterInOptionsUI();

            // Force settings file creation even when all visible options are defaults.
            s._Hidden = false;

            // Seed ModsData (Config.xml + README). Method handles migration + repairs.
            try
            {
                ConfigToolXml.EnsureModsDataSeeded(GetAssetPathSafe());
            }
            catch (Exception ex)
            {
                s_Log.Warn($"EnsureModsDataSeeded failed: {ex.GetType().Name}: {ex.Message}");
            }

            // Apply-on-load.
            ConfigTool.ReadAndApply();
        }

        public void OnDispose()
        {
            s_Log.Info(nameof(OnDispose));

            if (setting != null)
            {
                setting.UnregisterInOptionsUI();
                setting = null;
            }

            modAsset = null;
            instance = null;
        }

        // -----------------------------------------------------------------
        // Helpers
        // -----------------------------------------------------------------

        /// <summary>
        /// Returns the installed mod folder path (ExecutableAsset.path) when available.
        /// Returns empty string when path not resolved (caller may fallback).
        /// </summary>
        public static string GetAssetPathSafe()
        {
            if (modAsset != null && !string.IsNullOrEmpty(modAsset.path))
            {
                return modAsset.path;
            }

            return string.Empty;
        }

        /// <summary>
        /// Debug helper: logs fields + properties of an object via reflection.
        /// For diagnosing game objects/components without a debugger.
        /// </summary>
        public static void DumpObjectData(object? objectToDump)
        {
            if (objectToDump == null)
            {
                SafeLogInfo("Object: <null>");
                return;
            }

            SafeLogInfo("Object: " + objectToDump);

            Type type = objectToDump.GetType();

            // Includes private fields because game types often hide useful state there.
            FieldInfo[] fields = type.GetFields(
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (FieldInfo field in fields)
            {
                SafeLogInfo(" " + field.Name + ": " + field.GetValue(objectToDump));
            }
            // Same for properties (some game types expose state via properties only).
            PropertyInfo[] properties = type.GetProperties(
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (PropertyInfo property in properties)
            {
                SafeLogInfo(" " + property.Name + ": " + property.GetValue(objectToDump));
            }
        }

        // -----------------------------------------------------------------
        // Log Helpers
        // -----------------------------------------------------------------

        /// <summary>
        /// Always-on informational logging.
        /// Routes through SafeLogInfo so logger failures cannot throw into gameplay/UI.
        /// </summary>
        public static void Log(string message)
        {
            SafeLogInfo(message);
        }

        /// <summary>
        /// Verbose logging: only active when in-game Logging checkbox is enabled.
        /// Use for per-prefab/per-field spam that would otherwise hurt performance.
        /// </summary>
        public static void LogIf(string message)
        {
            if (setting == null || !setting.Logging)
            {
                return;
            }

            SafeLogInfo(message);
        }

        /// <summary>
        /// Lowest-level log write with guard rails:
        /// - ignores empty strings
        /// - catches logger exceptions (rare but real in CS2)
        /// </summary>
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
            catch
            {
                // Swallow CO logger fails so they never surface to the player.
            }
        }

        public static void Warn(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                return;
            }

            try
            {
                s_Log.Warn(message);
            }
            catch
            {
                // Swallow logging failures so they never surface to the player.
            }
        }

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
                s_Log.Warn($"AddLocaleSource: AddSource for '{localeId}' failed: {ex.GetType().Name}: {ex.Message}");
            }
        }
    }
}
