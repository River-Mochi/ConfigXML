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
                { m_Setting.GetOptionGroupLocaleID(Setting.kToggleGroup), "Opciones - elige una" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kButtonGroup), "Acciones" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kConfigUsageGroup), "Cómo usar Config.xml" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kInfoGroup), " " },  // No Info section title
                { m_Setting.GetOptionGroupLocaleID(Setting.kDebugGroup), "DEBUG" },

                // Debug tab: Info group
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.NameDisplay)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.NameDisplay)), "Nombre visible de este mod." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VersionDisplay)), "Versión" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VersionDisplay)), "Número de versión actual." },

                // -----------------------------
                // Actions tab: Options toggles
                // -----------------------------

                // UseModPresets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseModPresets)), "Presets de inicio rápido" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseModPresets)),
                    "<Inicio rápido> - aplica presets integrados automáticamente.\n" +
                    "Modo FÁCIL:  1 clic y LISTO.\n\n" +
                    "Recomendado para la mayoría de jugadores.\n" +
                    "Aumenta trabajadores (y otros ajustes menores de educación requerida).\n" +
                    "Puedes cambiar entre Presets y Archivo personalizado cuando quieras.\n" +
                    "El archivo de Presets y el archivo personalizado de ModsData son distintos."
                },

                // UseLocalConfig
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseLocalConfig)), "Usar archivo personalizado" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UseLocalConfig)),
                    "<USUARIOS AVANZADOS>\n" +
                    "Usa un archivo local: <ModsData/ConfigXML/Config.xml>\n" +
                    "en lugar de los presets del mod.\n" +

                    "<CONSEJOS>\n" +
                    "Haz clic en **Abrir carpeta Config**\n" +
                    "• Edita **Config.xml** con un editor de texto (Notepad++)\n" +
                    "• No pongas trabajadores en 0 (usa valores pequeños).\n" +
                    "• Tras editar: guarda y haz clic en <APLICAR nueva config AHORA>\n\n" +
                    "<Restablecer por defecto> reemplaza el archivo personalizado.\n" +
                    "Puedes volver a Presets cuando quieras (archivos separados)."
                },

                // -----------------------------
                // Actions tab: Buttons (local custom only)
                // -----------------------------

                // OpenConfigFile button (now: folder)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenConfigFile)), "ABRIR carpeta Config" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenConfigFile)),
                    "Opcional\n" +
                    "• Abre la carpeta <ModsData/ConfigXML/> que contiene **Config.xml**.\n" +
                    "1. Edita con tu editor preferido (Notepad++).\n\n" +
                    "2. Ruta de ejemplo (Windows):\n" +
                    "C:/Users/YourName/AppData/LocalLow/Colossal Order/Cities Skylines II/ModsData/ConfigXML/Config.xml"
                },

                // ApplyConfiguration button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ApplyConfiguration)), "APLICAR nueva config AHORA" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Lee <ModsData/ConfigXML/Config.xml> y aplica los nuevos valores a prefabs de servicios (por ejemplo, trabajadores)\n" +
                    "• Aplica a **edificios nuevos** (no existentes).\n" +
                    "• En ciudades existentes, reemplaza el edificio para ver los cambios.\n" +
                    "• Tras editar + guardar Config.xml, pulsa otra vez **Aplicar nueva**."
                },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ApplyConfiguration)),
                    "¿Aplicar cambios a nuevos edificios de servicio?\n " +
                    "¿Seguro?"
                },

                // ResetLocalConfig (Actions tab)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfig)), "Restablecer por defecto (Config.xml)" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfig)),
                    "Botón **EMPEZAR DE NUEVO**.\n\n" +
                    "Sobrescribe **ModsData/ConfigXML/Config.xml** con una copia por defecto (presets incluidos).\n" +
                    "• Útil si el archivo está corrupto o necesitas un reinicio limpio.\n\n" +
                    "• Cierra cualquier Config.xml abierto antes de restablecer."
                },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfig)),
                    "¿Sobrescribir ModsData/ConfigXML/Config.xml con el archivo por defecto (presets)?\n\n" +
                    "El nuevo archivo REEMPLAZA el existente."
                },

                // ----------------------------------
                // Actions tab: How to use Config.xml
                //
                // ----------------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PresetUsageSteps)),
                    "<Opción 1 - Inicio rápido>\n" +
                    "Selecciona **[Presets de inicio rápido]**.\n" +
                    "Listo - a jugar."
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PresetUsageSteps)), " " },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CustomUsageSteps)),
                    "<Opción 2 - Usuarios avanzados>\n" +
                    "**[Usar archivo personalizado]** para hacer tus ajustes.\n\n" +
                    "1. Haz clic en **[ABRIR carpeta Config]**\n" +
                    "2. Edita y guarda **Config.xml** (Notepad++)\n" +
                    "3. Haz clic en **[APLICAR nueva config AHORA]**\n" +
                    "4. Construye un edificio de servicio nuevo para ver los valores\n" +
                    "5. Repite 1-4 sin reiniciar: después de cambios, pulsa <Aplicar nueva>\n\n" +

                    "Migration note:\n" +
                    "Si existía ModsData/RealCity/Config.xml, se copió a **ModsData/ConfigXML/Config.xml**.\n" +
                    "Revisa Logs/ConfigXML.log.\n" +
                    "Para ignorar el archivo antiguo: borra ModsData/RealCity (opcional), inicia el juego y\n" +
                    "usa **[Restablecer por defecto]**"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.CustomUsageSteps)), " " },

                // -----------------------------------
                // Debug tab: status, logging, reset
                // -----------------------------------

                // DumpPrefabStatus button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DumpPrefabStatus)), "Volcar estado de prefabs al log"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "**USUARIOS AVANZADOS**\n" +
                    "Chequeo único: registra si cada prefab de Config.xml está OK o falta.\n" +
                    "• Útil tras parches del juego.\n" +
                    "• Ignora avisos de prefabs de DLC que no tengas - es normal.\n" +
                    "Archivo log: C:/Users/YourName/AppData/LocalLow/Colossal Order/Cities Skylines II/Logs/ConfigXML.log"
                },

                // Verbos Logging (strong warning about performance)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VerboseLogs)),
                    "Logs verbosos (leer advertencias a la derecha)"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.VerboseLogs)),
                    "<NO para juego normal.>\n" +
                    "Los logs verbosos pueden ralentizar el juego y crear archivos grandes.\n" +
                    "Activa solo **temporalmente** para depurar.\n" +
                    "<Si no sabes qué es, mejor dejarlo DESACTIVADO.>"
                },

                // Paradox Mods button (Debug tab, Info group)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxModsButton)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxModsButton)),
                    "Abrir la web de **Paradox Mods** de los mods del autor."
                },

                // Debug tab duplicate reset button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Restablecer por defecto (crear nuevo Config.xml)"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Igual que el botón de Acciones\n" +
                    "Sobrescribe <ModsData/ConfigXML/Config.xml> con el archivo por defecto.\n" +
                    "Usa esto si tu archivo está roto, quieres empezar de cero, o quieres los valores por defecto de la nueva versión (algunas actualizaciones añaden edificios)."
                },
                // Warning Prompt
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "¿Sobrescribir <ModsData/ConfigXML/Config.xml> con el archivo por defecto?\n" +
                    "Se reemplazarán los cambios personalizados."
                },
            };
        }

        public void Unload()
        {
        }
    }
}
