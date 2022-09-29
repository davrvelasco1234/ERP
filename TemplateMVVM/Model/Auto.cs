using System;
using ERP_ExcelGeneric.Models;

namespace TemplateMVVM.Model
{
    public class Auto
    {
        public string IdAuto { get; set; }
        [AttDownloadExcel(IsVisible = false)]
        public string IdMarca { get; set; }
        [AttDownloadExcel(AliasProperty = "Marca")]
        public string DescMarca { get; set; }
        [AttDownloadExcel(IsVisible = false)]
        public string IdModelo { get; set; }
        [AttDownloadExcel(AliasProperty = "Modelo")]
        public string DescModelo { get; set; }
        [AttDownloadExcel(IsVisible = false)]
        public string IdCarroceria { get; set; }
        [AttDownloadExcel(AliasProperty = "Carroceria")]
        public string DescCarroceria { get; set; }
        [AttDownloadExcel(AliasProperty = "Año", ApplyFormating = false)]
        public int Anio { get; set; }
        public string Color { get; set; }
        public decimal Precio { get; set; }
        public DateTime FechaCompra { get; set; }
        public string Observaciones { get; set; }
    }
}
