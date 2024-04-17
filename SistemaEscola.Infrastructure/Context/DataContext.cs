using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SistemaEscola.Infrastructure.Interfaces.Contexts;
using System.Data;
using System.Data.Common;

namespace SistemaEscola.Infrastructure.Context
{
    public class DataContext : IDataContext
    {
        private readonly IConfiguration _config;
        private readonly string _connectionString = "DefaultConnection";
        private readonly int _commandTimeout = 120;

        public DataContext(IConfiguration config)
        {
            _config = config;
        }

        public T? Get<T>(string sp, DynamicParameters? parms, CommandType commandType = CommandType.Text)
        {
            using var db = GetDbconnection();
            var commandDefinition = new CommandDefinition(sp, parms, commandType: commandType, commandTimeout: _commandTimeout);
            return db.Query<T>(commandDefinition).FirstOrDefault();
        }

        public async Task<T> GetAsync<T>(string sp, DynamicParameters? parms = default, CommandType commandType = CommandType.Text)
        {
            using var db = GetDbconnection();
            var commandDefinition = new CommandDefinition(sp, parms, commandType: commandType, commandTimeout: _commandTimeout);
            return await db.QuerySingleOrDefaultAsync<T>(commandDefinition);
        }

        public List<T> GetAll<T>(string sp, DynamicParameters? parms = default, CommandType commandType = CommandType.Text)
        {
            using var db = GetDbconnection();
            var commandDefinition = new CommandDefinition(sp, parms, commandType: commandType, commandTimeout: _commandTimeout);
            return db.Query<T>(commandDefinition).ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(string sp, DynamicParameters? parms = default, CommandType commandType = CommandType.Text)
        {
            using var db = GetDbconnection();
            var commandDefinition = new CommandDefinition(sp, parms, commandType: commandType, commandTimeout: _commandTimeout);
            return await db.QueryAsync<T>(commandDefinition);
        }

        public async Task<bool> ExecuteAsync(string sql, DynamicParameters parameters = null, CommandType commandType = CommandType.Text)
        {
            using var db = GetDbconnection();
            var commandDefinition = new CommandDefinition(sql, parameters, commandType: commandType, commandTimeout: _commandTimeout);

            try
            {
                int rowsAffected = await db.ExecuteAsync(commandDefinition);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public DbConnection GetDbconnection()
        {
            return new SqlConnection(_config.GetConnectionString(_connectionString));
        }

        public void Dispose()
        {
        }
    }
}