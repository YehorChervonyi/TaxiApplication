using TaxiApplication.DAL.Context;

namespace TaxiApplication.DAL.Extensions;

public class DBInitializer
{
    public static void Initialize(DBContext context)
    {
        context.Database.EnsureCreated();
    }
}