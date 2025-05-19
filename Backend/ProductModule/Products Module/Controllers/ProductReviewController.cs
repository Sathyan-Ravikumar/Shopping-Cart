using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using products.Application.Services_Interface;

namespace Products_Module.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductReviewController : ControllerBase
    {

        private readonly IProductReviewService _reviewService;
        public ProductReviewController(IProductReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetReviewsByProductId(int productId)
        {
            var reviews = await _reviewService.GetReviewsByProductIdAsync(productId);
            return Ok(reviews);
        }
    }
}
