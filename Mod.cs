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
    using System.Reflection;         // Assembly, FieldInfo, PropertyInfo

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
        public static ExecutableAsset? modAsset { get; private set; }
        public static Setting? setting { get; private set; }

        private static bool s_BannerLogged;

        public void OnLoad(UpdateSystem updateSystem)
        {
            instance = this;

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
                    s_Log.Warn("Failed to resolve mod ExecutableAsset; falling back to assembly location for shipped files.");
                }
            }
            catch (Exception ex)
            {
                s_Log.Warn($"TryGetExecutableAsset failed: {ex.GetType().Name}: {ex.Message}");
            }

            var s = new Setting(this);
            setting = s;

            AddLocaleSource("en-US", new LocaleEN(s));
            AddLocaleSource("de-DE", new LocaleDE(s));
            AddLocaleSource("es-ES", new LocaleES(s));
            AddLocaleSource("fr-FR", new LocaleFR(s));
            AddLocaleSource("it-IT", new LocaleIT(s));
            AddLocaleSource("ja-JP", new LocaleJA(s));
            AddLocaleSource("ko-KR", new LocaleKO(s));
            AddLocaleSource("pl-PL", new LocalePL(s));
            AddLocaleSource("pt-BR", new LocalePT_BR(s));
            AddLocaleSource("zh-HANS", new LocaleZH_CN(s));
            AddLocaleSource("zh-HANT", new LocaleZH_HANT(s));

            AssetDatabase.global.LoadSettings("ConfigSettings", s, new Setting(this));
            s.RegisterInOptionsUI();

            s._Hidden = false;

            try
            {
                ConfigToolXml.EnsureModsDataSeeded(GetAssetPathSafe());
            }
            catch (Exception ex)
            {
                s_Log.Warn($"EnsureModsDataSeeded failed: {ex.GetType().Name}: {ex.Message}");
            }

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

        public static string GetAssetPathSafe()
        {
            if (modAsset != null && !string.IsNullOrEmpty(modAsset.path))
            {
                return modAsset.path;
            }

            return string.Empty;
        }

        // --------------------------------------------------------------
        // Log Helpers
        // --------------------------------------------------------------

        public static void Log(string message)
        {
            SafeLogInfo(message);
        }

        // Verbose is permanently disabled (buttons + files are the approved “deep dump” mechanism).
        public static bool IsVerboseEnabled => false;

        public static void LogIfVerbose(string message)
        {
            // Intentionally a no-op. prevents accidental huge dumps.
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
            catch
            {
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
