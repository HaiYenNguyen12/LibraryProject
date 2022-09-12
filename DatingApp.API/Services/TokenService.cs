using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DatingApp.API.Database.entities;
using DatingApp.API.Services;
using Microsoft.IdentityModel.Tokens;

namespace DatingApp.API.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configration;

        public TokenService(IConfiguration configration)
        {
            _configration = configration;
        }
        public string CreateToken(User user)
        {
            var claims  =  new List<Claim>(){
                new Claim(JwtRegisteredClaimNames.NameId, user.Username),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(ClaimTypes.Role,user.Role)

            };
            var symetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configration["TokenKey"]));

            var tokenDesctiptor = new SecurityTokenDescriptor{
                Subject = new ClaimsIdentity(claims),
                Expires =DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(symetricKey,SecurityAlgorithms.HmacSha512Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDesctiptor);

            return tokenHandler.WriteToken(token);
        }
    }
}