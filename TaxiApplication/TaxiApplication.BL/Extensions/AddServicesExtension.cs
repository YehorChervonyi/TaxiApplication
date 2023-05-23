using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using TaxiApplication.BL.Mapping;
using TaxiApplication.BL.Services.Classes;
using TaxiApplication.BL.Services.Interfaces;

namespace TaxiApplication.BL.Extensions;

public static class AddServicesExtension
{
    public static void AddServices(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddScoped<ICarService, CarService>();
        services.AddScoped<IDriverService, DriverService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<ITariffService, TariffService>();
        services.AddScoped<IUserService, UserService>();

        services.AddScoped<IAuthService, AuthService>();
        
        
        
        services.AddAutoMapper(typeof(AutoMapperProfile));

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = "Auth",
                ValidateAudience = true,
                ValidAudience = "Auth",
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(configuration["SecretKey"]))
            };
        });
        services.AddAuthorization();
        services.AddScoped<IJwtService, JwtService>();
    }
}