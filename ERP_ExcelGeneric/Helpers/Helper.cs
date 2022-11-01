using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Windows;
using ERP_ExcelGeneric.Models;
using GemBox.Spreadsheet;

namespace ERP_ExcelGeneric.Helpers
{

    internal class Helper
    {
        internal static void SaveBook(ExcelFile workbook, string path)
        {
            string MessageDefault1 = "El proceso no puede obtener acceso al archivo";
            //string MessageDefault2 = "siendo utilizado en otro";
            try
            {
                workbook.Save(path);
                ERP_Controls.Notification.Popup.ExecutePopup(ERP_Common.Helpers.Constantes.MessageType.Success, "Excel", "Archivo Creado !!!");
                return;
            }
            catch (Exception e)
            {
                var msj = "El archivo que intento sobre escribir esta abierto " + Environment.NewLine +
                          "Cierre el archivo, después presione ACEPTAR para intentar crear el archivo de nuevo " + Environment.NewLine +
                          "O CANCELAR para cancelar la acción";

                if (e.Message.Contains(MessageDefault1))
                {
                    if (MessageBox.Show(msj, "Error", MessageBoxButton.OKCancel, MessageBoxImage.Error) == MessageBoxResult.OK)
                    {
                        SaveBook(workbook, path);
                    }
                    else
                    {
                        ERP_Controls.Notification.Popup.ExecutePopup(ERP_Common.Helpers.Constantes.MessageType.Warning, "Archivo NO Creado", e.Message);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
        }



        internal static DataTable ConvertToDataTable<T>(IEnumerable<T> list)
        {
            DataTable table = CreateDataTable<T>();
            Type entityType = typeof(T);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);
            foreach (T item in list)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                {
                    MemberInfo property = typeof(T).GetProperty(prop.Name);
                    var att = property.GetCustomAttribute(typeof(AttDownloadExcelAttribute)) as AttDownloadExcelAttribute;
                    if (att is null)
                        row[prop.Name] = prop.GetValue(item);
                    else if (att.IsVisible)
                        row[(string.IsNullOrEmpty(att.AliasProperty) ? prop.Name : att.AliasProperty)] = prop.GetValue(item);
                }
                table.Rows.Add(row);
            }
            return table;
        }



        internal static DataTable CreateDataTable<T>()
        {
            Type entityType = typeof(T);
            DataTable table = new DataTable(entityType.Name);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);
            Random r = new Random();
            foreach (PropertyDescriptor prop in properties)
            {
                MemberInfo property = typeof(T).GetProperty(prop.Name);
                var att = property.GetCustomAttribute(typeof(AttDownloadExcelAttribute)) as AttDownloadExcelAttribute;
                if (att is null)
                    table.Columns.Add(prop.Name, prop.PropertyType);
                else if (att.IsVisible)
                    table.Columns.Add((string.IsNullOrEmpty(att.AliasProperty) ? prop.Name : att.AliasProperty), prop.PropertyType);
            }
            return table;
        }


        internal static AttDownloadExcelAttribute GetAttributeProperty<T>(string property)
        {
            Type entityType = typeof(T);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);
            foreach (PropertyDescriptor prop in properties)
            {
                MemberInfo propertyInfo = typeof(T).GetProperty(prop.Name);
                string alias = "";
                var att = propertyInfo.GetCustomAttribute(typeof(AttDownloadExcelAttribute)) as AttDownloadExcelAttribute;
                if (!(att is null))
                    alias = att.AliasProperty;
                if (prop.Name == property || alias == property)
                    return att;
            }
            return null;
        }


    }
}
