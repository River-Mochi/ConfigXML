// File: Config/ConfigTool.Dumps.cs
// Purpose: One-shot dump tools (status + component field dumps) for Config-XML.

namespace ConfigXML
{
    using Game.Prefabs;                // PrefabSystem, PrefabBase, ComponentBase, PrefabID
    using System;                      // Exception, DateTime, StringComparer, Type
    using System.Collections.Generic;  // HashSet
    using System.IO;                   // StreamWriter, FileStream, FileMode, FileAccess, FileShare, Path, Directory
    using System.Reflection;           // BindingFlags, FieldInfo
    using Unity.Entities;              // Entity, World
    using UnityEngine;                 // Application

    public static partial class ConfigTool
    {
        public static void DumpPrefabStatus()
        {
            string assetPath = Mod.GetAssetPathSafe();
            bool useLocal = Mod.setting != null && Mod.setting.UseLocalConfig;

            ConfigurationXml? config = useLocal
                ? ConfigToolXml.LoadLocalConfig(assetPath)
                : ConfigToolXml.LoadPresetConfig(assetPath);

            if (config == null || config.Prefabs == null || config.Prefabs.Count == 0)
            {
                Mod.Log("DumpPrefabStatus: config has no Prefabs to check.");
                return;
            }

            World? world = World.DefaultGameObjectInjectionWorld;
            if (world == null)
            {
                Mod.Log("DumpPrefabStatus: default ECS world not available; skip.");
                return;
            }

            PrefabSystem prefabSystem;
            try
            {
                prefabSystem = world.GetOrCreateSystemManaged<PrefabSystem>();
            }
            catch (Exception ex)
            {
                Mod.Log($"DumpPrefabStatus: failed to get PrefabSystem: {ex.GetType().Name}: {ex.Message}");
                return;
            }

            string mode = useLocal ? "CUSTOM" : "PRESETS";

            int ok = 0;
            int missing = 0;
            int noEntity = 0;

            Mod.Log($"{Mod.ModTag} === PREFAB STATUS DUMP BEGIN ({mode}) ===");
            Mod.Log($"{Mod.ModTag} Total prefabs in config: {config.Prefabs.Count}");
            Mod.Log($"{Mod.ModTag} Output mode: PROBLEMS ONLY");

            string folder = Path.Combine(Application.persistentDataPath, "ModsData", "ConfigXML");
            Directory.CreateDirectory(folder);
            string filePath = Path.Combine(folder, $"PrefabStatus_{mode}.txt");

            using (var writer = new StreamWriter(new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.Read)))
            {
                writer.WriteLine($"{Mod.ModTag} Prefab Status Dump ({mode})");
                writer.WriteLine($"Total prefabs in config: {config.Prefabs.Count}");
                writer.WriteLine($"Generated: {DateTime.Now}");
                writer.WriteLine();

                foreach (PrefabXml prefabXml in config.Prefabs)
                {
                    PrefabID id = new PrefabID(prefabXml.Type, prefabXml.Name);

                    string status;
                    if (!prefabSystem.TryGetPrefab(id, out PrefabBase prefab))
                    {
                        status = "MISSING";
                        missing++;
                    }
                    else if (!prefabSystem.TryGetEntity(prefab, out _))
                    {
                        status = "NO_ENTITY";
                        noEntity++;
                    }
                    else
                    {
                        status = "OK";
                        ok++;
                    }

                    if (status != "OK")
                    {
                        Mod.Log($"{Mod.ModTag} PREFAB {status}: {prefabXml}");
                    }

                    writer.WriteLine($"{status}\t{prefabXml.Type}\t{prefabXml.Name}");
                }

                writer.WriteLine();
                writer.WriteLine($"Summary: OK={ok}, NO_ENTITY={noEntity}, MISSING={missing}");
                writer.WriteLine("Note: MISSING prefabs from DLC you do not own is normal.");
            }

            Mod.Log($"{Mod.ModTag} Summary: OK={ok}, NO_ENTITY={noEntity}, MISSING={missing}");
            Mod.Log($"{Mod.ModTag} Note: MISSING prefabs from DLC you do not own is normal.");
            Mod.Log($"{Mod.ModTag} Status file saved to {filePath}");
            Mod.Log($"{Mod.ModTag} === PREFAB STATUS DUMP END ===");
        }

        public static void DumpXMLComponentFields()
        {
            string assetPath = Mod.GetAssetPathSafe();
            bool useLocal = Mod.setting != null && Mod.setting.UseLocalConfig;

            ConfigurationXml? config = useLocal
                ? ConfigToolXml.LoadLocalConfig(assetPath)
                : ConfigToolXml.LoadPresetConfig(assetPath);

            if (config == null || config.Prefabs == null || config.Prefabs.Count == 0)
            {
                Mod.Warn($"{Mod.ModTag} Dump Component Fields: config has no Prefabs.");
                return;
            }

            World? world = World.DefaultGameObjectInjectionWorld;
            if (world == null)
            {
                Mod.Warn($"{Mod.ModTag} Dump Component Fields: default ECS world not available.");
                return;
            }

            PrefabSystem prefabSystem;
            try
            {
                prefabSystem = world.GetOrCreateSystemManaged<PrefabSystem>();
            }
            catch (Exception ex)
            {
                Mod.Warn($"{Mod.ModTag} Dump Component Fields: failed to get PrefabSystem: {ex.GetType().Name}: {ex.Message}");
                return;
            }

            string mode = useLocal ? "CUSTOM" : "PRESETS";
            string folder = Path.Combine(Application.persistentDataPath, "ModsData", "ConfigXML");
            Directory.CreateDirectory(folder);
            string filePath = Path.Combine(folder, $"ComponentFields_{mode}.txt");

            var seen = new HashSet<string>(StringComparer.Ordinal);

            using (var writer = new StreamWriter(new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.Read)))
            {
                writer.WriteLine($"{Mod.ModTag} Component Field Dump ({mode})");
                writer.WriteLine($"Prefabs in config: {config.Prefabs.Count}");
                writer.WriteLine($"Generated: {DateTime.Now}");
                writer.WriteLine();

                foreach (PrefabXml prefabXml in config.Prefabs)
                {
                    string key = prefabXml.Type + "|" + prefabXml.Name;
                    if (!seen.Add(key))
                    {
                        continue;
                    }

                    PrefabID id = new PrefabID(prefabXml.Type, prefabXml.Name);

                    if (!prefabSystem.TryGetPrefab(id, out PrefabBase prefab))
                    {
                        writer.WriteLine($"# MISSING: {prefabXml.Type}.{prefabXml.Name}");
                        writer.WriteLine();
                        continue;
                    }

                    if (!prefabSystem.TryGetEntity(prefab, out Entity entity))
                    {
                        writer.WriteLine($"# NO_ENTITY: {prefabXml.Type}.{prefabXml.Name}");
                        writer.WriteLine();
                        continue;
                    }

                    writer.WriteLine($"# {prefabXml.Type}.{prefabXml.Name}");
                    writer.WriteLine($"PrefabClass: {prefab.GetType().Name}");
                    writer.WriteLine($"EntityIndex: {entity.Index}");
                    writer.WriteLine();

                    DumpObjectFieldsToWriter(writer, prefab.name, prefab);

                    if (prefab.components != null)
                    {
                        foreach (ComponentBase component in prefab.components)
                        {
                            if (component == null)
                            {
                                continue;
                            }

                            DumpObjectFieldsToWriter(writer, prefab.name + "." + component.name, component);
                        }
                    }

                    writer.WriteLine("----");
                    writer.WriteLine();
                }
            }

            Mod.Log($"{Mod.ModTag} Component field dump saved to {filePath}");
        }

        // Back-compat wrapper (older Setting.cs referenced this name).
        public static void DumpConfiguredPrefabFieldsToFile()
        {
            DumpXMLComponentFields();
        }

        private static void DumpObjectFieldsToWriter(StreamWriter writer, string label, object obj)
        {
            Type type = obj.GetType();
            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            writer.WriteLine($"[{label}] CLASS={type.Name}");

            foreach (FieldInfo field in fields)
            {
                if (field.Name == "isDirty" || field.Name == "active" || field.Name == "components")
                {
                    continue;
                }

                object? value;
                try
                {
                    value = field.GetValue(obj);
                }
                catch
                {
                    value = "<unreadable>";
                }

                writer.WriteLine($"{field.Name} = {value}");
            }

            writer.WriteLine();
        }
    }
}
