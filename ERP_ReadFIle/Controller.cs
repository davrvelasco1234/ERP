
using ERP_HelperFile.Models;

namespace ERP_HelperFile
{
    public class Controller
    {
        public static string ReadKey(string seccion, string att, string valDef, string file)
            => Files.KeyFile.ReadKey(seccion, att, valDef, file);


        public static DataConecction GetConfigCon()
            => Files.ConnFile.GetConfigCon();
    }
}
