using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace NodebookApp.Services.Interface
{
    // JWT oluşturma ve doğrulama işlemlerini tanımlayan arayüz
    public interface ISecurtiyService
    {
        void SecureToken(Claim[] claim, out JwtSecurityToken token, out string tokenAstring);
        void SecureToken(Claim[] claims, out JWTSecurityToken token, out string tokenAstring);
    }
}
