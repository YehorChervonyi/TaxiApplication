using TaxiApplication.Mapping;

namespace TaxiApplication.Extensions;

public static class AddMapperExtension
{
    public static void AddMapper(this IServiceCollection service)
    {
        service.AddAutoMapper(typeof(AutoMapperProfile));
    }
}