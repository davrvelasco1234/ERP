
using System;
using System.Collections.Generic;
using System.Text;
using ERP_Common.Helpers;


namespace ERP_Common
{
    public static class ErpHelpersXXx
    {

        public static string FnxGetMessage(this Exception exception)
           => exception.Message + Environment.NewLine +
                   exception.Source + Environment.NewLine +
                   exception.HelpLink + Environment.NewLine +
                   exception.HResult + Environment.NewLine +
                   exception.InnerException + Environment.NewLine +
                   exception.StackTrace + Environment.NewLine +
                   exception.TargetSite + Environment.NewLine +
                   exception.Data;


        public static string FnxFechaSQL(this DateTime Fecha)
            => Converts.FechaSQL(Fecha);


        public static T GetInstance<T>()
            => Cifrado.GetInstance<T>();


        public static string FnxEncode(this string cadena)
            => Cifrado.Base64_Encode(cadena);


        public static string FnxDecode(this string cadena)
            => Cifrado.Base64_Decode(cadena);


        public static string GetAssemblyDirectory()
            => Inicializa.GetAssemblyDirectory();


        public static string GetXml<T>(T objectT)
            => Converts.GetXml<T>(objectT);
    }
}
