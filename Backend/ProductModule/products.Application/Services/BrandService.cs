using AutoMapper;
using products.Application.Services_Interface;
using Products.Domain.RepositoryInterfaces;
using Products.View_Request_Modals.ViewModal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace products.Application.Services
{
    public class BrandService : IBrandService
    {
        private readonly IBrands  _brands;
        private readonly IMapper _mapper;
        public BrandService(IBrands brands,IMapper mapper)
        {
            _brands = brands;
            _mapper = mapper;
        }

        public async Task<List<Brands_ViewModal>> GetAllBrands()
        {
            var brand = await _brands.GetBrandsAsync();
            return  _mapper.Map<List<Brands_ViewModal>>(brand);
            
        }
    }
}
