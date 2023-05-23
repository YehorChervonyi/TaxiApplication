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
        DbSeading(modelBuilder);
        
    }

    private void DbSeading(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasData(
                new User
            {
                id = 1,
                name = "Name1",
                surname = "Sur1",
                phone = "123123",
                login = "login1",
                password = "pass1",

            },
                new User
                {
                    id = 2,
                    name = "Name2",
                    surname = "Sur2",
                    phone = "123123",
                    login = "login2",
                    password = "pass2",
                
                }
                );
        modelBuilder.Entity<Tariff>()
            .HasData(
                new Tariff()
                {
                    id = 1,
                    name = "Економ",
                    price = 8,
                    fee = 35
                },
                new Tariff()
                {
                    id = 2,
                    name = "Стандарт",
                    price = 9,
                    fee = 40 
                },
                new Tariff()
                {
                    id = 3,
                    name = "Бізнес",
                    price = 11,
                    fee = 50 
                },
                new Tariff()
                {
                    id = 4,
                    name = "Мікроавтобус",
                    price = 11,
                    fee = 50 
                });
        modelBuilder.Entity<Driver>()
            .HasData(
                new Driver()
                {
                    id = 1,
                    name = "Name1",
                    surname = "Sur1",
                    experience = 1,
                    status = 1,
                },
                new Driver()
                {
                    id = 2,
                    name = "Name2",
                    surname = "Sur2",
                    experience = 2,
                    status = 1,
                },
                new Driver()
                {
                    id = 3,
                    name = "Name3",
                    surname = "Sur3",
                    experience = 2,
                    status = 1,
                },
                new Driver()
                {
                    id = 4,
                    name = "Name4",
                    surname = "Sur4",
                    experience = 2,
                    status = 1,
                });
        modelBuilder.Entity<Car>()
            .HasData(
                new Car()
                {
                    id = 1,
                    tariffId = 1,
                    driverId = 1,
                    plate = "plate",
                    brand = "brand",
                    model = "model",
                    seats = 4
                },
                new Car()
                {
                    id = 2,
                    tariffId = 2,
                    driverId = 2,
                    plate = "plate",
                    brand = "brand",
                    model = "model",
                    seats = 4
                },
                new Car()
                {
                    id = 3,
                    tariffId = 3,
                    driverId = 1,
                    plate = "plate",
                    brand = "brand",
                    model = "model",
                    seats = 4
                },
                new Car()
                {
                    id = 4,
                    tariffId = 4,
                    driverId = 2,
                    plate = "plate",
                    brand = "brand",
                    model = "model",
                    seats = 5
                });
        modelBuilder.Entity<Order>()
            .HasData(
                new Order()
                {
                    id = 1,
                    userId = 1,
                    driverId = 2,
                    start = "start",
                    finish = "finish",
                    status = 0,
                    price = 123,
                    timeStart = new DateTime(),
                    timeFinish = new DateTime()
                },
                new Order()
                {
                    id = 2,
                    userId = 2,
                    driverId = 1,
                    start = "start",
                    finish = "finish",
                    status = 0,
                    price = 123,
                    timeStart = new DateTime(),
                    timeFinish = new DateTime()
                },
                new Order()
                {
                    id = 3,
                    userId = 2,
                    driverId = 1,
                    start = "start",
                    finish = "finish",
                    status = 0,
                    price = 123,
                    timeStart = new DateTime(),
                    timeFinish = new DateTime()
                },
                new Order()
                {
                    id = 4,
                    userId = 1,
                    driverId = 2,
                    start = "start",
                    finish = "finish",
                    status = 0,
                    price = 123,
                    timeStart = new DateTime(),
                    timeFinish = new DateTime()
                });
    }
}