using System;
using NodebookApp.SharedVM;

namespace NodebookApp.Services.Interface
{
    // Kullanıcı işlemlerini tanımlayan arayüz
    public interface IUserService
    {
        Task<UserManager> RegisterUserAsycn(Register model);
        Task<UserManager> LoginUserAsycn(Login model);
    }
}
