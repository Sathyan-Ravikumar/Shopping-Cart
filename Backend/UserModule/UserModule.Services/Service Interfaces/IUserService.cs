using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserModule.ViewModal.RequestModal.Mapper.View_Modal;

namespace UserModule.Services.Service_Interfaces
{
    public interface IUserService
    {
        void SendOtp(string phone);
        Task<JwtToken> VerifyOtp(string contact, string otp);
        void SendEmail(string request);
    }
}
