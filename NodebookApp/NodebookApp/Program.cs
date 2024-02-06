using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NodebookApp.DbContext;
using NodebookApp.Services;
using NodebookApp.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

// Servisleri konteynere ekleyerek bağımlılıkları yönetir
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<AuthenticationDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("AuthenticationConn"));
});
builder.Services.AddSwaggerGen();

// Identity ve JWT Authentication'ı konfigure eder
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequiredLength = 6;
}).AddEntityFrameworkStores<AuthenticationDbContext>().AddDefaultTokenProviders();
builder.Services.AddAuthentication(auth =>
{
    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Authentication:Audience"],
        ValidIssuer = builder.Configuration["Authentication:Issuer"],
        RequireExpirationTime = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Authentication:Key"])),
        ValidateIssuerSigningKey = true
    };
}) ;

// Servislerin yaşam döngüsünü yönetir
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ISecurtiyService, JWTSecurityToken>();

var app = builder.Build();

// HTTP istek pipeline'ını konfigure eder
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
