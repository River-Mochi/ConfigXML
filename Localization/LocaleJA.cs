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
                { m_Setting.GetOptionGroupLocaleID(Setting.kToggleGroup), "オプション - どちらか選択" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kButtonGroup), "アクション" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kConfigUsageGroup), "Config.xmlの使い方" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kInfoGroup), " " },  // No Info section title
                { m_Setting.GetOptionGroupLocaleID(Setting.kDebugGroup), "DEBUG" },

                // Debug tab: Info group
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.NameDisplay)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.NameDisplay)), "このModの表示名。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VersionDisplay)), "バージョン" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VersionDisplay)), "現在のバージョン番号。" },

                // -----------------------------
                // Actions tab: Options toggles
                // -----------------------------

                // UseModPresets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseModPresets)), "クイックスタート プリセット" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseModPresets)),
                    "<クイックスタート> - 内蔵プリセットを自動で適用。\n" +
                    "かんたんモード:  1クリックでOK！\n\n" +
                    "ほとんどの人におすすめ。\n" +
                    "労働者数を増やします（＋仕事に必要な教育レベルの小さな調整など）。\n" +
                    "プリセット/カスタムはいつでも切替OK。\n" +
                    "プリセットとModsDataのカスタムは別ファイルです。"
                },

                // UseLocalConfig
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseLocalConfig)), "カスタムファイルを使う" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UseLocalConfig)),
                    "<パワーユーザー>\n" +
                    "ローカルのカスタムファイル: <ModsData/ConfigXML/Config.xml>\n" +
                    "を使います（Modのプリセットの代わり）。\n" +

                    "<ヒント>\n" +
                    "**Configフォルダを開く** をクリック\n" +
                    "• **Config.xml** をテキストエディタで編集（Notepad++）\n" +
                    "• workersを0にしない（少人数なら小さい値を使う）。\n" +
                    "• 編集後: 保存してから <今すぐ新しいconfigを適用> をクリック\n\n" +
                    "<デフォルトに戻す> は既存のカスタムファイルを置き換えます。\n" +
                    "いつでもプリセットへ戻せます（別ファイル）。"
                },

                // -----------------------------
                // Actions tab: Buttons (local custom only)
                // -----------------------------

                // OpenConfigFile button (now: folder)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenConfigFile)), "Configフォルダを開く" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenConfigFile)),
                    "任意\n" +
                    "• **Config.xml** が入っている <ModsData/ConfigXML/> を開きます。\n" +
                    "1. 好きなエディタで編集（Notepad++）。\n\n" +
                    "2. 例（Windows）:\n" +
                    "C:/Users/YourName/AppData/LocalLow/Colossal Order/Cities Skylines II/ModsData/ConfigXML/Config.xml"
                },

                // ApplyConfiguration button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ApplyConfiguration)), "今すぐ新しいconfigを適用" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ApplyConfiguration)),
                    "<ModsData/ConfigXML/Config.xml> を読み込み、サービス系Prefab（例: 建物のworkers）へ反映します\n" +
                    "• **新しく建てた建物** に反映（既存には反映しません）。\n" +
                    "• 既存都市は建物を建て直すと反映されます。\n" +
                    "• Config.xmlを編集して保存したら、もう一度 **適用** をクリック。"
                },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ApplyConfiguration)),
                    "新しく建てるサービス建物へ変更を適用しますか？\n " +
                    "よろしいですか？"
                },

                // ResetLocalConfig (Actions tab)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfig)), "デフォルトのConfig.xmlに戻す" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfig)),
                    "**やり直し** ボタン。\n\n" +
                    "**ModsData/ConfigXML/Config.xml** を、Mod付属のデフォルト（プリセット）で上書きします。\n" +
                    "• カスタムファイルが壊れた/きれいにリセットしたい時に。\n\n" +
                    "• Reset前にConfig.xmlを閉じてください。"
                },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfig)),
                    "ModsData/ConfigXML/Config.xml をデフォルト（プリセット）で上書きしますか？\n\n" +
                    "新しいファイルが既存を置き換えます。"
                },

                // ----------------------------------
                // Actions tab: How to use Config.xml
                // 
                // ----------------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PresetUsageSteps)),
                    "<オプション 1 - クイックスタート>\n" +
                    "内蔵プリセットなら **[クイックスタート プリセット]** を選択。\n" +
                    "これでOK。"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PresetUsageSteps)), " " },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CustomUsageSteps)),
                    "<オプション 2 - パワーユーザー>\n" +
                    "**[カスタムファイルを使う]** で自分用に調整。\n\n" +
                    "1. **[Configフォルダを開く]**\n" +
                    "2. **Config.xml** を編集して保存（Notepad++）\n" +
                    "3. **[今すぐ新しいconfigを適用]**\n" +
                    "4. 新しいサービス建物を建てて確認\n" +
                    "5. 変更後は <適用> を押せば再起動なしで繰り返しOK\n\n" +

                    "移行メモ:\n" +
                    "ModsData/RealCity/Config.xml がある場合、**ModsData/ConfigXML/Config.xml** にコピーされています。\n" +
                    "Logs/ConfigXML.log を確認。\n" +
                    "古いファイルを無視する: ModsData/RealCity を削除（任意）→ゲーム起動→\n" +
                    "**[デフォルトに戻す]**"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.CustomUsageSteps)), " " },

                // -----------------------------------
                // Debug tab: status, logging, reset
                // -----------------------------------
        
                // DumpPrefabStatus button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DumpPrefabStatus)), "Prefab状態をログに出す"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "**パワーユーザー**\n" +
                    "1回だけチェック: Config.xmlの各PrefabがOK/不足かをログ出力。\n" +
                    "• ゲーム更新後の確認に便利。\n" +
                    "• 未所持DLCのPrefab警告は普通なので無視OK。\n" +
                     "ログ: C:/Users/YourName/AppData/LocalLow/Colossal Order/Cities Skylines II/Logs/ConfigXML.log"
                },

                // Verbos Logging (strong warning about performance)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.Logging)),
                    "詳細ログ (右の注意を読んで)"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.Logging)),
                    "<普段はOFF推奨。>\n" +
                    "詳細ログは重くなり、ログも巨大になります。\n" +
                    "デバッグ時だけ **一時的に** ON。\n" +
                    "<よく分からなければOFFのまま。>"
                },

                // Paradox Mods button (Debug tab, Info group)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxModsButton)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxModsButton)),
                    "作者のMod一覧（**Paradox Mods**）を開きます。"
                },

                // Debug tab duplicate reset button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "デフォルトに戻す (新Config.xml)"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "アクションのResetと同じ\n" +
                    "<ModsData/ConfigXML/Config.xml> をデフォルトで上書き 。\n" +
                    "カスタムが壊れた/最初からやりたい/新バージョンのデフォルトが欲しい時に（更新で建物が増える場合あり）。"
                },
                // Warning Prompt
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "<ModsData/ConfigXML/Config.xml> をデフォルトで上書きしますか？\n" +
                    "カスタム変更は置き換えられます。"
                },
            };
        }

        public void Unload()
        {
        }
    }
}
