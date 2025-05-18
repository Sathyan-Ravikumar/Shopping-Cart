using Products.Modal.Modal;

namespace Products.Domain.RepositoryInterfaces
{
    public interface IBrands
    {
        Task<List<Brands>> GetBrandsAsync();
    }
}
