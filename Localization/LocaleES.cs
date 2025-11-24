// LocaleES.cs
// Spanish es-ES City Services Redux.

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

            // Show "City Services Redux 0.5.1" title
            if (!string.IsNullOrEmpty(Mod.ModVersion))
            {
                title = title + " " + Mod.ModVersion;
            }

            return new Dictionary<string, string>
            {
                // Tab titles
                { m_Setting.GetSettingsLocaleID(), title },
                { m_Setting.GetOptionTabLocaleID(Setting.kSection), "Acciones" },
                { m_Setting.GetOptionTabLocaleID(Setting.kDebugSection), "Debug" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(Setting.kToggleGroup), "Opciones – elige una" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kButtonGroup), "Acciones" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kConfigUsageGroup), "Cómo usar Config.xml" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kInfoGroup), "Info" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kDebugGroup), "DEBUG" },

                // Debug tab: Info group
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.NameDisplay)), "Mod"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.NameDisplay)), "Nombre visible de este mod."
                },
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.VersionDisplay)), "Versión"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.VersionDisplay)), "Versión actual."
                },

                // -----------------------------
                // Actions tab: Options toggles
                // -----------------------------

                // UseModPresets
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseModPresets)),
                    "AJUSTES RECOMENDADOS"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseModPresets)),
                    "**Inicio rápido** – aplica todos los ajustes recomendados.\n" +
                    "Modo FÁCIL: ¡1 clic y listo!\n\n" +
                    "Recomendado para la mayoría de jugadores – incluye ajustes ya pensados, por ejemplo número de trabajadores/salarios " +
                    "distintos de los valores por defecto del juego."
                },

                // UseLocalConfig
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseLocalConfig)),
                    "USAR Config.xml PERSONAL"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseLocalConfig)),
                    "**USUARIOS AVANZADOS**\n" +
                    "Permite usar un <ModsData/RealCity/Config.xml> personal en lugar de los ajustes integrados.\n" +
                    "• Para quien quiera parámetros distintos por partida o por PC.\n\n" +
                    "**CONSEJOS**\n" +
                    "Haz clic en el botón «ABRIR carpeta de Config.xml».\n" +
                    "• Muestra la carpeta con Config.xml en ModsData/RealCity; allí puedes cambiar trabajadores u otros campos.\n" +
                    "• **Nunca** pongas los puestos de trabajo a 0; usa valores positivos pequeños para poco personal.\n" +
                    "• Después de guardar los cambios, pulsa el botón **APLICAR nueva configuración** para actualizar el mod.\n\n" +
                    "Usa <Restablecer Config.xml> **solo** si rompes el archivo o quieres empezar de cero – la Config.xml actual se reemplaza.\n" +
                    "Puedes volver a **AJUSTES RECOMENDADOS** en cualquier momento."
                },

                // -----------------------------
                // Actions tab: Buttons (local custom only)
                // -----------------------------

                // OpenConfigFile button (now: folder)
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenConfigFile)),
                    "ABRIR carpeta de Config.xml"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenConfigFile)),
                    "No es obligatorio – usa esto solo si quieres cambiar los ajustes por defecto del mod.\n" +
                    "• Abre la carpeta <ModsData/RealCity/> que contiene **Config.xml**.\n" +
                    "1. Edita el archivo con tu editor de texto favorito (por ejemplo <Notepad++>).\n\n" +
                    "2. Ruta de ejemplo (Windows):\n" +
                    "C:/Users/TuNombre/AppData/LocalLow/Colossal Order/Cities Skylines II/ModsData/RealCity/Config.xml"
                },

                // ApplyConfiguration button
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ApplyConfiguration)),
                    "APLICAR nueva configuración"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Lee tu <ModsData/RealCity/Config.xml> personal y aplica los nuevos valores a los edificios de servicios " +
                    "(trabajadores, tasas de proceso, etc.).\n\n" +
                    "• Se aplica a **nuevos edificios**, no a los existentes.\n" +
                    "• En ciudades ya empezadas, derriba el edificio antiguo y construye uno nuevo para ver los cambios.\n" +
                    "• Si estás conforme con los ajustes, basta con cargar una ciudad.\n" +
                    "   Solo tendrás que pulsar **APLICAR nueva configuración** cuando vuelvas a editar Config.xml."
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Aplicar tus nuevos ajustes personalizados a muchos edificios de servicio.\n" +
                    "¿Seguro que quieres continuar?"
                },

                // ResetLocalConfig (Actions tab)
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfig)),
                    "Restablecer Config.xml"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfig)),
                    "BOTÓN DE EMPEZAR DE NUEVO\n\n" +
                    "Sobrescribe **ModsData/RealCity/Config.xml** con una copia nueva de los ajustes originales del mod.\n" +
                    "• Úsalo **solo** si tu archivo se ha roto o quieres empezar desde cero.\n\n" +
                    "• «Restablecer Config.xml» reemplaza el archivo actual – cierra la Config.xml en el editor antes de usar el botón."
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfig)),
                    "¿Sobrescribir ModsData/RealCity/Config.xml con el archivo original?\n\n" +
                    "Se perderán todos tus cambios."
                },

                // ----------------------------------
                // Actions tab: How to use Config.xml
                // (only shown when UseLocalConfig is enabled)
                // ----------------------------------
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ConfigUsageSteps)),
                    "Opción 1\n" +
                    "Selecciona <[AJUSTES RECOMENDADOS]> para usar los ajustes integrados.\n" +
                    "Si eliges AJUSTES RECOMENDADOS, ya está: juega tranquilo.\n\n" +
                    "<--------------------------->\n\n" +
                    "Opción 2 – usuarios avanzados\n" +
                    "Selecciona <[USAR Config.xml PERSONAL]> para editar tus propios valores.\n\n" +
                    "1. Haz clic en <[ABRIR carpeta de Config.xml]>.\n" +
                    "2. Abre, edita y guarda <Config.xml> con tu editor de texto preferido.\n" +
                    "3. Luego haz clic en <[APLICAR nueva configuración]>.\n" +
                    "4. <Carga una ciudad> (o vuelve a cargar) para ver los cambios en los **nuevos** edificios."
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
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.Logging)), "Registro detallado (avanzado)" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.Logging)),
                    "Escribe mucha información adicional en el archivo de registro.\n" +
                    "<NO recomendado> para jugar normalmente.\n" +
                    "Demasiado registro puede ralentizar el juego y crear archivos enormes.\n" +
                    "Actívalo solo temporalmente cuando necesites datos o depurar."
                },

                // DumpPrefabStatus button
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "Volcar estado de prefabs al log"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "**USUARIOS AVANZADOS**\n" +
                    "Comprueba cada prefab listado en Config.xml y registra si está OK o falta.\n" +
                    "• Úsalo después de un parche para ver qué entradas de Config.xml ya no coinciden con el juego.\n" +
                    "• Ignora avisos de prefabs de DLC que no tengas – es normal."
                },

                // Paradox Mods button (Debug tab, Info group)
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxModsButton)),
                    "Paradox Mods"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxModsButton)),
                    "Abre la página de **Paradox Mods** para City Services Redux y tus otros mods."
                },

                // Debug tab duplicate reset button
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Restablecer Config.xml"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Igual que el botón del panel Acciones: sobrescribe <ModsData/RealCity/Config.xml> con una copia nueva " +
                    "de los ajustes originales del mod.\n" +
                    "Úsalo si tu archivo está roto o quieres empezar de cero."
                },
                // Warning Prompt
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "¿Sobrescribir <ModsData/RealCity/Config.xml> con el archivo de PRESETS original?\n\n" +
                    "Cualquier cambio personalizado se sustituirá por una nueva copia."
                },
            };
        }

        public void Unload()
        {
        }
    }
}
