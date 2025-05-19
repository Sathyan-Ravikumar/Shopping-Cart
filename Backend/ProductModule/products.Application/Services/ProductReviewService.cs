using products.Application.Services_Interface;
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
    public class ProductReviewService : IProductReviewService
    {
        private readonly IProductReviewRepository _productReviewRepository;

        public ProductReviewService(IProductReviewRepository productReviewRepository)
        {
            _productReviewRepository = productReviewRepository;
        }

        public async Task<IEnumerable<ProductReviews_ViewModal>> GetReviewsByProductIdAsync(int productId)
        {
            return await _productReviewRepository.GetProductReviewsByProductId(productId);
        }
        public async Task<bool> AddReviewAsync(AddProductReview request)
        {
            if (request == null || request.UserId <= 0 || request.ProductId <= 0 || request.Rating < 1 || request.Rating > 5)
            {
                return false;
            }

            return await _productReviewRepository.AddReviewAsync(request);
        }
    }
}
