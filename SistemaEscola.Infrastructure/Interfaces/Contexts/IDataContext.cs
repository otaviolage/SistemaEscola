using Dapper;
using System.Data;
using System.Data.Common;

namespace SistemaEscola.Infrastructure.Interfaces.Contexts
{
    public interface IDataContext : IDisposable
    {
        DbConnection GetDbconnection();
        T? Get<T>(string sp, DynamicParameters? parms = default, CommandType commandType = CommandType.Text);
        Task<T> GetAsync<T>(string sp, DynamicParameters? parms = default, CommandType commandType = CommandType.Text);
        List<T> GetAll<T>(string sp, DynamicParameters? parms = default, CommandType commandType = CommandType.Text);
        Task<IEnumerable<T>> GetAllAsync<T>(string sp, DynamicParameters? parms, CommandType commandType = CommandType.Text);
        Task<bool> ExecuteAsync(string sql, DynamicParameters parameters = null, CommandType commandType = CommandType.Text);
    }
}