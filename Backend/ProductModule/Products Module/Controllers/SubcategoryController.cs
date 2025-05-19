using Microsoft.AspNetCore.Mvc;
using products.Application.Services_Interface;
using Products.View_Request_Modals.ViewModal;

namespace Products_Module.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubcategoryController : ControllerBase
    {
        private readonly ISubcategoryService _subcategoryService;

        public SubcategoryController(ISubcategoryService subcategoryService)
        {
            _subcategoryService = subcategoryService;
        }

        [HttpGet]
        public async Task<List<Subcategory_ViewModal>> GetSubcategoriesByCategoryId(int categoryId)
        {
            var subCategory = await _subcategoryService.GetSubcategoriesByCategoryId(categoryId);
            return subCategory;
        }
    }
}
