
using System.Data.SqlClient;
using ERP_Entorno.Interfaces;

namespace ERP_Entorno.Controllers
{
    internal class SqlConnectionString : ISqlConnection
    {
        public  string DataSource { get; }
        public  string InitialCatalog { get; }
        public  string UserID { get; }
        public  string Password { get; }
        public  string ApplicationName { get; }
        public  string ConnectionString { get; }

        public SqlConnectionString(string IdCadena)
        {
            this.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings[IdCadena].ConnectionString;

            var conn = new SqlConnectionStringBuilder(this.ConnectionString);
            this.DataSource = conn.DataSource;
            this.InitialCatalog = conn.InitialCatalog;
            this.UserID = conn.UserID;
            this.Password = conn.Password;
            this.ApplicationName = conn.ApplicationName;
        }


    }
}
