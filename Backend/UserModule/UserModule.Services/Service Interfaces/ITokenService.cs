using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserModule.ViewModal.RequestModal.Mapper.View_Modal;

namespace UserModule.Services.Service_Interfaces
{
    public interface ITokenService
    {
        JwtToken GenerateToken(GetUserDetails userDetails);
    }
}
