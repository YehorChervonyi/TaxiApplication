using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Entities;

public static class Injecting
{
    public static void Inject(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<Data.Context.DBContext>(options =>
        {
            options.UseSqlServer(
                configuration["ConnectionString"]);
        });
    }
}