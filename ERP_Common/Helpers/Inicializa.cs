
using System;
using System.IO;
using System.Reflection;

namespace ERP_Common.Helpers
{
    public static class Inicializa
    {
        public static string GetAssemblyDirectory()
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);
        }

        public static string GetAssemblyName()
            => Assembly.GetEntryAssembly().GetName().Name;
        
    }
}
