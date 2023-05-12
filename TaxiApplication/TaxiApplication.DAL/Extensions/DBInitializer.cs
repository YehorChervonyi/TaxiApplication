using Data.Context;

namespace Data.Entities;

public class DBInitializer
{
    public static void Initialize(DBContext context)
    {
        context.Database.EnsureCreated();
    }
}