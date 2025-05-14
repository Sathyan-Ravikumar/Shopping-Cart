using Dapper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserModule.Modal.DataAccess;
using UserModule.Repository.Repository_Interfaces;

namespace UserModule.Repository.Repositories
{

    public class StoredProcedures : IStoredProcedures
    {

        private readonly SqlServerConnection _connection;

        public StoredProcedures(SqlServerConnection config) 
        {
            _connection = config;
        }

        public async Task<T> ExecuteStoredProcedureAsync<T>(string storedProcedure,DynamicParameters parameters)
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
