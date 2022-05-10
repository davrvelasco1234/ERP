using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_Common.Helpers
{
    public static class Converts
    {
        public static string FechaSQL(DateTime Fecha)
        {
            string anio = Fecha.Year.ToString();
            string mes = Fecha.Month.ToString();
            string dia = Fecha.Day.ToString();
            if (mes.ToString().Length < 2) { mes = "0" + mes; }
            if (dia.ToString().Length < 2) { dia = "0" + dia; }
            string fechaSQL = anio + mes + dia;
            return fechaSQL;
        }


        public static string GetXml<T>(T objectT)
        {
            StringBuilder stringBuilder = new StringBuilder();
            System.IO.TextWriter textWrite = new System.IO.StringWriter(stringBuilder);
            System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
            xmlSerializer.Serialize(textWrite, objectT);
            textWrite.Close();
            return stringBuilder.ToString().Replace("'", "").Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?>", "");
        }


    }
}
