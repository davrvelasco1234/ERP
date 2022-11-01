using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace ERP_HelperFile.Files
{
    internal class KeyFile
    {
        public static string ReadKey(string lpAppName, string lpKeyName, string lpDefault, string lpFileName)
        {
            StringBuilder valor = new StringBuilder();
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
