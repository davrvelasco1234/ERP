using ERP_Entorno.Controllers;
using ERP_Entorno.Interfaces;
using System.Data.SqlClient;

namespace ERP_Entorno
{


    public static class Entorno
    {
        public static ISqlConnection SqlConnection { get; }
        public static IExecQuery ExecQuery { get; }
        public static IExecProperty GetProperty { get; }

        static Entorno()
        {
            SqlConnection = new SqlConnectionString(ERP_HelperFile.Controller.GetConfigCon());
            ExecQuery = new ExecQuery(SqlConnection);
            GetProperty = new ExecProperty(SqlConnection);
        }
    }



    public class EntornoDynamic : IEntornoDynamic
    {
        public ISqlConnection SqlConnection { get; }

        public IExecQuery ExecQuery { get; }
        public IExecProperty GetProperty { get; }

        public EntornoDynamic(string IdConnectionString)
        {
            SqlConnection = new SqlConnectionString(IdConnectionString);

            ExecQuery = new ExecQuery(SqlConnection);
            GetProperty = new ExecProperty(SqlConnection);
            
        }

        public EntornoDynamic(SqlConnectionStringBuilder sqlConnection)
        {
            SqlConnection = new SqlConnectionString(sqlConnection);

            ExecQuery = new ExecQuery(SqlConnection);
            GetProperty = new ExecProperty(SqlConnection);
        }

    }
}
