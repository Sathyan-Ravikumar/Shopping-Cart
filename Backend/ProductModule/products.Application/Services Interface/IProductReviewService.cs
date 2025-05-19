using Products.View_Request_Modals.RequestModal;
using Products.View_Request_Modals.ViewModal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace products.Application.Services_Interface
{
    public interface IProductReviewService
    {
        Task<IEnumerable<ProductReviews_ViewModal>> GetReviewsByProductIdAsync(int productId);
        Task<bool> AddReviewAsync(AddProductReview request);
    }
}
