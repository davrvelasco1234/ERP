
using ERP_Entorno.Controllers;
using ERP_Entorno.Interfaces;


namespace ERP_Entorno
{


    public static class Entorno
    {
        public static IExecQuery ExecQuery { get; }
        public static IExecProperty GetProperty { get; }
        public static ISqlConnection SqlConnection { get; }

        static Entorno()
        {
            SqlConnection = new SqlConnectionString(ERP_Common.Helpers.Constantes.DB_DefaultConnection);
            ExecQuery = new ExecQuery(SqlConnection);
            GetProperty = new ExecProperty(SqlConnection);
        }
    }



    public class EntornoDynamic : IEntornoDynamic
    {
        public IExecQuery ExecQuery { get; }
        public IExecProperty GetProperty { get; }
        public ISqlConnection SqlConnection { get; }

        public EntornoDynamic(string IdConnectionString)
        {
            SqlConnection = new SqlConnectionString(IdConnectionString);
            ExecQuery = new ExecQuery(SqlConnection);
            GetProperty = new ExecProperty(SqlConnection);
        }
    }
}
