using System;
using System.IO;
using System.Reflection;
using ERP_HelperFile.Models;


namespace ERP_HelperFile.Files
{
    public class ConnFile
    {
        public static DataConecction GetConfigCon()
        {
            string applicationName = Assembly.GetEntryAssembly().GetName().Name;
            string pathBase = AppDomain.CurrentDomain.BaseDirectory;
            string fileConfig = Path.Combine(pathBase, "Config.pub");

            if (!HelperFile.ExistFile(fileConfig))
            {
                throw new ERP_Common.ErpException("Archivo de configuracion no encontrado");
            }

            string dataSource = KeyFile.ReadKey("Config", "global gvServer", "", fileConfig);
            string initialCatalog = KeyFile.ReadKey("Config", "global gvBaseDatos", "", fileConfig);
            string userID = KeyFile.ReadKey("Config", "global gvUsuario", "", fileConfig);
            string password = KeyFile.ReadKey("Config", "global gvPassword", "", fileConfig);

            if (string.IsNullOrEmpty(dataSource) || string.IsNullOrEmpty(initialCatalog) || string.IsNullOrEmpty(userID) || string.IsNullOrEmpty(password))
            {
                throw new ERP_Common.ErpException("Archivo de configuracion no encontrado");
            }

            return new DataConecction(dataSource, initialCatalog, userID, password, applicationName);
        }
    }
}

