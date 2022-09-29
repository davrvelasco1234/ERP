
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
        /// Formato numerico que se asignara a las propiedades int
        /// </summary>
        public string FormatInt { get; set; } = "_-* #,##0_-;-* #,##0_-;_-* \" - \"??_-;_-@_-"; 
        /// <summary>   
        /// Formato numerico que se asignara a las propiedades decimal  
        /// </summary>  
        public string FormatDec { get; set; } = "_-* #,##0.00_-;-* #,##0.00_-;_-* \" - \"??_-;_-@_-";   
        /// <summary>   
        /// Formato numerico que se asignara a las propiedades datetime 
        /// </summary>  
        public string FormatDate { get; set; } = "dd MMM yyyy"; 
        /// <summary>   
        /// Indica si coloca o no titulos a las coumnas 
        /// </summary>  
        public bool ColumnHeaders { get; set; } = true; 
        /// <summary>   
        /// Indica a partir de que renglon comiensa escribir    
        /// </summary>  
        private int startRow = 0;   
        public int StartRow 
        {
            get { return startRow; }
            set
            {
                startRow = value;
                PanesStateRow = startRow + 1;
            }
        }
        /// <summary>
        /// indica si fijara los titulos 
        /// </summary>
        public bool PanesState { get; set; } = true;
        /// <summary>
        /// indica a partir de que renglon fijara los titulos
        /// </summary>
        public int PanesStateRow { get; set; }
        /// <summary>
        /// Indica la extencion con la que se descargara el archivo
        /// </summary>
        public ExtencionExcel ExtencionExcel { get; set; } = ExtencionExcel.XLSX;
    }



    public enum ExtencionExcel
    {
        CSV,
        XLSX
    }
}
