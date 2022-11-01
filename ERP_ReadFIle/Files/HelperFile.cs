
using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace ERP_HelperFile.Files
{
    public class HelperFile
    {
        public static bool ExistFile(string pathFile)
            => File.Exists(pathFile);

    }
}


