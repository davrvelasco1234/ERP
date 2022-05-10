
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using ERP_Entorno.Interfaces;
using Dapper;


namespace ERP_Entorno.Controllers
{
    internal class ExecQuery : IExecQuery
    {
        private ISqlConnection SqlConnection;

        public ExecQuery(ISqlConnection sqlConnection)
        {
            this.SqlConnection = sqlConnection;
        }

        //Scalar
        public T ExecuteScalar<T>(string query, object param)
            => ExecQueryBase.ExecuteScalar<T>(query, param, this.SqlConnection.ConnectionString);

        public async Task<T> ExecuteScalarAsync<T>(string query, object param)
            => await ExecQueryBase.ExecuteScalarAsync<T>(query, param, this.SqlConnection.ConnectionString);


        //Single
        public T QuerySingle<T>(string query, object param)
            => ExecQueryBase.QuerySingle<T>(query, param, this.SqlConnection.ConnectionString);

        public async Task<T> QuerySingleAsync<T>(string query, object param)
            => await ExecQueryBase.QuerySingleAsync<T>(query, param, this.SqlConnection.ConnectionString);


        //Single or default
        public T QuerySingleOrDefault<T>(string query, object param)
            => ExecQueryBase.QuerySingleOrDefault<T>(query, param, this.SqlConnection.ConnectionString);

        public async Task<T> QuerySingleOrDefaultAsync<T>(string query, object param)
            => await ExecQueryBase.QuerySingleOrDefaultAsync<T>(query, param, this.SqlConnection.ConnectionString);


        //First
        public T QueryFirst<T>(string query, object param)
            => ExecQueryBase.QueryFirst<T>(query, param, this.SqlConnection.ConnectionString);

        public async Task<T> QueryFirstAsync<T>(string query, object param)
            => await ExecQueryBase.QueryFirstAsync<T>(query, param, this.SqlConnection.ConnectionString);


        //First or default
        public T QueryFirstOrDefault<T>(string query, object param)
            => ExecQueryBase.QueryFirstOrDefault<T>(query, param, this.SqlConnection.ConnectionString);

        public async Task<T> QueryFirstOrDefaultAsync<T>(string query, object param)
            => await ExecQueryBase.QueryFirstOrDefaultAsync<T>(query, param, this.SqlConnection.ConnectionString);


        //Query
        public IEnumerable<T> Query<T>(string query, object param)
            => ExecQueryBase.Query<T>(query, param, this.SqlConnection.ConnectionString);

        public async Task<IEnumerable<T>> QueryAsync<T>(string query, object param)
            => await ExecQueryBase.QueryAsync<T>(query, param, this.SqlConnection.ConnectionString);


        //Execute
        public int Execute(string query, object param)
            => ExecQueryBase.Execute(query, param, this.SqlConnection.ConnectionString);

        public async Task<int> ExecuteAsync(string query, object param)
            => await ExecQueryBase.ExecuteAsync(query, param, this.SqlConnection.ConnectionString);


    }
}
