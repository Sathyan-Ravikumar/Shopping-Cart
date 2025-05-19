using AutoMapper;
using products.Application.Services_Interface;
using Products.Domain.RepositoryInterfaces;
using Products.Modal.Modal;
using Products.View_Request_Modals.ViewModal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace products.Application.Services
{
    public class SubcategoryService : ISubcategoryService
    {
        private readonly ISubcategoryRepository _subcategoryRepository;
        private readonly IMapper _mapper;

        public SubcategoryService(ISubcategoryRepository subcategoryRepository,IMapper mapper)
        {
            _subcategoryRepository = subcategoryRepository;
            _mapper = mapper;
        }

        public async Task<List<Subcategory_ViewModal>> GetSubcategoriesByCategoryId(int categoryId)
        {
            var subCategories = await _subcategoryRepository.GetSubCategoriesByCategoryID(categoryId);
            var result = _mapper.Map<List<Subcategory_ViewModal>>(subCategories);

            return result;
        }
    }
}
