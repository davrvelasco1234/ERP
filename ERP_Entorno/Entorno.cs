using ERP_Entorno.Controllers;
using ERP_Entorno.Interfaces;
using System.Data.SqlClient;

namespace ERP_Entorno
{


    public static class Entorno
    {
        public static ISqlConnection SqlConnection { get; private set; }
        public static IExecQuery ExecQuery { get; private set; }
        public static IExecProperty GetProperty { get; private set; }

        private static SqlConnection SqlConn { get; set; }
        /*
        static Entorno()
        {
            SqlConnection = new SqlConnectionString(ERP_HelperFile.Controller.GetConfigCon());
            ExecQuery = new ExecQuery(SqlConnection);
            GetProperty = new ExecProperty(SqlConnection);
        }
        */
        public static void Initilize(SqlConnection conn, string pass)
        {
            SqlConnection = new SqlConnectionString(new SqlConnectionStringBuilder(Conexion(conn, pass))); 
            ExecQuery = new ExecQuery(SqlConnection);
            GetProperty = new ExecProperty(SqlConnection);
        }

        private static string Conexion(SqlConnection conn, string pass)
        {
            return conn.ConnectionString.Replace("MultipleActiveResultSets", string.Format("Password={0};{1}", pass, "MultipleActiveResultSets"));
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
