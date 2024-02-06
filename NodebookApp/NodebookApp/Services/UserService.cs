using System;
using System.Security.Claims;
using System.Text;
using Azure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;
using NodebookApp.Services.Interface;
using NodebookApp.SharedVM;

namespace NodebookApp.Services
{
    // IUserService arayüzünden kalıtım alarak kullanıcıyla ilgili işlemleri yönetir
    public class UserService: IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ISecurtiyService _jwtsecurity;

        public UserService(UserManager<IdentityUser> userManager ,ISecurtiyService jwtsecurity)
        {
            _userManager = userManager;
            _jwtsecurity = jwtsecurity;
        }

        // Kullanıcı girişi işlemini gerçekleştirir
        public async Task<UserManager> LoginUserAsycn(Login model)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    return new UserManager {
                        Message = "Hatalı",
                        IsSuccess = false,
                    };
                }
                var result = await _userManager.CheckPasswordAsync(user, model.Password);
                if (!result)
                    return new UserManager
                    {
                        Message = "Hatalı",
                        IsSuccess = false,
                    };
                var claims = new[]
                {
                  new Claim("Email",model.Email),
                  new Claim(ClaimTypes.NameIdentifier,user.Id),
                };
                _jwtsecurity.SecureToken(claims, out JWTSecurityToken token, out string tokenAstring);
                return new UserManager
                {
                    Message = tokenAstring,
                    IsSuccess = true,
                    ExpireDate = token.ValidTo
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Yeni kullanıcı kaydı işlemini gerçekleştirir
        public async Task<UserManager> RegisterUserAsycn(Register model)
        {
            try
            {
                if (model == null)
                {
                    throw new NullReferenceException("Hatalı");
                }
                if (model.Password != model.ConfirmPassword)
                    return new UserManager
                    {
                        Message = "Hatalı",
                        IsSuccess = false,
                    };
                var identityUser = new IdentityUser
                {
                    Email = model.Email,
                    UserName = model.Email
                };
                var result = await _userManager.CreateAsync(identityUser, model.Password);
                if (result.Succeeded)
                {
                    var confirmedEmailToken = await _userManager.GenerateEmailConfirmationTokenAsync(identityUser);
                    var encodeEmailToken = Encoding.UTF8.GetBytes(confirmedEmailToken);
                    var validEmailToken = WebEncoders.Base64UrlEncode(encodeEmailToken);

                }
                return new UserManager
                {
                    Message = "Başarılı",
                    IsSuccess = true,
                };

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
