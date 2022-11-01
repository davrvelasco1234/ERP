
namespace ERP_Common.Helpers
{
    public static class Constantes
    {
        public const string DB_DefaultConnection = "DB_DefaultConnection";
        public const string DB_Ayer = "DB_Ayer";
        public const string DB_Hoy = "DB_Hoy";
        public const string DB_QA = "DB_QA";

        public const int MessageCodeTry = 999;
        public const int MessageCodeParamArg = 998;
        public const int MessageCodeErrorLog = 997;
        public const int MessageCodeWindowsClose = 990;

        public const double FontSizeSmallger = 12;
        public const double FontSizeSmall = 15;
        public const double FontSizeMedium = 18;
        public const double FontSizeBig = 21;
        public const double FontSizeBigger = 24;


        public const string FormatDate1 = "dd MMM yyyy";
        public const string FormatDate2 = "dd MM yyyy";
        public const string FormatDate3 = "dd/MMM/yyyy";
        public const string FormatDate4 = "dd/MM/yyyy";
        public const string FormatDate5 = "dd-MMM-yyyy";
        public const string FormatDate6 = "dd-MM-yyyy";

        public const string FormatAccounting1_Dec = "#,##0.00;-  #,##0.00; -    ;";
        public const string FormatAccounting2_Dec = "#,##0.00;-  #,##0.00;     ;";
        public const string FormatAccounting3_Dec = "#,##0.00;-  #,##0.00; 0.00    ;";

        public const string FormatAccounting1_Int = "#,##0;-  #,##0; -    ;";
        public const string FormatAccounting2_Int = "#,##0;-  #,##0;     ;";
        public const string FormatAccounting3_Int = "#,##0;-  #,##0; 0    ;";

        public const string FormatSinNegativos = "#,##0.00;  ;   ;";
        public const string FormatAccountingExcel = "_-* #,##0.00_-;-* #,##0.00_-;_-* \" - \"??_-;_-@_-";


        public enum MessageType
        {
            Bug,
            Success,
            Help,
            Warning
        }


    }
}
