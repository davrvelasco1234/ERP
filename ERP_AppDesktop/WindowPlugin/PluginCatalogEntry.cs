using System.Xml.Serialization;

namespace ERP_AppDesktop.WindowPlugin
{
    public class PluginCatalogEntry
    {
        [XmlAttribute] public string Name { get; set; }
        [XmlAttribute] public string Version { get; set; }
        [XmlAttribute] public string Description { get; set; }
        [XmlAttribute] public string AssemblyPath { get; set; }
        [XmlAttribute] public string MainClass { get; set; }
        [XmlAttribute] public int Bits { get; set; }
        [XmlAttribute] public string Parameters { get; set; }
    }
}
