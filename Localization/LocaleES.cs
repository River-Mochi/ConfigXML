// File: Localization/LocaleES.cs
// Spanish es-ES for Config-XML.

namespace ConfigXML
{
    using Colossal; // IDictionarySource, IDictionaryEntryError
    using System.Collections.Generic;

    public class LocaleES : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleES(Setting setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors,
            Dictionary<string, int> indexCounts)
        {
            var title = Mod.ModName;

            // Show "Config-XML 0.6.2" title
            if (!string.IsNullOrEmpty(Mod.ModVersion))
            {
                title = title + " (" + Mod.ModVersion + ")";
            }

            return new Dictionary<string, string>
            {
                // Tab titles
                { m_Setting.GetSettingsLocaleID(), title },
                { m_Setting.GetOptionTabLocaleID(Setting.kSection), "Acciones" },
                { m_Setting.GetOptionTabLocaleID(Setting.kDebugSection), "Debug" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(Setting.kButtonGroup), "Acciones" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kToggleGroup), "Elige una" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kConfigUsageGroup), "Cómo usar Config.xml" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kInfoGroup), " " },   // No Info section title
                { m_Setting.GetOptionGroupLocaleID(Setting.kDebugGroup), "DEBUG" },

                // -----------------------------
                // Actions tab: Options toggles
                // -----------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseModPresets)), "PREAJUSTES RECOMENDADOS" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseModPresets)),
                    "**Inicio rápido** - aplica todos los **preajustes** integrados.\n" +
                    "Modo FÁCIL: 1 clic y listo.\n\n" +
                    "• Recomendado para la mayoría: ajustes ya equilibrados (p. ej., trabajadores/salarios).\n\n" +
                    "• Puedes cambiar entre <Preajustes> y <Archivo personalizado> en cualquier momento."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseLocalConfig)), "Usar archivo personalizado" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseLocalConfig)),
                    "**USUARIOS AVANZADOS**\n" +
                    "Usa un archivo personalizado: <ModsData/ConfigXML/Config.xml>\n" +
                    "en lugar de los preajustes del mod.\n\n" +
                    "<Pasos>\n" +
                    "Pulsa **[ABRIR CARPETA DE CONFIG]**\n" +
                    "• Edita y guarda **Config.xml** (Notepad++)\n" +
                    "• Luego pulsa **[APLICAR NUEVA CONFIG AHORA]**\n\n" +
                    "• Nota: no pongas trabajadores a 0.\n" +
                    "• Puedes volver a preajustes cuando quieras (archivo separado)."
                },

                // -----------------------------
                // Actions tab: Buttons (custom only)
                // -----------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenConfigFile)), "ABRIR CARPETA DE CONFIG" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenConfigFile)),
                    "• Abre la carpeta que contiene **Config.xml**.\n" +
                    "1. Edita el archivo con un editor (**Notepad++**).\n\n" +
                    "2. Ruta de ejemplo (Windows):\n\n" +
                    "<C:/Users/YourName/AppData/LocalLow/Colossal Order/Cities Skylines II/ModsData/ConfigXML/Config.xml>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ApplyConfiguration)), "APLICAR NUEVA CONFIG AHORA" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Lee **Config.xml** y aplica nuevos valores a prefabs de servicios (p. ej., trabajadores)\n" +
                    "• Se aplica a **edificios nuevos** (no a existentes).\n" +
                    "• Reemplaza edificios para ver los nuevos valores.\n" +
                    "• Reiniciar también aplica el archivo elegido."
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ApplyConfiguration)),
                    "¿Aplicar cambios a cualquier *nuevo* edificio de servicio?\n¿Seguro?"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfig)), "Restablecer config predeterminada" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfig)),
                    "Botón **EMPEZAR DE CERO**.\n\n" +
                    "**Sobrescribe Config.xml** con un archivo predeterminado limpio (incluye preajustes).\n" +
                    "• Útil si el archivo personalizado está corrupto o quieres resetear.\n\n" +
                    "• Cierra cualquier Config.xml abierto antes de restablecer.\n" +
                    "• Copia a: <ModsData/ConfigXML/Config.xml>"
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfig)),
                    "¿Sobrescribir <ModsData/ConfigXML/Config.xml> con el archivo predeterminado (preajustes)?\n\nEl archivo nuevo REEMPLAZA el existente."
                },

                // ----------------------------------
                // Actions tab: How to use Config.xml
                // ----------------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PresetUsageSteps)), "<RECOMENDADO> valores por defecto - Listo, a jugar :)" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PresetUsageSteps)), " " },

                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.CustomUsageSteps)),
                    "**Opción 2 - Usuarios avanzados**\n" +
                    "<[Usar archivo personalizado]> para crear tus ajustes.\n\n" +
                    "1. Pulsa <[ABRIR CARPETA DE CONFIG]>\n" +
                    "2. <Edita + guarda **Config.xml**>.\n" +
                    "3. Pulsa <[APLICAR NUEVA CONFIG AHORA]>\n" +
                    "4. Repite 1-3 sin reiniciar.\n\n" +
                    "<--------------------------->\n" +
                    "Migración desde mod antiguo:\n" +
                    "• El antiguo </RealCity/Config.xml> (si existe) se copió a <ModsData/ConfigXML/Config.xml>.\n" +
                    "• Revisa Logs/ConfigXML.log para confirmación."
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.CustomUsageSteps)), " " },

                // Debug tab: Info group
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.NameDisplay)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.NameDisplay)), "Nombre visible de este mod." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VersionDisplay)), "Versión" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VersionDisplay)), "Número de versión actual." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxModsButton)), "Paradox Mods" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxModsButton)),
                    "Abrir la página **Paradox Mods** de los mods del autor."
                },

                // --------------------------------------
                // Debug tab: status, dumps, reset, verbose
                // --------------------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DumpPrefabStatus)), "Exportar estado de prefabs (una vez)" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "**USUARIOS AVANZADOS**\n" +
                    "• Comprobación única: indica si cada prefab de Config.xml está OK o falta.\n" +
                    "• Útil tras parches para ver qué entradas ya no coinciden.\n" +
                    "• Prefabs faltantes de DLC no comprado: es normal.\n\n" +
                    "• Archivo de salida: <ModsData/ConfigXML/PrefabStatus_PRESETS.txt> o <PrefabStatus_CUSTOM.txt>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DumpComponentFields)), "Exportar campos de componentes (una vez)" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.DumpComponentFields)),
                    "Exportación única de campos de prefab + componentes para los prefabs listados en Config.xml.\n" +
                    "Salida: <ModsData/ConfigXML/ComponentFields_PRESETS.txt> o <ComponentFields_CUSTOM.txt>"
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.DumpComponentFields)),
                    "Advertencia: genera un archivo grande.\n\nUbicación: <ModsData/ConfigXML/ComponentFields_PRESETS.txt> o <ComponentFields_CUSTOM.txt>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfigDebug)), "Restablecer a predeterminado (crear nuevo Config.xml)" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "**El mismo** botón Reset que en Acciones.\n" +
                    "**Sobrescribe Config.xml** con el archivo predeterminado.\n" +
                    "• Archivo: <ModsData/ConfigXML/Config.xml>"
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "¿Sobrescribir <ModsData/ConfigXML/Config.xml> con el archivo predeterminado?\nSe reemplazarán los cambios personalizados."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VerboseLogs)), "Registros detallados (solo debug)" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.VerboseLogs)),
                    "<NO usar en juego normal.>\n" +
                    "• Puede ralentizar el juego y crear archivos grandes.\n" +
                    "• Actívalo solo un momento para depurar."
                },
            };
        }

        public void Unload()
        {
        }
    }
}
