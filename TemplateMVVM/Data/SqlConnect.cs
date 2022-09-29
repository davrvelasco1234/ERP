using System.Data.SqlClient;
using ERP_Entorno;

namespace TemplateMVVM.Data
{
    public class SqlConnect
    {
        protected static EntornoDynamic Connection;

        static SqlConnect()
        {
            Connection = new EntornoDynamic(GetConnectionString());
        }

        private static SqlConnectionStringBuilder GetConnectionString()
            => new SqlConnectionStringBuilder(Entorno.Conexion.ConnectionString.Replace("MultipleActiveResultSets", string.Format("Password={0};{1}", Entorno.Password, "MultipleActiveResultSets")));

        //private static SqlConnectionStringBuilder GetConnectionString()
        //    => new SqlConnectionStringBuilder()
        //    {
        //        DataSource = Entorno.ServidorActual,
        //        InitialCatalog = Entorno.BaseDatos,
        //        UserID = Entorno.Usuario,
        //        Password = Entorno.Password
        //    };
    }
}
