


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

        public const double FontSizeSmallger = 12;
        public const double FontSizeSmall = 14;
        public const double FontSizeMedium = 16;
        public const double FontSizeBig = 18;
        public const double FontSizeBigger = 20;

        public enum MessageType
        {
            Bug,
            Success,
            Help,
            Warning
        }


    }
}
