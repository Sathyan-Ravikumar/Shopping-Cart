using Products.View_Request_Modals.ViewModal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Domain.RepositoryInterfaces
{
    public interface IProductRepository
    {
        Task<List<ProductsBySubcategory>> GetProductsBySubcategoryIdAsync(int subcategoryId);
        Task<ProductsByProductId> GetProductByIdAsync(int productId);
        Task<IEnumerable<AllActiveProducts>> GetAllActiveProductsAsync();
        Task<int> GetProductStockAsync(int productId);
    }
}
