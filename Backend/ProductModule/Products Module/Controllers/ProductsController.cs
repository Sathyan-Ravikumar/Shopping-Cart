using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using products.Application.Services;
using products.Application.Services_Interface;

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


    }
}
