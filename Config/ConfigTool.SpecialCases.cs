// <copyright file="ConfigTool.SpecialCases.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Config/ConfigTool.SpecialCases.cs
// Purpose: Explicit special-case patchers (no reflection) for Config-XML.

namespace ConfigXML
{
    using Game.Prefabs;    // PrefabBase, ComponentBase
    using UnityEngine;     // Mathf

    public static partial class ConfigTool
    {
        private static bool TryPatchProcessingCompanyProcess(PrefabBase prefab, PrefabXml prefabConfig, ComponentBase component)
        {
            // Key off the name so Config.xml can target "IndustrialProcess" even though it's a struct inside ProcessingCompany.
            if (component.GetType().Name != "ProcessingCompany")
            {
                return false;
            }

            if (!prefabConfig.TryGetComponent("IndustrialProcess", out ComponentXml structConfig))
            {
                return false;
            }

            // IMPORTANT: this is the prefab ComponentBase type, not the ECS IComponentData type.
            if (!(component is Game.Prefabs.ProcessingCompany comp))
            {
                return false;
            }

            bool patched = false;
            var oldProc = comp.process;

            if (structConfig.TryGetField("m_MaxWorkersPerCell", out FieldXml mwpcField) && mwpcField.ValueFloatSpecified)
            {
                float newVal = mwpcField.ValueFloat ?? oldProc.m_MaxWorkersPerCell;
                if (!Mathf.Approximately(oldProc.m_MaxWorkersPerCell, newVal))
                {
                    comp.process.m_MaxWorkersPerCell = newVal;
                    s_FieldsChangedThisApply++;
                    patched = true;
                }
            }

            if (structConfig.TryGetField("m_Output.m_Amount", out FieldXml outAmtField) && outAmtField.ValueIntSpecified)
            {
                int newVal = outAmtField.ValueInt ?? oldProc.m_Output.m_Amount;
                if (oldProc.m_Output.m_Amount != newVal)
                {
                    comp.process.m_Output.m_Amount = newVal;
                    s_FieldsChangedThisApply++;
                    patched = true;
                }
            }

            return patched;
        }
    }
}
