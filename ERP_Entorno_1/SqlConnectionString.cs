using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ERP_Entorno
{
    internal class SqlConnectionString
    {

        public static SqlConnectionStringBuilder GetString()
            =>  new SqlConnectionStringBuilder()
                {
                    DataSource = "DESKTOP-5O3N9PO",
                    InitialCatalog = "ERP",
                    UserID = "uspruebas",
                    Password = "pruebas",
                    ApplicationName = "ERP_AppDesktop"
                };
        



    }
}
