using System;
using System.Data;
using System.IO;
using ERP_ExcelGeneric.Models;

namespace ERP_ExcelGeneric.Controller
{
   public class DownloadTXT
    {
        public static void ExportDataTabletoFile<TData>(DataTable datatable, string file, ConfigDownloadExcel config)
        {
            string delimited = config.ConfigTXT.Delimited;
            int[] LengthStringList = new int[datatable.Columns.Count];
            bool QuitarEspacios = config.ConfigTXT.QuitarEspacios;

            //Get LengthString por columna
            for (int i = 0; i < datatable.Columns.Count - 1; i++)
            {
                string name = datatable.Columns[i].ColumnName;
                var att = Helpers.Helper.GetAttributeProperty<TData>(name);
                int pad = (att is null) ? 0 : att.LengthString;
                LengthStringList[i] = pad;
            }

            StreamWriter str = new StreamWriter(file, false, System.Text.Encoding.UTF8);

            //escribe columnas
            if (config.ColumnHeaders)
            {
                string Columns = string.Empty;
                int colum = -1;
                foreach (DataColumn column in datatable.Columns)
                {
                    colum++;
                    int PadRight = LengthStringList[colum];
                    var columName = QuitarEspacios ? column.ColumnName.ToString().Trim() : column.ColumnName.ToString().Trim().PadRight(PadRight);
                    Columns += columName + delimited;
                }
                str.WriteLine(Columns.Remove(Columns.Length - 1, 1));
            }


            //escribe columnas
            foreach (DataRow datarow in datatable.Rows)
            {
                string row = string.Empty;
                int colum = -1;
                foreach (object item in datarow.ItemArray)
                {
                    colum++;
                    int PadRight = LengthStringList[colum];
                    string value = QuitarEspacios ? item.ToString().Trim() : item.ToString().Trim().PadRight(PadRight);
                    row += value + delimited;
                }
                str.WriteLine(row.Remove(row.Length - 1, 1));

            }
            str.Flush();
            str.Close();
        }

    }
}
