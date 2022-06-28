
namespace ERP_ExcelGeneric.Models
{
    public class ConfigDownloadExcel
    {
        /// <summary>
        /// Nomnbre del libro
        /// </summary>
        public string NameBook { get; set; } = "myBook";
        /// <summary>
        /// Nombre de la hoja
        /// </summary>
        public string NameSheet { get; set; } = "Sheet1";
        /// <summary>
        /// Columnas numericas en excel. Ejemplo new int[] { 3, 5, 6 } quiere decir que las columnas d,f,g en el excel son numericas. Si se agrega este parametro se les dara formato de numero a estas columnas 
        /// </summary>
        //public string ColNum { get; set; } = "";
        public int[] ColNum { get; set; } = new int[0];
        /// <summary>
        /// Formato numerico que se asignara al archivo para las columnas indicadas en ColNum
        /// </summary>
        public string FormatNum { get; set; } = ERP_Common.Helpers.Constantes.FormatAccountingExcel;
        /// <summary>
        /// Columnas de fecha en excel. Ejemplo new int[] { 3, 5, 6 } quiere decir que las columnas d,f,g en el excel son fechas. Si se agrega este parametro se les dara formato de fecha a estas columnas 
        /// </summary>
        public int[] ColDate { get; set; } = new int[0];
        /// <summary>
        /// Formato de fecha que se asignara al archivo para las columnas indicadas en ColDate
        /// </summary>
        public string FormatDate { get; set; } = ERP_Common.Helpers.Constantes.FormatDate1;
    }
}
