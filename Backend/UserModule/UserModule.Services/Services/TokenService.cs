using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Numerics;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Twilio.Jwt.AccessToken;
using UserModule.Services.Service_Interfaces;
using UserModule.ViewModal.RequestModal.Mapper.View_Modal;

namespace UserModule.Services.Services
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _key;

        public TokenService(IConfiguration configuration)
        {
            var tokenKey = configuration["Jwt:TokenKey"];
            if (string.IsNullOrWhiteSpace(tokenKey))
                throw new ArgumentNullException("TokenKey", "Token key must be set in configuration.");

            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));
        }

        public JwtToken GenerateToken(GetUserDetails userDetails)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userDetails.UserId.ToString()),
                new Claim(ClaimTypes.Name, userDetails.Name),
                new Claim("PhoneNumber", userDetails.Phone),
                new Claim(ClaimTypes.Email, userDetails.Email),
                new Claim("IsActive", userDetails.IsActive.ToString()),
                new Claim(ClaimTypes.Role,userDetails.RoleName)
            };

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);

            var expires = DateTime.UtcNow.AddHours(24); 

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = expires,
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.CreateToken(tokenDescriptor);

            return new JwtToken
            {
                Token = tokenHandler.WriteToken(jwtToken),
                ExpiresAt = expires
            };
        }
    }
}
