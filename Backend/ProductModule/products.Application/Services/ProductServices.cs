using products.Application.Services_Interface;
using Products.Domain.Repositories;
using Products.Domain.RepositoryInterfaces;
using Products.View_Request_Modals.ViewModal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace products.Application.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepository _productRepository;

        public ProductServices(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductsBySubcategory>> GetProductsBySubcategoryAsync(int subcategoryId)
        {
            return await _productRepository.GetProductsBySubcategoryIdAsync(subcategoryId);
        }

        public async Task<ProductsByProductId> GetProductByProductIdAsync(int productId)
        {
            return await _productRepository.GetProductByIdAsync(productId);
        }
        public async Task<List<AllActiveProducts>> GetAllActiveProductsAsync()
        {
            var result = await _productRepository.GetAllActiveProductsAsync();
            return result.ToList(); 
        }
    }
}
