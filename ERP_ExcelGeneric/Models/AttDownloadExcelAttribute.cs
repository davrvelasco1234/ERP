using System;

namespace ERP_ExcelGeneric.Models
{
    public class AttDownloadExcelAttribute : Attribute
    {
        public string AliasProperty;
        public bool IsVisible = true;
    }
}
