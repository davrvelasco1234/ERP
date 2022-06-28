

using System;


namespace LibMappingExcel.Models
{
    
    public class RegularExpressionMappingExcelAttribute : Attribute
    {
        public string RegularExpression;
        public string AliasProperty;
        public string Constans;
        public string Message;
        public string Example;
        public bool IsVisible = true;
        public string InputFormatDate;
        public string OutputFormatDate;
        public string Default;
        public bool IsID = false;
    }
}
