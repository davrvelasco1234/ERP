using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_HelperFile.Models
{
    public class DataConecction
    {

        public string DataSource { get; }
        public string InitialCatalog { get; }
        public string UserID { get; }
        public string Password { get; }
        public string ApplicationName { get; }


        internal DataConecction(string dataSource, string initialCatalog, string userID, string password, string applicationName)
        {
            this.DataSource = dataSource;
            this.InitialCatalog = initialCatalog;
            this.UserID = userID;
            this.Password = password;
            this.ApplicationName = applicationName;
        }

    }
}
