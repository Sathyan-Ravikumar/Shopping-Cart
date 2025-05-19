using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using products.Application.Services_Interface;
using Products.View_Request_Modals.RequestModal;

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


        [Authorize]
        [HttpPost("add-review")]
        public async Task<IActionResult> AddReview([FromBody] AddProductReview request)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid input.");
            }

            var result = await _reviewService.AddReviewAsync(request);

            if (result)
            {
                return Ok(new { Message = "Review added successfully." });
            }
            else
            {
                return BadRequest(new { Message = "Failed to add review. Please check the input." });
            }

        }
    }
}

