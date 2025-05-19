using Dapper;
using Products.Domain.RepositoryInterfaces;
using Products.Modal.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Products.Domain.Repositories
{
    public class SubcategoryRepository : ISubcategoryRepository
    {
        private readonly IStoredProcedures _storedProcedure;

        public SubcategoryRepository(IStoredProcedures storedProcedure)
        {
            _storedProcedure = storedProcedure;
        }

        public async Task<List<SubCategories>> GetSubCategoriesByCategoryID(int categoryID)
        {
            var spName = "sp_GetSubcategoriesByCategoryId";
            var parameter = new DynamicParameters();
            parameter.Add("@CategoryId", categoryID);
            var subCategory = await _storedProcedure.ExecuteStoredProcedureListAsync<SubCategories>(spName,parameter);
            return subCategory.ToList();
        }
    }
}
