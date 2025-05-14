using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserModule.Services.Service_Interfaces;
using UserModule.ViewModal.RequestModal.Mapper.Request_Modal;

namespace User_Module.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRegisterController : ControllerBase
    {
        private readonly IUserRegister _userRegisterService;

        public UserRegisterController(IUserRegister userRegisterService)
        {
            _userRegisterService = userRegisterService;
        }


        [HttpPost]
        public async Task<ActionResult<User_Register>> RegisterUser(User_Register userDetails)
        {
            
          return await _userRegisterService.UserRegisterAsync(userDetails);
        }
    }
}
