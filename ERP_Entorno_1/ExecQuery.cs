


using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;



namespace ERP_Entorno
{
    public class ExecQuery
    {
        private static SqlConnectionStringBuilder Connection;

        static ExecQuery()
        {
            Connection = SqlConnectionString.GetString();
        }

        //Scalar
        public static T ExecuteScalar<T>(string query)
        {
            using (var connection = new SqlConnection(Connection.ConnectionString))
            {
                return connection.ExecuteScalar<T>(query);
            }
        }

        public static async Task<T> ExecuteScalarAsync<T>(string query)
        {
            using (var connection = new SqlConnection(Connection.ConnectionString))
            {
                return await connection.ExecuteScalarAsync<T>(query);
            }
        }


        //Single
        public static T QuerySingle<T>(string query, object param = null)
        {
            var sAttr = System.Configuration.ConfigurationManager.AppSettings.Get("Key0");

            using (var connection = new SqlConnection(Connection.ConnectionString))
            {
                return connection.QuerySingle<T>(query, param);
            }
        }

        public static async Task<T> QuerySingleAsync<T>(string query)
        {
            using (var connection = new SqlConnection(Connection.ConnectionString))
            {
                return await connection.QuerySingleAsync<T>(query);
            }
        }




        //Single or default
        public static T QuerySingleOrDefault<T>(string query)
        {
            using (var connection = new SqlConnection(Connection.ConnectionString))
            {
                return connection.QuerySingleOrDefault<T>(query);
            }
        }

        public static async Task<T> QuerySingleOrDefaultAsync<T>(string query)
        {
            using (var connection = new SqlConnection(Connection.ConnectionString))
            {
                return await connection.QuerySingleOrDefaultAsync<T>(query);
            }
        }


        //First
        public static T QueryFirst<T>(string query)
        {
            using (var connection = new SqlConnection(Connection.ConnectionString))
            {
                return connection.QueryFirst<T>(query);
            }
        }

        public static async Task<T> QueryFirstAsync<T>(string query)
        {
            using (var connection = new SqlConnection(Connection.ConnectionString))
            {
                return await connection.QueryFirstAsync<T>(query);
            }
        }

        //First or default
        public static T QueryFirstOrDefault<T>(string query)
        {
            using (var connection = new SqlConnection(Connection.ConnectionString))
            {
                return connection.QueryFirstOrDefault<T>(query);
            }
        }

        public static async Task<T> QueryFirstOrDefaultAsync<T>(string query)
        {
            using (var connection = new SqlConnection(Connection.ConnectionString))
            {
                
                return await connection.QueryFirstOrDefaultAsync<T>(query);
            }
        }



        //Query
        public static IEnumerable<T> Query<T>(string query)
        {
            using (var connection = new SqlConnection(Connection.ConnectionString))
            {
                return connection.Query<T>(query);
            }
        }

        public static async Task<IEnumerable<T>> QueryAsync<T>(string query)
        {
            using (var connection = new SqlConnection(Connection.ConnectionString))
            {
                return await connection.QueryAsync<T>(query);
            }
        }


        //Execute
        public static int Execute(string query)
        {
            using (var connection = new SqlConnection(Connection.ConnectionString))
            {
                return connection.Execute(query);
            }
        }

        public static Task<int> ExecuteAsync(string query)
        {
            using (var connection = new SqlConnection(Connection.ConnectionString))
            {
                return connection.ExecuteAsync(query);
            }
        }


    }
}
