using System;
using System.Collections.Generic;
using System.Windows;
using ERP_ExcelGeneric.Models;
using GemBox.Spreadsheet;
using Microsoft.Win32;



namespace ERP_ExcelGeneric.Controller
{


    internal class Download
    {
        internal static bool Exec<TData>(IEnumerable<TData> datoslist, ConfigDownloadExcel config)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = config.NameBook;
            saveFileDialog.DefaultExt = "." + config.Extencion.ToString().ToLower();
            saveFileDialog.Title = "Guardar Archivo";
            if (saveFileDialog.ShowDialog() == false) { return false; }

            string rutaGuardar = saveFileDialog.FileName;

            return Exec<TData>(rutaGuardar, datoslist, config);
        }


        internal static bool Exec<TData>(string path, IEnumerable<TData> datoslist, ConfigDownloadExcel config)
        {
            SpreadsheetInfo.SetLicense("E0YU-JKB1-WFGE-HHO3");
            ExcelFile workbook = new ExcelFile();

            if (config is null) config = new ConfigDownloadExcel();

            var worksheet = workbook.Worksheets.Add(config.NameSheet);

            var respData = Helpers.Helper.ConvertToDataTable<TData>(datoslist);


            //SI ES FORMATO TXT HASTA AQUI LLEGA
            if (config.Extencion == Extencion.TXT)
            {
                DownloadTXT.ExportDataTabletoFile<TData>(respData, path, config);
                return true;
            }



            worksheet.InsertDataTable(respData,
            new InsertDataTableOptions()
            {
                ColumnHeaders = config.ColumnHeaders,
                StartRow = config.StartRow
            });



            /***********************************FORMATO DE CELDAS********************************/
            for (int colum = 0; colum < respData.Columns.Count; colum++)
            {
                var type = GetTypeCode(respData.Columns[colum].DataType.Name);
                string name = respData.Columns[colum].ColumnName;
                var AttributeProperty = Helpers.Helper.GetAttributeProperty<TData>(name);
                var applyFormating = AttributeProperty is null ? true : AttributeProperty.ApplyFormating;

                if ((type == TypeCode.Decimal || type == TypeCode.Double) && !string.IsNullOrEmpty(config.FormatDec) && applyFormating)
                {
                    for (int ren = 0; ren <= respData.Rows.Count; ren++)
                        worksheet.Cells[ren, colum].Style.NumberFormat = config.FormatDec;
                }
                else if ((type == TypeCode.Int16 || type == TypeCode.Int32 || type == TypeCode.Int64) && !string.IsNullOrEmpty(config.FormatInt) && applyFormating)
                {
                    for (int ren = 0; ren <= respData.Rows.Count; ren++)
                        worksheet.Cells[ren, colum].Style.NumberFormat = config.FormatInt;
                }
                else if (type == TypeCode.DateTime && !string.IsNullOrEmpty(config.FormatDate) && applyFormating)
                {
                    for (int ren = 0; ren <= respData.Rows.Count; ren++)
                        worksheet.Cells[ren, colum].Style.NumberFormat = config.FormatDate;
                }
                if ((AttributeProperty is null ? false : AttributeProperty.IsColumnEmpty))
                {
                    for (int ren = 0; ren <= respData.Rows.Count; ren++)
                        worksheet.Cells[ren, colum].Value = "";
                }
            }
            /************************************************************************************/


            if (config.ColumnHeaders)
            {
                /**************FORMATO DE ENCABEZADO*****************/
                CellStyle style = new CellStyle();
                style.HorizontalAlignment = HorizontalAlignmentStyle.Center;
                style.Font.Weight = ExcelFont.BoldWeight;
                style.Font.Size = 12 * 20;
                for (int j = 0; j < respData.Columns.Count; j++)
                {
                    for (int i = 0; i <= config.StartRow; i++)
                    {
                        worksheet.Cells[i, j].Style = style;

                        //if (!(worksheet.Cells[i, j].Value is null) && worksheet.Cells[i, j].Value.ToString().Contains(ConfigDownloadExcel.NameColumnEmpty))
                        //    worksheet.Cells[i, j].Value = "";
                    }
                    worksheet.Columns[j].AutoFit(1, worksheet.Rows[0], worksheet.Rows[100]);
                }
                /****************************************************/
            }

            if (config.PanesState)
            {
                /****************FIJAR EL ENCABEZADO*******************/
                worksheet.Panes = new WorksheetPanes(PanesState.Frozen, 0, config.PanesStateRow, string.Concat("A", config.PanesStateRow + 1), PanePosition.BottomLeft);
                /******************************************************/
            }
            try
            {

                Helpers.Helper.SaveBook(workbook, path);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error*", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

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
