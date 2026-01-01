// File: Config/ConfigXml.Models.cs
// Purpose: XML model types for Config-XML (ConfigurationXml, PrefabXml, ComponentXml, FieldXml).

namespace ConfigXML
{
    using System.Collections.Generic; // List<T>
    using System.Xml.Serialization;   // Xml* attributes

    [XmlRoot("Configuration")]
    public class ConfigurationXml
    {
        [XmlElement("Prefab")]
        public List<PrefabXml> Prefabs
        {
            get; set;
        } = new List<PrefabXml>();

        public bool TryGetPrefab(string name, out PrefabXml prefab)
        {
            prefab = default!;
            foreach (PrefabXml item in Prefabs)
            {
                if (item.Name == name)
                {
                    prefab = item;
                    return true;
                }
            }

            return false;
        }
    }

    public class PrefabXml
    {
        [XmlAttribute("type")]
        public string Type
        {
            get; set;
        } = string.Empty;

        [XmlAttribute("name")]
        public string Name
        {
            get; set;
        } = string.Empty;

        [XmlElement("Component")]
        public List<ComponentXml> Components
        {
            get; set;
        } = new List<ComponentXml>();

        public override string ToString()
        {
            return $"PrefabXml: {Type}.{Name}";
        }

        /// <summary>
        /// Verbose-only dump (DEBUG + VerboseLogs).
        /// Early-out prevents loops + ToString allocations when verbose is off.
        /// </summary>
        public void DumpToLog()
        {
            if (!Mod.IsVerboseEnabled)
            {
                return;
            }

            Mod.LogIfVerbose(ToString());

            foreach (ComponentXml component in Components)
            {
                component.DumpToLog();
            }
        }

        internal bool TryGetComponent(string name, out ComponentXml component)
        {
            component = default!;
            foreach (ComponentXml item in Components)
            {
                if (item.Name == name)
                {
                    component = item;
                    return true;
                }
            }

            return false;
        }
    }

    public class ComponentXml
    {
        [XmlAttribute("name")]
        public string Name
        {
            get; set;
        } = string.Empty;

        [XmlElement("Field")]
        public List<FieldXml> Fields
        {
            get; set;
        } = new List<FieldXml>();

        public override string ToString()
        {
            return $"ComponentXml: {Name}";
        }

        /// <summary>
        /// Verbose-only dump (DEBUG + VerboseLogs).
        /// Early-out prevents loops/allocs when verbose is off.
        /// </summary>
        public void DumpToLog()
        {
            if (!Mod.IsVerboseEnabled)
            {
                return;
            }

            Mod.LogIfVerbose(ToString());

            foreach (FieldXml field in Fields)
            {
                Mod.LogIfVerbose(field.ToString());
            }
        }

        internal bool TryGetField(string name, out FieldXml field)
        {
            field = default!;
            foreach (FieldXml item in Fields)
            {
                if (item.Name == name)
                {
                    field = item;
                    return true;
                }
            }

            return false;
        }
    }

    public class FieldXml
    {
        [XmlAttribute("name")]
        public string Name
        {
            get; set;
        } = string.Empty;

        // STRING is the default value.
        [XmlAttribute(AttributeName = "value", DataType = "string")]
        public string Value
        {
            get; set;
        } = string.Empty;

        // INTEGER

        [XmlIgnore]
        public bool ValueIntSpecified
        {
            get; set;
        }

        [XmlIgnore]
        public int? ValueInt
        {
            get; set;
        }

        [XmlAttribute("valueInt")]
        public int XmlValueInt
        {
            get => ValueInt.GetValueOrDefault();
            set
            {
                ValueInt = value;
                ValueIntSpecified = true;
            }
        }

        // FLOAT

        [XmlIgnore]
        public bool ValueFloatSpecified
        {
            get; set;
        }

        [XmlIgnore]
        public float? ValueFloat
        {
            get; set;
        }

        [XmlAttribute(AttributeName = "valueFloat", DataType = "float")]
        public float XmlValueFloat
        {
            get => ValueFloat.GetValueOrDefault();
            set
            {
                ValueFloat = value;
                ValueFloatSpecified = true;
            }
        }

        public override string ToString()
        {
            var res = $"{Name}=";

            if (ValueInt.HasValue)
            {
                res += $" {ValueInt} (int)";
            }

            if (ValueFloat.HasValue)
            {
                res += $" {ValueFloat} (float)";
            }

            if (!string.IsNullOrEmpty(Value))
            {
                res += $" {Value}";
            }

            return res;
        }
    }
}
