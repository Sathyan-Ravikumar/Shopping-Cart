using products.Application.Services_Interface;
using Products.Domain.Repositories;
using Products.Domain.RepositoryInterfaces;
using Products.View_Request_Modals.RequestModal;
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
        private readonly IBlobService _blobService;

        public ProductServices(IProductRepository productRepository, IBlobService blobService)
        {
            _productRepository = productRepository;
            _blobService = blobService;
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
        public async Task<int> GetProductStockAsync(int productId)
        {
            return await _productRepository.GetProductStockAsync(productId);
        }

        public async Task<int> AddProductAsync(AddNewProduct_RequestModal request)
        {
            var imageInfos = new List<(string url, bool isPrimary)>();

            // Check: Only one image should be marked as primary
            if (request.Images.Count(img => img.IsPrimary) != 1)
                throw new ArgumentException("Exactly one image must be marked as primary.");

            foreach (var img in request.Images)
            {
                var url = await _blobService.UploadImageAsync(img.ImageFile);
                imageInfos.Add((url, img.IsPrimary));
            }

            return await _productRepository.AddProductWithImagesAsync(request, imageInfos);
        }


    }
}
