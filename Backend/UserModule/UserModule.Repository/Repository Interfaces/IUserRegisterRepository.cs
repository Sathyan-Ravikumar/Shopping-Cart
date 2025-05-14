using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User_Module.Modal;

namespace UserModule.Repository.Repository_Interfaces
{
    public interface IUserRegisterRepository
    {
        Task<User> AddNewUser(User userDetials);

    }
}
