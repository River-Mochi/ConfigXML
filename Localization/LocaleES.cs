// Localization/LocaleES.cs
// Spanish es-ES for Config-XML.

namespace ConfigXML
{
    using Colossal;
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
                { m_Setting.GetOptionGroupLocaleID(Setting.kInfoGroup), " " },  // No Info section title
                { m_Setting.GetOptionGroupLocaleID(Setting.kDebugGroup), "DEBUG" },

                // -----------------------------
                // Actions tab: Options toggles
                // -----------------------------

                // UseModPresets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseModPresets)), "PRESETS RECOMENDADOS" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseModPresets)),
                    "**RECOMENDADO** - aplica **presets** integrados.\n" +
                    "Modo FÁCIL:  1 clic y LISTO.\n\n" +
                    "• Lo mejor para la mayoría: subir trabajadores.\n" +
                    "• Puedes cambiar entre <Presets> y <Archivo personalizado> cuando quieras.\n" +
                    "  (El archivo de presets y el archivo de ModsData son separados.)"
                },

                // UseLocalConfig
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseLocalConfig)), "Usar archivo personalizado" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UseLocalConfig)),
                    "**USUARIOS AVANZADOS**\n" +
                    "Usa un archivo local: <ModsData/ConfigXML/Config.xml>\n" +
                    "en lugar de los presets del mod.\n" +

                    "<Steps>\n" +
                    "Haz clic en **[ABRIR CARPETA CONFIG]**\n" +
                    "• Edita y guarda **Config.xml** con un editor de texto (Notepad++)\n" +
                    "• Luego haz clic en **[APLICAR NUEVA CONFIG AHORA]**\n\n" +
                    "• Nota: no pongas trabajadores en 0.\n" +
                    "• Puedes volver a los presets cuando quieras (archivos separados)."
                },

                // -----------------------------
                // Actions tab: Buttons (local custom only)
                // -----------------------------

                // OpenConfigFile button (now: folder)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenConfigFile)), "ABRIR CARPETA CONFIG" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenConfigFile)),
                    "• Abre la carpeta que contiene **Config.xml**.\n" +
                    "1. Edita el archivo con un editor de texto (**Notepad++**).\n\n" +
                    "2. Ruta de ejemplo (Windows):\n\n" +
                    "<C:/Users/YourName/AppData/LocalLow/Colossal Order/Cities Skylines II/ModsData/ConfigXML/Config.xml>"
                },

                // ApplyConfiguration button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ApplyConfiguration)), "APLICAR NUEVA CONFIG AHORA" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Lee **Config.xml** y aplica los nuevos valores a prefabs de servicios (por ejemplo, trabajadores)\n" +
                    "• Aplica a **edificios nuevos** (no existentes).\n" +
                    "• Reemplaza el edificio antiguo para ver los nuevos valores.\n" +
                    "• Después de editar + guardar Config.xml: pulsa **Aplicar nueva**.\n" +
                    "• Reiniciar el juego también aplica el archivo elegido.\n" +
                    "• Apply usa el archivo <ModsData/ConfigXML/Config.xml>."
                },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ApplyConfiguration)),
                    "¿Aplicar cambios a cualquier edificio de servicio *nuevo*?\n" +
                    "¿Seguro?"
                },

                // ResetLocalConfig (Actions tab)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfig)), "Restablecer a Config por defecto" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfig)),
                    "Botón **EMPEZAR DE NUEVO**.\n\n" +
                    "**Sobrescribe Config.xml** con un archivo por defecto nuevo (incluye todos los presets).\n" +
                    "• Útil si el archivo personalizado está corrupto o necesitas un reinicio limpio.\n\n" +
                    "• Cierra cualquier Config.xml abierto antes de restablecer.\n" +
                    "• Copia un archivo nuevo a: <ModsData/ConfigXML/Config.xml>"
                },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfig)),
                    "¿Sobrescribir ModsData/ConfigXML/Config.xml con el archivo por defecto (presets)?\n\n" +
                    "El nuevo archivo REEMPLAZA el existente."
                },

                // ----------------------------------
                // Actions tab: How to use Config.xml
                // ----------------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PresetUsageSteps)),
                    "<RECOMENDADO> para valores por defecto (trabajadores ↑↑) - Listo, a jugar :)"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PresetUsageSteps)), " " },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CustomUsageSteps)),
                    "**Opción 2 - Usuarios avanzados**\n" +
                    "<[USAR ARCHIVO PERSONALIZADO]> para hacer tus ajustes.\n\n" +
                    "1. Haz clic en <[ABRIR CARPETA CONFIG]>\n" +
                    "2. <Edita + guarda **Config.xml**>.\n" +
                    "3. Haz clic en <[APLICAR NUEVA CONFIG AHORA]>\n" +
                    "4. Pasos 1-3 se pueden repetir sin reiniciar.\n\n" +
                    "<--------------------------->\n" +
                    "Migración del mod antiguo:\n" +
                    "• Si existía </RealCity/Config.xml>, se copió a <ModsData/ConfigXML/Config.xml>.\n" +
                    "• Revisa Logs/ConfigXML.log para confirmarlo\n" +
                    "• Para ignorar archivos viejos: borra la carpeta RealCity (opcional), inicia el juego,\n" +
                    "• y luego usa <[RESTABLECER A CONFIG POR DEFECTO]> para obtener la versión más nueva."
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.CustomUsageSteps)), " " },

                // Debug tab: Info group
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.NameDisplay)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.NameDisplay)), "Nombre visible de este mod." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VersionDisplay)), "Versión" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VersionDisplay)), "Número de versión actual." },

                // Paradox Mods button (Debug tab, Info group)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxModsButton)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxModsButton)),
                    "Abrir la web de **Paradox Mods** de los mods del autor."
                },

                // --------------------------------------
                // Debug tab: status, reset, VerboseLogs
                // --------------------------------------

                // DumpPrefabStatus button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DumpPrefabStatus)), "Volcar estado de prefabs al log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "POWER USERS\n" +
                    "• **Chequeo único**: registra si cada prefab de Config.xml está OK o falta.\n" +
                    "• Útil tras parches del juego para ver qué entradas ya no coinciden.\n" +
                    "• Ignora avisos de prefabs de DLC que no tengas - es normal.\n\n" +
                    "• Archivo log: <C:/Users/YourName/AppData/LocalLow/Colossal Order/Cities Skylines II/Logs/ConfigXML.log>"
                },

                // Debug tab reset button (duplicate)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Restablecer por defecto (crear nuevo Config.xml)"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "**Mismo** botón de Reset que en la pestaña Acciones.\n" +
                    "**Sobrescribe Config.xml** con el archivo por defecto.\n" +
                    "• Úsalo si tu archivo está roto, quieres empezar de cero, o quieres el archivo nuevo del mod (algunas actualizaciones añaden edificios).\n" +
                    "• Archivo copiado aquí: <ModsData/ConfigXML/Config.xml>"
                },
                // Warning Prompt
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Overwrite <ModsData/ConfigXML/Config.xml> con el archivo por defecto?\n" +
                    "Se reemplazarán los cambios personalizados."
                },

                // VerboseLogs (strong warning about performance)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VerboseLogs)),
                    "Logs verbosos (lee las advertencias a la derecha antes de usar)"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.VerboseLogs)),
                    "<NO usar en juego normal.>\n" +
                    "• Los logs verbosos pueden ralentizar el juego y crear archivos grandes.\n" +
                    "• Activa solo unos minutos para **depuración temporal**.\n" +
                    "• <Si no sabes qué es, mejor dejarlo DESACTIVADO.>"
                },
            };
        }

        public void Unload()
        {
        }
    }
}
