using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using products.Application.Services_Interface;
using Products.View_Request_Modals.ViewModal;

namespace Products_Module.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Brands_ViewModal>>> GetAllBrands()
        {
            var result = await _brandService.GetAllBrands();
            return Ok(result);
        }
    }
}
