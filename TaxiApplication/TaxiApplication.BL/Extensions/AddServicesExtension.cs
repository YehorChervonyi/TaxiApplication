using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaxiApplication.BL.Mapping;
using TaxiApplication.BL.Repository;
using TaxiApplication.DAL.Extensions;

namespace TaxiApplication.BL.Extensions;

public static class AddServicesExtension
{
    public static void AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped(typeof(IGenericRepository<>));

        // services.AddScoped<IGenericRepository>();
        services.AddScoped(typeof(Injecting));
        services.AddAutoMapper(
            config =>
            {
                config.AddProfile(typeof(AutoMapperProfile));
            });
    }
}