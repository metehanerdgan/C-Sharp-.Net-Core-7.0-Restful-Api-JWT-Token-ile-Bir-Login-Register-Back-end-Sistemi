using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using NodebookApp.Services.Interface;
using Microsoft.Extensions.Configuration;

namespace NodebookApp.Services
{
    // ISecurityService arayüzünden kalıtım alarak JWT oluşturma ve doğrulama işlemlerini yönetir
    public class JWTSecurityToken:ISecurtiyService
    {
        private readonly IConfiguration configuration;

        public JWTSecurityToken(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public DateTime? ValidTo { get; internal set; }

        // JWT oluşturur
        public void SecureToken(Claim[] claims, out JwtSecurityToken token, out string tokenAstring)
        {
            try
            {
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Authentication:key"]));
                token = new JwtSecurityToken
                (
                       issuer: configuration["Authentication:Issuer"],
                       audience: configuration["Authentication:Audience"],
                       claims: claims,
                       expires: DateTime.Now.AddMinutes(30),
                       signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                       );
                tokenAstring = new JwtSecurityTokenHandler().WriteToken(token);
                 
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Bu metot implemente edilmemiş
        public void SecureToken(Claim[] claims, out JWTSecurityToken token, out string tokenAstring)
        {
            throw new NotImplementedException();
        }
    }
}
