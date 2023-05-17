using Microsoft.Extensions.DependencyInjection;
using TaxiApplication.BL.Mapping;
using TaxiApplication.BL.Services.Classes;
using TaxiApplication.BL.Services.Interfaces;

namespace TaxiApplication.BL.Extensions;

public static class AddServicesExtension
{
    public static void AddServices(this IServiceCollection services)
    {

        services.AddScoped<ICarService, CarService>();
        services.AddScoped<IDriverService, DriverService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<ITariffService, TariffService>();
        services.AddScoped<IUserService, UserService>();
        
        
        services.AddAutoMapper(typeof(AutoMapperProfile));
    }
}