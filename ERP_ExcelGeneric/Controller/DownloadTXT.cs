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
            string[,] LengthStringList = new string[datatable.Columns.Count, 3];
            bool QuitarEspacios = config.ConfigTXT.QuitarEspacios;

            //Get LengthString por columna
            for (int i = 0; i < datatable.Columns.Count; i++)
            {
                string name = datatable.Columns[i].ColumnName;
                var att = Helpers.Helper.GetAttributeProperty<TData>(name);
                int pad = (att is null) ? 0 : att.LengthString;
                char FillWith = (att is null) ? ' ' : att.FillWith;
                string LR = (att is null) ? "R" : att.LeftRigh.ToString().Substring(0, 1);
                LengthStringList[i, 0] = pad.ToString();
                LengthStringList[i, 1] = FillWith.ToString();
                LengthStringList[i, 2] = LR.ToString();
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
                    int padRight = Convert.ToInt32(LengthStringList[colum, 0]);
                    char fillWith = Convert.ToChar(LengthStringList[colum, 1]);
                    string lr = LengthStringList[colum, 2];

                    var columName = QuitarEspacios ? column.ColumnName.ToString().Trim() :
                                         lr == "R" ? column.ColumnName.ToString().Trim().PadRight(padRight, fillWith) : column.ColumnName.ToString().Trim().PadLeft(padRight, fillWith);

                    Columns += columName + delimited;
                }
                str.WriteLine(Columns.Remove(Columns.Length - 1, 1));
            }


            //escribe datos
            foreach (DataRow datarow in datatable.Rows)
            {
                string row = string.Empty;
                int colum = -1;
                foreach (object item in datarow.ItemArray)
                {
                    colum++;
                    int padRight = Convert.ToInt32(LengthStringList[colum, 0]);
                    char fillWith = Convert.ToChar(LengthStringList[colum, 1]);
                    string lr = LengthStringList[colum, 2];

                    var value = QuitarEspacios ? item.ToString().Trim() :
                                     lr == "R" ? item.ToString().Trim().PadRight(padRight, fillWith) : item.ToString().Trim().PadLeft(padRight, fillWith);

                    row += value + delimited;
                }
                str.WriteLine(row.Remove(row.Length - 1, 1));
            }

            str.Flush();
            str.Close();


            MVVM.Notification.Popup.ExecutePopup(MessageType.Success, "TXT", "Archivo Creado !!!");

        }

    }


}
