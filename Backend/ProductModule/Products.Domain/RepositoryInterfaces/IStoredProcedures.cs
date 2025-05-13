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
    }
}
