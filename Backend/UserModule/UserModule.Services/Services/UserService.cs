using Twilio.Types;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using UserModule.Services.Service_Interfaces;
using UserModule.Repository.Repository_Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;
using System.Numerics;
using UserModule.ViewModal.RequestModal.Mapper.View_Modal;
using UserModule.Repository.Repositories;

namespace UserModule.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IMemoryCache _cache;
        private readonly IUserRepository _repo;
        private readonly IConfiguration _config;
        private readonly ITokenService _tokenService;

        public UserService(IMemoryCache cache, IUserRepository repo, IConfiguration config, ITokenService tokenService)
        {
            _cache = cache;
            _repo = repo;
            _config = config;
            _tokenService = tokenService;
        }

        public void SendOtp(string phone)
        {
            var otp = GenerateOtp(phone);
            _cache.Set(phone, otp, TimeSpan.FromMinutes(5));

            string accountSid = _config["Twilio:AccountSid"];
            string authToken = _config["Twilio:AuthToken"];
            string fromPhone = _config["Twilio:FromPhone"];

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                to: new PhoneNumber($"+91{phone}"),
                from: new PhoneNumber(fromPhone),
                body: $"Your OTP is: {otp}");

            Console.WriteLine($"OTP sent to {phone}. SID: {message.Sid}");
        }

        public void SendEmail(string UserEmailId)
        {
            try
            {
                var fromEmail = _config["EmailUsername"];
                var emailHost = _config["EmailHost"];
                var emailPassword = _config["EmailPassword"];
                if (string.IsNullOrEmpty(fromEmail) || string.IsNullOrEmpty(emailHost) || string.IsNullOrEmpty(emailPassword))
                {
                    throw new InvalidOperationException("Email configuration is missing.");
                }
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(fromEmail));
                email.To.Add(MailboxAddress.Parse(UserEmailId));
                email.Subject = "Your OTP from Shopping Cart";
                var otp = GenerateOtp(UserEmailId);
                email.Body = new TextPart(TextFormat.Text) { Text = $"Your OTP is: {otp}" };

                using var smtp = new SmtpClient();
                smtp.Connect(emailHost, 587, SecureSocketOptions.StartTls);
                smtp.Authenticate(fromEmail, emailPassword);
                smtp.Send(email);
                smtp.Disconnect(true);
            }
            catch(Exception ex) {
                throw new Exception("Email sending failed: " + ex.Message);
            }
            
        }
        public async Task<JwtToken> VerifyOtp(string contact, string otp)
        {
            if (!_cache.TryGetValue(contact, out string cachedOtp) || string.IsNullOrWhiteSpace(cachedOtp))
                throw new Exception("OTP expired or invalid.");

            if (!string.Equals(cachedOtp, otp, StringComparison.Ordinal))
                throw new Exception("Incorrect OTP.");
            var user = await _repo.GetUserByNumberOrEmail(contact);
            if (user == null)
                throw new Exception("User not found.");
            _cache.Remove(contact);

            return _tokenService.GenerateToken(user);
        }

        public string GenerateOtp(string key)
        {
            string otp = new Random().Next(100000, 999999).ToString();
            _cache.Set(key, otp, TimeSpan.FromMinutes(5));
            return otp;
        }
    }
}
