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
        public async Task<IEnumerable<T>> ExecuteStoredProcedureListAsync<T>(string storedProcedure)
        {
            using (var connection = _connection.CreateConnection())
            {
                return await connection.QueryAsync<T>(
                    storedProcedure,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<(IEnumerable<T1>, IEnumerable<T2>)> ExecuteStoredProcedureMultiAsync<T1, T2>(string storedProcedure, DynamicParameters parameters)
        {
            using (var connection = _connection.CreateConnection())
            {
                using var multi = await connection.QueryMultipleAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);

                var result1 = await multi.ReadAsync<T1>();
                var result2 = await multi.ReadAsync<T2>();

                return (result1, result2);
            }
        }

        public async Task<int> ExecuteStoredProcedureNonQueryAsync(string storedProcedure, DynamicParameters parameters)
        {
            using (var connection = _connection.CreateConnection())
            {
                return await connection.ExecuteAsync(
                    storedProcedure,
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }
        public async Task<T> ExecuteStoredProcedureScalarAsync<T>(string storedProcedure, DynamicParameters parameters)
        {
            using (var connection = _connection.CreateConnection())
            {
                return await connection.ExecuteScalarAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }



    }
}
