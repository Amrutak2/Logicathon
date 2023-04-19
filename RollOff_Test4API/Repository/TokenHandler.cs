using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RollOff_Test4API.Models.Domain;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RollOff_Test4API.Repository
{
    public class TokenHandler: ITokenHandler
    {
        private readonly IConfiguration configuration;

        public TokenHandler(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public Task<string> CreateTokenAsync(Login loginTable)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));

            //Creating claims
            var claims = new List<Claim>();
            
            claims.Add(new Claim(ClaimTypes.Email, loginTable.Email));
           
            claims.Add(new Claim(ClaimTypes.Role, loginTable.Department));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(configuration["Jwt:Issuer"], configuration["Jwt:Audience"],
                claims, expires: DateTime.Now.AddMinutes(15), signingCredentials: credentials);

            return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
