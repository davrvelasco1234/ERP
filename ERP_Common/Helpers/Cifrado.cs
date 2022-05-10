

using System;


namespace ERP_Common.Helpers
{
    public static class Cifrado
    {
        public static T GetInstance<T>()
        {
            if (typeof(T).IsValueType)
            {
                return default(T);
            }
            else if (typeof(T) == typeof(String))
            {
                return (T)Convert.ChangeType(String.Empty, typeof(T));
            }
            else
            {
                return Activator.CreateInstance<T>();
            }
        }


        public static string Base64_Encode(string cadena)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(cadena);
            return Convert.ToBase64String(bytes);
        }


        public static string Base64_Decode(string cadena)
        {
            try
            {
                byte[] bytes = Convert.FromBase64String(cadena);
                return System.Text.Encoding.UTF8.GetString(bytes);
            }
            catch
            {
                return "";
            }
        }
    }
}
