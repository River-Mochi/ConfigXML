// Localization/LocaleJA.cs
// Japanese ja-JP for Config-XML.

namespace ConfigXML
{
    using Colossal;
    using System.Collections.Generic;

    public class LocaleJA : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleJA(Setting setting)
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
                { m_Setting.GetOptionTabLocaleID(Setting.kSection), "アクション" },
                { m_Setting.GetOptionTabLocaleID(Setting.kDebugSection), "デバッグ" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(Setting.kButtonGroup), "アクション" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kToggleGroup), "どちらか選択" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kConfigUsageGroup), "Config.xmlの使い方" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kInfoGroup), " " },  // No Info section title
                { m_Setting.GetOptionGroupLocaleID(Setting.kDebugGroup), "DEBUG" },

                // -----------------------------
                // Actions tab: Options toggles
                // -----------------------------

                // UseModPresets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseModPresets)), "おすすめプリセット" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseModPresets)),
                    "**おすすめ** - 内蔵 **プリセット** を適用します。\n" +
                    "かんたんモード:  1クリックでOK！\n\n" +
                    "• ほとんどのプレイヤー向け：労働者数を増やします。\n" +
                    "• <プリセット> と <カスタムファイル> はいつでも切替OK。\n" +
                    "  （プリセットとModsDataカスタムは別ファイルです。）"
                },

                // UseLocalConfig
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseLocalConfig)), "カスタムファイルを使う" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UseLocalConfig)),
                    "**POWER USERS**\n" +
                    "ローカルのカスタムファイル: <ModsData/ConfigXML/Config.xml>\n" +
                    "を使います（Modのプリセットの代わり）。\n" +

                    "<Steps>\n" +
                    "**[CONFIGフォルダを開く]** をクリック\n" +
                    "• テキストエディタで **Config.xml** を編集して保存（Notepad++）\n" +
                    "• その後 **[今すぐ新しいConfigを適用]** をクリック\n\n" +
                    "• 注意: workersを0にしないでください。\n" +
                    "• いつでもプリセットへ戻せます（別ファイル）。"
                },

                // -----------------------------
                // Actions tab: Buttons (local custom only)
                // -----------------------------

                // OpenConfigFile button (now: folder)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenConfigFile)), "CONFIGフォルダを開く" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenConfigFile)),
                    "• **Config.xml** があるフォルダを開きます。\n" +
                    "1. テキストエディタで編集（**Notepad++**）。\n\n" +
                    "2. 例（Windows）:\n\n" +
                    "<C:/Users/YourName/AppData/LocalLow/Colossal Order/Cities Skylines II/ModsData/ConfigXML/Config.xml>"
                },

                // ApplyConfiguration button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ApplyConfiguration)), "今すぐ新しいConfigを適用" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ApplyConfiguration)),
                    "**Config.xml** を読み込み、サービス系Prefab（例: 建物のworkers）へ反映します\n" +
                    "• **新しく建てた建物** に反映（既存には反映しません）。\n" +
                    "• 古い建物を建て替えると新しい値が見えます。\n" +
                    "• Config.xmlを編集して保存したら **適用** をクリック。\n" +
                    "• ゲーム再起動でも選択したConfigを適用します。\n" +
                    "• Applyは <ModsData/ConfigXML/Config.xml> を使います。"
                },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ApplyConfiguration)),
                    "*新しく建てる* サービス建物へ変更を適用しますか？\n" +
                    "よろしいですか？"
                },

                // ResetLocalConfig (Actions tab)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfig)), "デフォルトConfigに戻す" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfig)),
                    "**やり直し** ボタン。\n\n" +
                    "**Config.xmlを上書き**して、Mod付属の新しいデフォルト（プリセット込み）に戻します。\n" +
                    "• カスタムファイルが壊れた／きれいにリセットしたい時に。\n\n" +
                    "• Reset前に開いているConfig.xmlを閉じてください。\n" +
                    "• 新しいファイルをここへコピー: <ModsData/ConfigXML/Config.xml>"
                },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfig)),
                    "ModsData/ConfigXML/Config.xml をデフォルト（プリセット）で上書きしますか？\n\n" +
                    "新しいファイルが既存を置き換えます。"
                },

                // ----------------------------------
                // Actions tab: How to use Config.xml
                // ----------------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PresetUsageSteps)),
                    "<おすすめ> デフォルト（workers ↑↑） - これでOK、遊ぼう :)"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PresetUsageSteps)), " " },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CustomUsageSteps)),
                    "**オプション 2 - Power Users**\n" +
                    "<[カスタムファイルを使う]> で自分用に調整。\n\n" +
                    "1. <[CONFIGフォルダを開く]>\n" +
                    "2. <**Config.xml** を編集して保存>\n" +
                    "3. <[今すぐ新しいConfigを適用]>\n" +
                    "4. 1-3は再起動なしで繰り返しOK。\n\n" +
                    "<--------------------------->\n" +
                    "旧Modからの移行:\n" +
                    "• 旧 </RealCity/Config.xml> があった場合、新しい <ModsData/ConfigXML/Config.xml> にコピーされています。\n" +
                    "• Logs/ConfigXML.log で確認\n" +
                    "• 古いファイルを無視する: RealCityフォルダを削除（任意）→ゲーム起動→\n" +
                    "• <[デフォルトに戻す]> で最新版に更新。"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.CustomUsageSteps)), " " },

                // Debug tab: Info group
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.NameDisplay)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.NameDisplay)), "このModの表示名。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VersionDisplay)), "バージョン" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VersionDisplay)), "現在のバージョン番号。" },

                // Paradox Mods button (Debug tab, Info group)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxModsButton)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxModsButton)),
                    "作者のMod一覧（**Paradox Mods**）を開きます。"
                },

                // --------------------------------------
                // Debug tab: status, reset, VerboseLogs
                // --------------------------------------

                // DumpPrefabStatus button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DumpPrefabStatus)), "Prefab状態をログに出す" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "POWER USERS\n" +
                    "• **一回だけチェック**: Config.xmlの各PrefabがOK/不足かをログ出力。\n" +
                    "• ゲーム更新後に、どのエントリが合わなくなったか確認に便利。\n" +
                    "• 未所持DLCのPrefab警告は普通なので無視OK。\n\n" +
                    "• ログ: <C:/Users/YourName/AppData/LocalLow/Colossal Order/Cities Skylines II/Logs/ConfigXML.log>"
                },

                // Debug tab reset button (duplicate)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "デフォルトに戻す (新Config.xml)"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "**同じ** Resetボタン（Actionsタブと同じ）。\n" +
                    "**Config.xmlを上書き**してデフォルトに戻します。\n" +
                    "• ファイルが壊れた／最初からやりたい／新しいModのデフォルトが欲しい時に（更新で建物が増える場合あり）。\n" +
                    "• ファイルはここへ: <ModsData/ConfigXML/Config.xml>"
                },
                // Warning Prompt
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "<ModsData/ConfigXML/Config.xml> をデフォルトで上書きしますか？\n" +
                    "カスタム変更は置き換えられます。"
                },

                // VerboseLogs (strong warning about performance)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VerboseLogs)),
                    "詳細ログ (右の注意を読んでから使ってください)"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.VerboseLogs)),
                    "<普段のプレイでは使わないでください。>\n" +
                    "• 詳細ログは重くなり、ログも巨大になります。\n" +
                    "• デバッグ時だけ、数分だけ **一時的に** ON。\n" +
                    "• <よく分からなければOFFのままがおすすめ。>"
                },
            };
        }

        public void Unload()
        {
        }
    }
}
