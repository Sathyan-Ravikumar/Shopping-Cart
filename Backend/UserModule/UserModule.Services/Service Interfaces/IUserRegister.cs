using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserModule.ViewModal.RequestModal.Mapper.Request_Modal;

namespace UserModule.Services.Service_Interfaces
{
    public interface IUserRegister
    {
        Task<User_Register> UserRegisterAsync(User_Register user);
    }
}
