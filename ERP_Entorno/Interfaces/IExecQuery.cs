using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP_Entorno.Interfaces
{
    public interface IExecQuery
    {
        //Scalar
        T ExecuteScalar<T>(string query, object param);
        Task<T> ExecuteScalarAsync<T>(string query, object param);


        //Single
        T QuerySingle<T>(string query, object param);
        Task<T> QuerySingleAsync<T>(string query, object param);


        //Single or default
        T QuerySingleOrDefault<T>(string query, object param);
        Task<T> QuerySingleOrDefaultAsync<T>(string query, object param);


        //First
        T QueryFirst<T>(string query, object param);
        Task<T> QueryFirstAsync<T>(string query, object param);


        //First or default
        T QueryFirstOrDefault<T>(string query, object param);
        Task<T> QueryFirstOrDefaultAsync<T>(string query, object param);


        //Query
        IEnumerable<T> Query<T>(string query, object param);
        Task<IEnumerable<T>> QueryAsync<T>(string query, object param);


        //Execute
        int Execute(string query, object param);
        Task<int> ExecuteAsync(string query, object param);
    }
}
