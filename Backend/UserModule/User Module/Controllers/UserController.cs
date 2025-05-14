using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserModule.Services.Service_Interfaces;
using UserModule.ViewModal.RequestModal.Mapper.Request_Modal;
using UserModule.ViewModal.RequestModal.Mapper.View_Modal;

namespace User_Module.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("send-otp")]
        public IActionResult SendOtp([FromBody] OtpRequest_RequestModal request)
        {
            _userService.SendOtp(request.contact);
            return Ok("OTP sent successfully.");
        }

       
        [HttpPost("Send-otp-via-mail")]
        public IActionResult SendEmail([FromBody] OtpRequest_RequestModal request)
        {
            try
            {
                _userService.SendEmail(request.contact);
                return Ok("OTP email sent successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("verify-otp")]
        public async Task<ActionResult<JwtToken>> VerifyOtp([FromBody] VerifyOtp_RequestModal request)
        {
            var token = await _userService.VerifyOtp(request.contact, request.Otp);
            if (token == null)
                return Unauthorized("Invalid OTP");

            return Ok(token);
        }
    }
}
