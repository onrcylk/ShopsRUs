using Common.Dto.Token;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class TokenHandler
    {
        public IConfiguration Configuration { get; set; }
        public TokenHandler(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public TokenDto CreateAccessToken(User user)
        {
            try
            {
                TokenDto tokenInstance = new TokenDto();

                SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:SecurityKey"]));

                SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                tokenInstance.Expiration = DateTime.Now.AddMinutes(10);
                JwtSecurityToken securityToken = new JwtSecurityToken(
                    issuer: Configuration["Token:Issuer"],
                    audience: Configuration["Token:Audience"],
                    claims: new List<Claim>() { new Claim("userId", user.Id.ToString()) },
                    expires: tokenInstance.Expiration,
                    notBefore: DateTime.Now,
                    signingCredentials: signingCredentials
                    );

                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

                tokenInstance.AccessToken = tokenHandler.WriteToken(securityToken);

                tokenInstance.RefreshToken = CreateRefreshToken();
                return tokenInstance;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string CreateRefreshToken()
        {
            byte[] number = new byte[32];
            using (RandomNumberGenerator random = RandomNumberGenerator.Create())
            {
                random.GetBytes(number);
                return Convert.ToBase64String(number);
            }
        }
    }
}
