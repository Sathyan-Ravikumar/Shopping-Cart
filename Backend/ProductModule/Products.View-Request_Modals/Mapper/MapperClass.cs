using AutoMapper;
using Products.Modal.Modal;
using Products.View_Request_Modals.ViewModal;

namespace Products.View_Request_Modals.Mapper
{
    public class MapperClass : Profile
    {
        public MapperClass()
        {
            CreateMap<Brands_ViewModal,Brands>().ReverseMap();
            CreateMap<Subcategory_ViewModal,SubCategories>().ReverseMap();
        }
    }
}
