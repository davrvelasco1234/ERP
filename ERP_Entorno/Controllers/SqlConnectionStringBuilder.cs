using System.Data.SqlClient;
using ERP_Entorno.Interfaces;
using ERP_HelperFile.Models;

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

            var sqlConnection = new SqlConnectionStringBuilder(this.ConnectionString);
            this.DataSource = sqlConnection.DataSource;
            this.InitialCatalog = sqlConnection.InitialCatalog;
            this.UserID = sqlConnection.UserID;
            this.Password = sqlConnection.Password;
            this.ApplicationName = sqlConnection.ApplicationName;
        }

        public SqlConnectionString(SqlConnectionStringBuilder sqlConnection)
        {
            this.ConnectionString = sqlConnection.ConnectionString;
            this.DataSource = sqlConnection.DataSource;
            this.InitialCatalog = sqlConnection.InitialCatalog;
            this.UserID = sqlConnection.UserID;
            this.Password = sqlConnection.Password;
            this.ApplicationName = sqlConnection.ApplicationName;
        }


        public SqlConnectionString(DataConecction dc)
        {
            var conn = new SqlConnectionStringBuilder
            {
                DataSource = dc.DataSource,
                InitialCatalog = dc.InitialCatalog,
                UserID = dc.UserID,
                Password = dc.Password
            };
            this.ConnectionString = conn.ConnectionString;
            this.DataSource = dc.DataSource;
            this.InitialCatalog = dc.InitialCatalog;
            this.UserID = dc.UserID;
            this.Password = dc.Password;
            this.ApplicationName = dc.ApplicationName;
        }
    }
}
