using System;

namespace WpfHost.Interfaces
{
    [Serializable]
    public class PluginStartupInfo
    {
        public string FullAssemblyPath { get; set; }
        public string AssemblyName { get; set; }
        public int Bits { get; set; }
        public string MainClass { get; set; }
        public string Name { get; set; }
        public string Parameters { get; set; }
    }
}
