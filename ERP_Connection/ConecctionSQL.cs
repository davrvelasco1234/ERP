using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Reflection;
using System.IO;
using System.Runtime.InteropServices;

namespace ERP_Connection
{
    public static class ConecctionSQL
    {

        public static void GetConnection()
        {

        }

        public static void ReadConfig(string[] paramss)
        {
            string nameApp = Assembly.GetEntryAssembly().GetName().Name;
            string pathBase = AppDomain.CurrentDomain.BaseDirectory;
            string fileConfig = Path.Combine(pathBase, "config.pub");


            var resp = Read("Config", "global gvServer", "123",fileConfig);

            var asd = "";

        }

        private static string Read(string lpAppName, string lpKeyName, string lpDefault, string lpFileName)
        {
            var valor = new StringBuilder();
            var resp = GetPrivateProfileString(lpAppName, lpKeyName, lpDefault, valor, 255, lpFileName);
            return valor.ToString();
        }


        private static int GetPrivateProfileStringA(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName)
            => GetPrivateProfileString(lpAppName, lpKeyName, lpDefault, lpReturnedString, nSize, lpFileName);



        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileString(
            string lpAppName,
            string lpKeyName,
            string lpDefault,
            StringBuilder lpReturnedString,
            int nSize,
            string lpFileName);




    }
}

