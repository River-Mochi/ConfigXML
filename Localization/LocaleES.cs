// LocaleES.cs
// Spanish (es-ES) City Services Redux.

namespace RealCity
{
    using System.Collections.Generic;
    using Colossal;

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

            // Show "City Services Redux 0.5.0" title
            if (!string.IsNullOrEmpty(Mod.ModVersion))
            {
                title = title + " " + Mod.ModVersion;
            }

            return new Dictionary<string, string>
            {
                // Tab titles
                { m_Setting.GetSettingsLocaleID(), title },
                { m_Setting.GetOptionTabLocaleID(Setting.kSection), "Acciones" },
                { m_Setting.GetOptionTabLocaleID(Setting.kDebugSection), "Depuración" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(Setting.kToggleGroup), "Opciones - elige una" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kButtonGroup), "Acciones" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kConfigUsageGroup), "Cómo usar Config.xml" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kInfoGroup), "Información" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kDebugGroup), "DEBUG" },

                // Debug tab: Info group
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.NameDisplay)), "Mod"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.NameDisplay)),
                    "Nombre de este mod."
                },
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.VersionDisplay)), "Versión"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.VersionDisplay)),
                    "Número de versión actual."
                },

                // -----------------------------
                // Actions tab: Options toggles
                // -----------------------------

                // UseModPresets
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseModPresets)),
                    "PRESETS RECOMENDADOS"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseModPresets)),
                    "**Inicio rápido** - aplica todos los ajustes recomendados.\n" +
                    "Modo FÁCIL: ¡1 clic y listo!\n\n" +
                    "Recomendado para la mayoría de jugadores: ya incluye ajustes seleccionados a mano " +
                    "como número de trabajadores/salarios distintos de los valores por defecto del juego."
                },

                // UseLocalConfig
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseLocalConfig)),
                    "USAR Config.xml PERSONALIZADO"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseLocalConfig)),
                    "**USUARIOS AVANZADOS**\n" +
                    "Al activarlo, permite usar un archivo local personalizado " +
                    "<ModsData/RealCity/Config.xml> en lugar de los presets incluidos.\n" +
                    "• Para quienes quieren ajustes de servicios distintos por partida o por PC.\n\n" +
                    "**CONSEJOS**\n" +
                    "Pulsa el botón \"OPEN Config folder\".\n" +
                    "• Muestra la ubicación del Config.xml en ModsData/RealCity; luego puedes ajustar " +
                    "el número de trabajadores u otros campos.\n" +
                    "• **Nunca** pongas los puestos de trabajo a 0; usa valores pequeños si quieres muy poco personal.\n" +
                    "• Después de cambiarlo, guarda el archivo y pulsa **APPLY** para aplicar los cambios al mod.\n\n" +
                    "Usa <Restore new> <SOLO> si has roto tu archivo o quieres un Config.xml totalmente nuevo " +
                    "(reemplaza el archivo existente).\n" +
                    "Puedes volver a **[Use PRESETS]** cuando quieras."
                },

                // -----------------------------
                // Actions tab: Buttons (local custom only)
                // -----------------------------

                // OpenConfigFile button (now: folder)
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenConfigFile)),
                    "ABRIR carpeta de Config"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenConfigFile)),
                    "No es obligatorio: úsalo solo si quieres cambiar los presets por defecto del mod.\n" +
                    "• Abre la carpeta <ModsData/RealCity/> que contiene **Config.xml**.\n" +
                    "1. Edita el archivo con tu editor de texto favorito (por ejemplo, <Notepad++>).\n\n" +
                    "2. Ruta de ejemplo que se abre (Windows):\n" +
                    "C:/Users/TuNombre/AppData/LocalLow/Colossal Order/Cities Skylines II/ModsData/RealCity/Config.xml"
                },

                // ApplyConfiguration button
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ApplyConfiguration)),
                    "APLICAR nueva configuración ahora"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Lee tu archivo local <ModsData/RealCity/Config.xml> y aplica los nuevos valores " +
                    "a los prefabs de servicios de la ciudad (trabajadores, tasas de proceso, etc.).\n\n" +
                    "• Se aplica a **nuevos edificios**, no a los existentes.\n" +
                    "• En ciudades ya empezadas, borra el edificio antiguo y vuelve a colocarlo para ver los cambios.\n" +
                    "• Si ya te gustan los ajustes, simplemente carga una partida.\n" +
                    "   Solo necesitas pulsar **Apply New** cuando vuelvas a cambiar Config.xml."
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Aplicarás tus cambios personalizados a muchos edificios de servicios.\n" +
                    "¿Seguro que quieres continuar?"
                },

                // ResetLocalConfig (Actions tab)
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfig)),
                    "Restaurar nuevo Config.xml"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfig)),
                    "BOTÓN DE EMPEZAR DE CERO\n\n" +
                    "Sobrescribe **ModsData/RealCity/Config.xml** con una copia nueva de los presets originales del mod.\n" +
                    "• Úsalo <solo> si tu archivo personalizado está dañado o si quieres volver a empezar.\n\n" +
                    "• \"Restore new\" reemplaza el archivo existente: primero cierra el Config.xml en tu editor."
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfig)),
                    "¿Sobrescribir ModsData/RealCity/Config.xml con el archivo original?\n\n" +
                    "Se perderán los cambios personalizados que hiciste."
                },

                // ----------------------------------
                // Actions tab: How to use Config.xml
                // (shown only when UseLocalConfig is enabled)
                // ----------------------------------

                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ConfigUsageSteps)),
                    "Opción 1\n" +
                    "Selecciona <[Use PRESETS]> recomendado para los presets incluidos.\n" +
                    "Si eliges PRESETS, ya está: juega.\n\n" +
                    "<--------------------------->\n\n" +
                    "Opción 2 - Usuarios avanzados\n" +
                    "Selecciona <[Use CUSTOM Config.xml]> para editar tus propios valores.\n\n" +
                    "1. Haz clic en <[OPEN Config folder]>.\n" +
                    "2. Abre, edita y guarda <Config.xml> con tu editor de texto.\n" +
                    "3. Luego haz clic en <[APPLY NEW Configuration Now]>.\n" +
                    "4. <Carga una ciudad> (o recarga) para ver los cambios en los **nuevos** edificios."
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ConfigUsageSteps)),
                    " "
                },

                // -----------------------------------
                // Debug tab: logging + status + reset
                // -----------------------------------

                // Logging (strong warning about performance)
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.Logging)),
                    "Registro detallado (avanzado)"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.Logging)),
                    "Escribe mucha información adicional en el archivo de registro.\n" +
                    "<NO recomendado> para juego normal.\n" +
                    "Un registro excesivo puede ralentizar el juego y crear archivos muy grandes.\n" +
                    "Actívalo solo de forma temporal para recopilar datos o depurar."
                },

                // DumpPrefabStatus button
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "Volcar estado de prefabs al log"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "**USUARIOS AVANZADOS**\n" +
                    "Revisa cada prefab listado en Config.xml y registra si está OK o falta.\n" +
                    "• Úsalo después de un parche del juego para ver qué entradas de Config.xml ya no coinciden.\n" +
                    "• Ignora avisos de prefabs de DLC que no posees: es normal."
                },

                // Paradox Mods button (Debug tab, Info group)
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxModsButton)),
                    "Paradox Mods"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxModsButton)),
                    "Abrir la página de **Paradox Mods** para City Services Redux y tus otros mods."
                },

                // Debug tab duplicate reset button
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Restaurar nuevo Config.xml"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Igual que el botón de la pestaña Acciones: sobrescribe <ModsData/RealCity/Config.xml> " +
                    "con una copia nueva de los presets originales.\n" +
                    "Úsalo si tu archivo personalizado está roto o quieres empezar de cero."
                },
                // Warning Prompt
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "¿Sobrescribir <ModsData/RealCity/Config.xml> con el archivo de PRESETS original?\n\n" +
                    "Todos los cambios personalizados se reemplazarán por un archivo nuevo."
                },
            };
        }

        public void Unload()
        {
        }
    }
}
