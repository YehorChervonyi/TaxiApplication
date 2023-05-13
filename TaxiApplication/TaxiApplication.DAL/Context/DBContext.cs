using Microsoft.EntityFrameworkCore;
using TaxiApplication.DAL.Entities;
using TaxiApplication.DAL.EntitiesConfigurations;

namespace TaxiApplication.DAL.Context;

public class DBContext : DbContext
{
    public DBContext (DbContextOptions<DBContext> options) : base(options){}
    
    public DbSet<User> Users { get; set; }
    public DbSet<Driver> Drivers { get; set; }
    public DbSet<Tariff> Tariffs { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new DriverConfiguration());
        modelBuilder.ApplyConfiguration(new TariffConfiguration());
        modelBuilder.ApplyConfiguration(new CarConfiguration());
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        base.OnModelCreating(modelBuilder);
        
    }
}