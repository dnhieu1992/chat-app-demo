using ChatApp.WebApi.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ChatApp.WebApi.Services
{
    public class JwtService
    {
        public string GenerateJwtToken(IConfiguration configuration, UserViewModel user)
        {
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["Jwt:Key"]));
            var claims = new List<Claim>()
                {
                    new Claim("Username", user.Username),
                    new Claim(ClaimTypes.Email,user.Email),
                };
            var tokenOption = new JwtSecurityToken(
                    issuer: configuration["Jwt:Issuer"],
                    audience: configuration["Jwt:Issuer"],
                    claims: AddUserInformation(user),
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
                );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOption);

            return tokenString;
        }
        public List<Claim> AddUserInformation(UserViewModel user)
        {
            return new List<Claim>(){
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.NameIdentifier,user.Username)
            };
        }
    }

}
