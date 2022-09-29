using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Reflection;
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

        public static TypeCode GetTypeCode(string type)
        {
            if (type == "Boolean")
                return TypeCode.Boolean;
            else if (type == "Byte")
                return TypeCode.Byte;
            else if (type == "Char")
                return TypeCode.Char;
            else if (type == "DateTime")
                return TypeCode.DateTime;
            else if (type == "Decimal")
                return TypeCode.Decimal;
            else if (type == "Double")
                return TypeCode.Double;
            else if (type == "Int16")
                return TypeCode.Int16;
            else if (type == "Int32")
                return TypeCode.Int32;
            else if (type == "Int64")
                return TypeCode.Int64;
            else if (type == "Object")
                return TypeCode.Object;
            else if (type == "SByte")
                return TypeCode.SByte;
            else if (type == "Single")
                return TypeCode.Single;
            else if (type == "String")
                return TypeCode.String;
            else if (type == "UInt16")
                return TypeCode.UInt16;
            else if (type == "UInt32")
                return TypeCode.UInt32;
            else if (type == "UInt64")
                return TypeCode.UInt64;

            return TypeCode.Empty;
        }




    }
}
