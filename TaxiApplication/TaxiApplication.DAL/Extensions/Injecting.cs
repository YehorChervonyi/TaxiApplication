using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TaxiApplication.DAL.Context;
using TaxiApplication.DAL.Repository.Classes;
using TaxiApplication.DAL.Repository.Interfaces;

namespace TaxiApplication.DAL.Extensions;

public static class Injecting
{
    public static void Inject(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<ICarRepository, CarRepository>();
        services.AddScoped<IDriverRepository, DriverRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<ITariffRepository, TariffRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        
        services.AddDbContext<DBContext>(options =>
        {
            options.UseNpgsql(
                configuration["ConnectionString"]);
        });
    }
}