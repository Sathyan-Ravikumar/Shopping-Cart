using Dapper;
using Products.Domain.RepositoryInterfaces;
using Products.Modal.Modal;
using Products.View_Request_Modals.RequestModal;
using Products.View_Request_Modals.ViewModal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Domain.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IStoredProcedures _storedProcedure;

        public ProductRepository(IStoredProcedures storedProcedure)
        {
            _storedProcedure = storedProcedure;
        }

        public async Task<List<ProductsBySubcategory>> GetProductsBySubcategoryIdAsync(int subcategoryId)
        {
            var spName = "sp_GetProductsBySubcategoryId";
            var parameter = new DynamicParameters();
            parameter.Add("SubcategoryId", subcategoryId);

            var (productsResult, images) = await _storedProcedure.ExecuteStoredProcedureMultiAsync<ProductsBySubcategory, ProductImages_ViewModal>(spName, parameter);

            var products = productsResult.ToList();

            foreach (var product in products)
            {
                product.PrimaryImage = images
                    .Where(img => img.ProductId == product.ProductId && img.IsPrimary)
                    .ToList();
            }

            return products;
        }
        public async Task<ProductsByProductId> GetProductByIdAsync(int productId)
        {
            var spName = "sp_GetProductByProductId";
            var parameters = new DynamicParameters();
            parameters.Add("ProductId", productId);

            var (productResult, images) = await _storedProcedure.ExecuteStoredProcedureMultiAsync<ProductsByProductId, ProductImages_ViewModal>(spName, parameters);

            var product = productResult.FirstOrDefault();

            if (product != null)
            {
                product.Images = images.Where(img => img.ImageUrl != null).ToList();
            }

            return product;
        }
        public async Task<IEnumerable<AllActiveProducts>> GetAllActiveProductsAsync()
        {
            var spName = "sp_GetAllActiveProducts";
            return await _storedProcedure.ExecuteStoredProcedureListAsync<AllActiveProducts>(spName);
        }
        public async Task<int> GetProductStockAsync(int productId)
        {
            var spName = "sp_GetProductStock";
            var parameters = new DynamicParameters();
            parameters.Add("ProductId", productId);

            return await _storedProcedure.ExecuteStoredProcedureAsync<int>(spName, parameters);
        }

        public async Task<int> AddProductWithImagesAsync(AddNewProduct_RequestModal request, List<(string url, bool isPrimary)> imageInfos)
        {
            var spName = "sp_AddProductWithImagesAndInventoryLog";

            var parameters = new DynamicParameters();
            parameters.Add("Name", request.Name);
            parameters.Add("Description", request.Description);
            parameters.Add("Price", request.Price);
            parameters.Add("StockQuantity", request.StockQuantity);
            parameters.Add("IsActive", request.IsActive);
            parameters.Add("BrandId", request.BrandId);
            parameters.Add("SubcategoryId", request.SubcategoryId);
            parameters.Add("CreatedAt", DateTime.UtcNow);

            var table = new DataTable();
            table.Columns.Add("ImageUrl", typeof(string));
            table.Columns.Add("IsPrimary", typeof(bool));
            table.Columns.Add("CreatedAt", typeof(DateTime));

            foreach (var image in imageInfos)
            {
                table.Rows.Add(image.url, image.isPrimary, DateTime.UtcNow);
            }

            parameters.Add("Images", table.AsTableValuedParameter("ProductImageType"));

            
            return await _storedProcedure.ExecuteStoredProcedureScalarAsync<int>(spName, parameters);
            
        }

    }
}
