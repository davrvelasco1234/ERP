using System;
using System.Collections.Generic;
using System.Linq;
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
            saveFileDialog.DefaultExt = "." + config.ExtencionExcel.ToString().ToLower();
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

            worksheet.InsertDataTable(respData,
            new InsertDataTableOptions()
            {
                ColumnHeaders = config.ColumnHeaders,
                StartRow = config.StartRow
            });



            /***********************************FORMATO DE CELDAS********************************/
            for (int colum = 0; colum < respData.Columns.Count; colum++)
            {
                var type = ERP_Common.Helpers.Converts.GetTypeCode(respData.Columns[colum].DataType.Name);
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
    }
    
}
