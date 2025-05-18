using Products.Domain.RepositoryInterfaces;
using Products.Modal.Modal;


namespace Products.Domain.Repositories
{
    public class BrandsRepository : IBrands
    {
        private readonly IStoredProcedures _storedProcedures;
        public BrandsRepository(IStoredProcedures storedProcedures) 
        {
            _storedProcedures = storedProcedures;
        }

        public async Task<List<Brands>> GetBrandsAsync()
        {
            var spName = "sp_GetAllBrands";
            var brands = await _storedProcedures.ExecuteStoredProcedureListAsync<Brands>(spName);
            return brands.ToList();
        }

    }
}
