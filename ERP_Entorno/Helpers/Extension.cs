using System;
using System.Globalization;

namespace ERP_Entorno.Helpers
{
    public static class Extension
    {
        public static DateTime ToDateTime(this string date, string inputFormat = "yyyyMMdd")
        {
            if (DateTime.TryParseExact(date, inputFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateTime))
            {
                return DateTime.ParseExact(date,
                                        inputFormat,
                                        CultureInfo.InvariantCulture,
                                        DateTimeStyles.None);
            }
            else
            {
                try
                {
                    return Convert.ToDateTime(date);
                }
                catch (Exception)
                {
                    return new DateTime();
                }
            }
        }

        public static string ToDateFormat(this string date, string inputFormat = "yyyyMMdd", string outputFormat = "dd MMM yyyy")
            => date.ToDateTime(inputFormat).ToString(outputFormat);
    }
}
