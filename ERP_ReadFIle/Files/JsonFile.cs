using System.IO;
using Newtonsoft.Json;


namespace ERP_HelperFile.Files
{
    public class JsonFile
    {
        public static T ReadFileJson<T>(string pathFile)
        {
            using (StreamReader jsonStream = File.OpenText(pathFile))
            {
                var json = jsonStream.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(json);
            }
        }

        public static string SerializeObjectJson(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static void WriteFileJson(object obj, string pathFile)
        {
            string json = SerializeObjectJson(obj);
            File.WriteAllText(pathFile, json);
        }



    }
}



