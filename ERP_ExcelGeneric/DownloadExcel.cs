using ERP_ExcelGeneric.Models;
using System.Collections.Generic;

namespace ERP_ExcelGeneric
{
    public static class MainDownloadExcel
    {

        public static bool Exec<TData>(IEnumerable<TData> datoslist, ConfigDownloadExcel config)
            => Controller.Download.Exec<TData>(datoslist, config);

        public static bool Exec<TData>(string path, IEnumerable<TData> datoslist, ConfigDownloadExcel config)
            => Controller.Download.Exec<TData>(path, datoslist, config);


    }
}
