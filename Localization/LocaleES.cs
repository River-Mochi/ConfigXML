// LocaleES.cs
// Spanish (es-ES) Config-XML.

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

            // Show "City Services Redux 0.5.3" title
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
                { m_Setting.GetOptionGroupLocaleID(Setting.kToggleGroup), "Opciones - elige una" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kButtonGroup), "Acciones" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kConfigUsageGroup), "Cómo usar Config.xml" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kInfoGroup), "Info" },
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
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseModPresets)),
                    "AJUSTES PREDEFINIDOS RECOMENDADOS"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseModPresets)),
                    "**Inicio rápido** - aplica todos los ajustes recomendados.\n" +
                    "Modo FÁCIL: ¡1 clic y listo!\n\n" +
                    "Recomendado para la mayoría de jugadores: ya incluye ajustes afinados (p.ej. número de trabajadores/salarios y más) " +
                    "que se diferencian de los valores por defecto del juego."
                },

                // UseLocalConfig
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseLocalConfig)),
                    "USAR ARCHIVO PERSONALIZADO"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseLocalConfig)),
                    "**USUARIOS AVANZADOS**\n" +
                    "Permite usar un archivo local personalizado <ModsData/ConfigXML/Config.xml> en lugar de los presets integrados.\n" +
                    "• Para jugadores avanzados que quieran ajustes distintos por partida o por equipo.\n\n" +
                    "**CONSEJOS**\n" +
                    "Haz clic en el botón Abrir carpeta de config.\n" +
                    "• Muestra la ubicación de Config.xml en ModsData/ConfigXML; allí puedes ajustar trabajadores u otros campos.\n" +
                    "• **Nunca** pongas el número de trabajadores a 0; usa valores pequeños positivos si quieres poco personal.\n" +
                    "• Después de cambiar la configuración, guarda el archivo y usa el botón **APPLY** para aplicar los cambios en el mod.\n\n" +
                    "Usa <Reset new> solo si rompes tu archivo o quieres un Config.xml totalmente nuevo – sustituye el archivo existente.\n" +
                    "Puedes volver a **PREAJUSTES** cuando quieras. "
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
                    "• Abre la carpeta <ModsData/ConfigXML/> que contiene **Config.xml**.\n" +
                    "1. Edita el archivo con tu editor de texto favorito (por ejemplo, <Notepad++>).\n\n" +
                    "2. Ruta de ejemplo en Windows:\n" +
                    "C:/Users/TuNombre/AppData/LocalLow/Colossal Order/Cities Skylines II/ModsData/ConfigXML/Config.xml"
                },

                // ApplyConfiguration button
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ApplyConfiguration)),
                    "APLICAR nueva configuración ahora"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Lee tu <ModsData/ConfigXML/Config.xml> local y aplica los nuevos valores a los edificios de servicios " +
                    "(trabajadores, tasas de procesamiento, etc.).\n\n" +
                    "• Solo afecta a **edificios nuevos**, no a los existentes.\n" +
                    "• En ciudades ya creadas, elimina el edificio antiguo y construye uno nuevo para ver los cambios.\n" +
                    "• Si estás contento con los ajustes, simplemente carga una ciudad.\n" +
                    "   Solo necesitas pulsar **Aplicar nueva** cuando vuelvas a cambiar Config.xml."
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Tus cambios personalizados se aplicarán a muchos edificios de servicios.\n " +
                    "¿Seguro que quieres continuar?"
                },

                // ResetLocalConfig (Actions tab)
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfig)),
                    "Restaurar nuevo Config.xml"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfig)),
                    "BOTÓN PARA EMPEZAR DE CERO\n\n" +
                    "Sobrescribe **ModsData/ConfigXML/Config.xml** con una copia nueva de los presets originales del mod.\n" +
                    "• Úsalo solo si tu archivo personalizado está roto o quieres empezar desde cero.\n\n" +
                    "• **Restaurar nuevo** sustituye el archivo existente: cierra el Config.xml viejo en tu editor primero."
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfig)),
                    "¿Sobrescribir ModsData/ConfigXML/Config.xml con el archivo original?\n\n" +
                    "Tus cambios personalizados se perderán y se reemplazarán por una copia nueva."
                },

                // ----------------------------------
                // Actions tab: How to use Config.xml
                // (only shown when UseLocalConfig is enabled)
                // ----------------------------------

                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ConfigUsageSteps)),
                    "Opción 1\n" +
                    "Selecciona <[AJUSTES PREDEFINIDOS RECOMENDADOS]> para usar los presets integrados.\n" +
                    "Si eliges PREAJUSTES, ya está: juega.\n\n" +
                    "<--------------------------->\n\n" +
                    "Opción 2 - Usuarios avanzados\n" +
                    "Selecciona <[USAR ARCHIVO PERSONALIZADO]> para editar tu propio Config.xml.\n\n" +
                    "1. Haz clic en <[ABRIR carpeta de Config]>.\n" +
                    "2. Abre, edita y guarda <Config.xml> con un editor de texto (por ejemplo, Notepad++).\n" +
                    "3. Haz clic en <[APLICAR nueva configuración ahora]> para aplicar los cambios del archivo.\n" +
                    "4. <Cargar ciudad> (o recargar) para ver los cambios en **edificios nuevos**.\n" +
                    "5. Puedes repetir los pasos 1–4 sin reiniciar el juego siempre que pulses <APPLY> después de cada cambio."
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ConfigUsageSteps)), " " },

                // -----------------------------------
                // Debug tab: logging + status + reset
                // -----------------------------------

                // Logging (strong warning about performance)
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.Logging)),
                    "Registros detallados (lee las advertencias a la derecha antes de usarlo)"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.Logging)),
                    "Escribe mucha información extra en el archivo de registro.\n" +
                    "<NO lo uses> para jugar normalmente.\n" +
                    "Demasiados registros pueden ralentizar el juego y generar archivos enormes.\n" +
                    "Actívalo solo de forma temporal cuando estés recopilando datos o depurando.\n" +
                    "Si no sabes exactamente para qué sirve, mejor déjalo DESACTIVADO."
                },

                // DumpPrefabStatus button
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "Volcar estado de prefabs al registro"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "**USUARIOS AVANZADOS**\n" +
                    "Revisa cada prefab listado en Config.xml y registra si está OK o falta.\n" +
                    "• Úsalo después de un parche del juego para ver qué entradas de Config.xml ya no coinciden con el juego.\n" +
                    "• Ignora las advertencias sobre prefabs de DLC que no posees: es normal."
                },

                // Paradox Mods button (Debug tab, Info group)
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxModsButton)),
                    "Paradox Mods"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxModsButton)),
                    "Abre la página de **Paradox Mods** paraConfig-XML y otros mods."
                },

                // Debug tab duplicate reset button
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Restaurar nuevo Config.xml"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Igual que el botón del panel Acciones: sobrescribe <ModsData/ConfigXML/Config.xml> con una copia nueva " +
                    "de los presets originales del mod.\n" +
                    "Úsalo si tu archivo personalizado está roto o quieres empezar de nuevo."
                },
                // Warning Prompt
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "¿Sobrescribir <ModsData/ConfigXML/Config.xml> con el archivo de PREAJUSTES original del mod?\n\n" +
                    "Cualquier cambio personalizado se reemplazará por un archivo nuevo."
                },
            };
        }

        public void Unload()
        {
        }
    }
}
