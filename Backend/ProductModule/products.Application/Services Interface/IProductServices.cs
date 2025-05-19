using Products.View_Request_Modals.ViewModal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace products.Application.Services_Interface
{
    public interface IProductServices
    {
        Task<List<ProductsBySubcategory>> GetProductsBySubcategoryAsync(int subcategoryId);
        Task<ProductsByProductId> GetProductByProductIdAsync(int productId);
        Task<List<AllActiveProducts>> GetAllActiveProductsAsync();
        Task<int> GetProductStockAsync(int productId);
    }
}
