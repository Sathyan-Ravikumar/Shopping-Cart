using Dapper;
using Products.Domain.RepositoryInterfaces;
using Products.Modal.DataAccess;
using System.Data;

namespace Products.Domain.Repositories
{
    public class StoredProcedures : IStoredProcedures
    {
        private readonly SqlServerConnection _connection;

        public StoredProcedures(SqlServerConnection config)
        {
            _connection = config;
        }

        public async Task<T> ExecuteStoredProcedureAsync<T>(string storedProcedure, DynamicParameters parameters)
        {
            using (var connection = _connection.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<T>(
                    storedProcedure,
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }


        public async Task<IEnumerable<T>> ExecuteStoredProcedureListAsync<T>(string storedProcedure, DynamicParameters parameters)
        {
            using (var connection = _connection.CreateConnection())
            {
                return await connection.QueryAsync<T>(
                storedProcedure,
                parameters,
                commandType: CommandType.StoredProcedure);
            }
        }
    }
}
