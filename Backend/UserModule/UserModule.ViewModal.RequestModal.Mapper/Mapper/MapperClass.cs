using AutoMapper;
using User_Module.Modal;
using UserModule.ViewModal.RequestModal.Mapper.Request_Modal;

namespace UserModule.ViewModal.RequestModal.Mapper.Mapper
{
    public class MapperClass : Profile
    {
        public MapperClass()
        {
            CreateMap<User, User_Register>().ReverseMap();
        }
    }
}
