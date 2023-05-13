using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TaxiApplication.DAL.Context;

namespace TaxiApplication.DAL.Extensions;

public static class Injecting
{
    public static void Inject(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<DBContext>(options =>
        {
            options.UseSqlServer(
                configuration["ConnectionString"]);
        });
    }
}