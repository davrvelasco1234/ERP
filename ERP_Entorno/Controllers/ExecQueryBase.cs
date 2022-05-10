using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using ERP_Entorno.Interfaces;
using Dapper;


namespace ERP_Entorno.Controllers
{
    internal static class ExecQueryBase
    {
        //Scalar
        public static T ExecuteScalar<T>(string query, object param, string ConnectionString)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                return connection.ExecuteScalar<T>(query, param);
            }
        }

        public static async Task<T> ExecuteScalarAsync<T>(string query, object param, string ConnectionString)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                return await connection.ExecuteScalarAsync<T>(query, param);
            }
        }


        //Single
        public static T QuerySingle<T>(string query, object param, string ConnectionString)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                return connection.QuerySingle<T>(query, param);
            }
        }

        public static async Task<T> QuerySingleAsync<T>(string query, object param, string ConnectionString)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                return await connection.QuerySingleAsync<T>(query, param);
            }
        }


        //Single or default
        public static T QuerySingleOrDefault<T>(string query, object param, string ConnectionString)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                return connection.QuerySingleOrDefault<T>(query, param);
            }
        }

        public static async Task<T> QuerySingleOrDefaultAsync<T>(string query, object param, string ConnectionString)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                return await connection.QuerySingleOrDefaultAsync<T>(query, param);
            }
        }


        //First
        public static T QueryFirst<T>(string query, object param, string ConnectionString)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                return connection.QueryFirst<T>(query, param);
            }
        }

        public static async Task<T> QueryFirstAsync<T>(string query, object param, string ConnectionString)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                return await connection.QueryFirstAsync<T>(query, param);
            }
        }


        //First or default
        public static T QueryFirstOrDefault<T>(string query, object param, string ConnectionString)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                return connection.QueryFirstOrDefault<T>(query, param);
            }
        }

        public static async Task<T> QueryFirstOrDefaultAsync<T>(string query, object param, string ConnectionString)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                return await connection.QueryFirstOrDefaultAsync<T>(query, param);
            }
        }


        //Query
        public static IEnumerable<T> Query<T>(string query, object param, string ConnectionString)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                return connection.Query<T>(query, param);
            }
        }

        public static async Task<IEnumerable<T>> QueryAsync<T>(string query, object param, string ConnectionString)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                return await connection.QueryAsync<T>(query, param);
            }
        }


        //Execute
        public static int Execute(string query, object param, string ConnectionString)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                return connection.Execute(query, param);
            }
        }

        public static async Task<int> ExecuteAsync(string query, object param, string ConnectionString)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                return await connection.ExecuteAsync(query, param);
            }
        }

    }
}
