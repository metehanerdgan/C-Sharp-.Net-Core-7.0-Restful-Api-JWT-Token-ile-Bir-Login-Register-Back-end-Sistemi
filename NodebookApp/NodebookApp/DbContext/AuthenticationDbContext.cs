using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NodebookApp.DbContext
{
    // IdentityDbContext sınıfından kalıtım alarak veritabanı işlemlerini yönetir
    public class AuthenticationDbContext : IdentityDbContext
    {
        public AuthenticationDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
