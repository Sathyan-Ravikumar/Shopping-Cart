using AutoMapper;
using Products.Modal.Modal;
using Products.View_Request_Modals.ViewModal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.View_Request_Modals.Mapper
{
    public class MapperClass : Profile
    {
        public MapperClass()
        {
            CreateMap<Brands_ViewModal,Brands>().ReverseMap();
        }
    }
}
