using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Domain.RepositoryInterfaces
{
    public interface IStoredProcedures
    {
        Task<T> ExecuteStoredProcedureAsync<T>(string storedProcedure, DynamicParameters parameters);
        Task<IEnumerable<T>> ExecuteStoredProcedureListAsync<T>(string storedProcedure, DynamicParameters parameters);
        Task<IEnumerable<T>> ExecuteStoredProcedureListAsync<T>(string storedProcedure);
        Task<(IEnumerable<T1>, IEnumerable<T2>)> ExecuteStoredProcedureMultiAsync<T1, T2>(string storedProcedure, DynamicParameters parameters);
        Task<int> ExecuteStoredProcedureNonQueryAsync(string storedProcedure, DynamicParameters parameters);
        Task<T> ExecuteStoredProcedureScalarAsync<T>(string storedProcedure, DynamicParameters parameters);
    }
}
