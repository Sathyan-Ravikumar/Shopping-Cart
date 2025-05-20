using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using products.Application.Services;
using products.Application.Services_Interface;
using Products.View_Request_Modals.RequestModal;
using Products.View_Request_Modals.ViewModal;

namespace Products_Module.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductServices _productServices;

        public ProductsController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        [HttpGet("subcategory/{subcategoryId}")]
        public async Task<IActionResult> GetProductsBySubcategory(int subcategoryId)
        {
            var products = await _productServices.GetProductsBySubcategoryAsync(subcategoryId);
            return Ok(products);
        }

        [HttpGet("product/{id}")]
        public async Task<IActionResult> GetProductById(int productId)
        {
            var product = await _productServices.GetProductByProductIdAsync(productId);
            if (product == null)
                return NotFound("Product not found");

            return Ok(product);
        }

        [HttpGet("active")]
        public async Task<ActionResult<List<AllActiveProducts>>> GetAllActiveProducts()
        {
            var products = await _productServices.GetAllActiveProductsAsync();
            return Ok(products);
        }

        [HttpGet("stock/{productId}")]
        public async Task<IActionResult> GetProductStock(int productId)
        {
            try
            {
                var stock = await _productServices.GetProductStockAsync(productId);
                return Ok(new { ProductId = productId, StockQuantity = stock });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Error fetching stock.", Details = ex.Message });
            }
        }
        [Authorize]
        [HttpPost("add")]
        public async Task<IActionResult> AddProduct([FromForm] AddNewProduct_RequestModal request)
        {
            if (!ModelState.IsValid || request.Images == null || !request.Images.Any())
                return BadRequest("Product data or images are missing.");

            try
            {
                var productId = await _productServices.AddProductAsync(request);
                return Ok(new { Message = "Product added successfully.", ProductId = productId });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Failed to add product.", Error = ex.Message });
            }
        }

    }
}
