

namespace LibMappingExcel.Helpers
{
    internal class ValidateFormat
    {
        internal static bool ValidateFormatDate(string format)
        {
            string day = "dd";
            string month = "MM";
            string year = "yyyy";
            string D = "//";
            string G = "--";
            
            if (format.Contains(day))
            {
                format = format.Replace(day, "");
            }
            if (format.Contains(month))
            {
                format = format.Replace(month, "");
            }
            if (format.Contains(year))
            {
                format = format.Replace(year, "");
            }
            

            if (format.Contains(D))
            {
                format = format.Replace(D, "");
            }
            else if (format.Contains(G))
            {
                format = format.Replace(G, "");
            }

            if (format != "")
            {
                return false;
            }

            return true;

        }
    }
}
