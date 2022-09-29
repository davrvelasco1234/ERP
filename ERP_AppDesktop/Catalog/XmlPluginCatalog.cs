using ERP_AppDesktop.WindowPlugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ERP_AppDesktop.Catalog
{
    public class XmlPluginCatalog : IPluginCatalog
    {
        [XmlRoot(ElementName = "PluginCatalog", Namespace = "http://www.ikriv.com/wpfHosting/plugins")]
        public class XmlPluginData
        {
            [XmlArrayItem(ElementName = "Plugin")]
            public PluginCatalogEntry[] Plugins { get; set; }
        }

        public XmlPluginCatalog()
        {

        }

        public XmlPluginCatalog(string fileName)
        {
            FileName = fileName;
        }

        public string FileName { get; set; }

        public IEnumerable<PluginCatalogEntry> GetPluginList()
        {
            return new List<PluginCatalogEntry>()
            {
                new PluginCatalogEntry
                {
                    Name = "Pruebas 111",
                    Version = "88",
                    Description = "nuevo plugin",
                    AssemblyPath = @"C:\PROYECTOS\MAF\ERP2\PluginPruebas\bin\Debug\PluginPruebas.exe",
                    MainClass = "PluginPruebas.WindowPlugin.Plugin",
                    Parameters = "Default message"
                },
                new PluginCatalogEntry
                {
                    Name = "Pruebas 222",
                    Version = "88",
                    Description = "nuevo plugin",
                    AssemblyPath = @"C:\PROYECTOS\MAF\ERP2\PluginPruebas\bin\Debug\PluginPruebas.exe",
                    MainClass = "PluginPruebas.WindowPlugin.Plugin",
                    Parameters = "Default message"
                },
                new PluginCatalogEntry
                {
                    Name = "Pruebas 333",
                    Version = "88",
                    Description = "nuevo plugin",
                    AssemblyPath = @"C:\PROYECTOS\MAF\ERP2\PluginPruebas\bin\Debug\PluginPruebas.exe",
                    MainClass = "PluginPruebas.WindowPlugin.Plugin",
                    Parameters = "Default message"
                },
                new PluginCatalogEntry
                {
                    Name = "Pruebas 444",
                    Version = "88",
                    Description = "nuevo plugin",
                    AssemblyPath = @"C:\PROYECTOS\MAF\ERP2\PluginPruebas\bin\Debug\PluginPruebas.exe",
                    MainClass = "PluginPruebas.WindowPlugin.Plugin",
                    Parameters = "Default message"
                },
                new PluginCatalogEntry
                {
                    Name = "Pruebas 555",
                    Version = "88",
                    Description = "nuevo plugin",
                    AssemblyPath = @"C:\PROYECTOS\MAF\ERP2\PluginPruebas\bin\Debug\PluginPruebas.exe",
                    MainClass = "PluginPruebas.WindowPlugin.Plugin",
                    Parameters = "Default message"
                }
            };
            //using (var reader = new StreamReader(FileName))
            //{
            //    var serializer = new XmlSerializer(typeof(XmlPluginData));
            //    var data = (XmlPluginData)serializer.Deserialize(reader);
            //    return data.Plugins;
            //}
        }
    }
}
