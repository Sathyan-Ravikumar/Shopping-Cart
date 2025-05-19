using Products.View_Request_Modals.RequestModal;
using Products.View_Request_Modals.ViewModal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Domain.RepositoryInterfaces
{
    public interface IProductReviewRepository
    {
        Task<IEnumerable<ProductReviews_ViewModal>> GetProductReviewsByProductId(int productId);
        Task<bool> AddReviewAsync(AddProductReview request);
    }
}
