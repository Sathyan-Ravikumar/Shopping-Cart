using Dapper;
using Products.Domain.RepositoryInterfaces;
using Products.Modal.Modal;
using Products.View_Request_Modals.RequestModal;
using Products.View_Request_Modals.ViewModal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Domain.Repositories
{
    public class ProductReviewsRepository : IProductReviewRepository
    {
        private readonly IStoredProcedures _storedProcedures;
        public ProductReviewsRepository(IStoredProcedures storedProcedures)
        {
            _storedProcedures = storedProcedures;
        }

        public async Task<IEnumerable<ProductReviews_ViewModal>> GetProductReviewsByProductId(int productId)
        {
            var spName = "sp_GetReviewsByProductId";
            var parameter = new DynamicParameters();
            parameter.Add("@ProductId", productId);
            var review = await _storedProcedures.ExecuteStoredProcedureListAsync<ProductReviews_ViewModal>(spName, parameter);
            return review;
        }

        public async Task<bool> AddReviewAsync(AddProductReview request)
        {
            var spName = "sp_AddProductReview";
            var parameters = new DynamicParameters();
            parameters.Add("UserId", request.UserId);
            parameters.Add("ProductId", request.ProductId);
            parameters.Add("Rating", request.Rating);
            parameters.Add("ReviewText", request.ReviewText);

            var result = await _storedProcedures.ExecuteStoredProcedureNonQueryAsync(spName, parameters);
            return result > 0;
        }

    }
}
