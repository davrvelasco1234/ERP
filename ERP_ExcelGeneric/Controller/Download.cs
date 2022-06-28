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
        public static void Exec<TData>(IEnumerable<TData> datoslist, ConfigDownloadExcel config)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = config.NameBook + "_" + String.Format("{0:dd-MMM-yyyy}", ERP_Entorno.Entorno.GetProperty.FechaHoy());
            saveFileDialog.DefaultExt = ".xlsx";
            saveFileDialog.Title = "Guardar Archivo";
            if (saveFileDialog.ShowDialog() == false) { return; }

            string rutaGuardar = saveFileDialog.FileName;

            Exec<TData>(rutaGuardar, datoslist, config);
        }


        public static void Exec<TData>(string path, IEnumerable<TData> datoslist, ConfigDownloadExcel config)
        {
            SpreadsheetInfo.SetLicense("E0YU-JKB1-WFGE-HHO3");
            ExcelFile workbook = new ExcelFile();

            if (config is null) config = new ConfigDownloadExcel();

            var worksheet = workbook.Worksheets.Add(config.NameSheet);


            var respData = Helpers.Helper.ConvertToDataTable<TData>(datoslist);


            worksheet.InsertDataTable(respData,
            new InsertDataTableOptions()
            {
                ColumnHeaders = true,
                StartRow = 0
            });


            /********************FORMATO DE CONTABILIDAD EN CELDAS*****************/
            for (int i = 0; i < config.ColNum.Count(); i++)
            {
                int colum = config.ColNum[i];
                for (int ren = 0; ren < respData.Columns.Count; ren++)
                {
                    worksheet.Cells[ren, colum].Style.NumberFormat = config.FormatNum;
                }
            }
            /************************************************************************************/


            /********************FORMATO DE FECHA EN CELDAS*****************/
            for (int i = 0; i < config.ColDate.Count(); i++)
            {
                int colum = config.ColDate[i];
                for (int ren = 0; ren < respData.Columns.Count; ren++)
                {
                    worksheet.Cells[ren, colum].Style.NumberFormat = config.FormatDate;
                }
            }
            /************************************************************************************/


            /**************FORMATO DE ENCABEZADO*****************/
            CellStyle style = new CellStyle();
            style.HorizontalAlignment = HorizontalAlignmentStyle.Center;
            style.Font.Weight = ExcelFont.BoldWeight;
            style.Font.Size = 12 * 20;
            for (int j = 0; j < respData.Columns.Count; j++)
            {
                worksheet.Cells[0, j].Style = style;
                worksheet.Columns[j].AutoFit(1, worksheet.Rows[0], worksheet.Rows[100]);
            }
            /****************************************************/


            /****************FIJAR EL ENCABEZADO*******************/
            worksheet.Panes = new WorksheetPanes(PanesState.Frozen, 0, 1, "A2", PanePosition.BottomLeft);
            /******************************************************/

            try
            {
                Helpers.Helper.SaveBook(workbook, path);
                return;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error*", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
    }
}
