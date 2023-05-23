using TaxiApplication.DAL.Context;
using TaxiApplication.DAL.Entities;
using TaxiApplication.DAL.Repository.Interfaces;

namespace TaxiApplication.DAL.Repository.Classes;

public class CarRepository: GenericRepository<Car>, ICarRepository
{
    public CarRepository(DBContext context) : base(context)
    {
        
    }
    
    public IQueryable GetCarByDriverId(int id)
    {
        var car = GetAll().Where(car => car.driverId == id);
        return car;
    }
    
    public IQueryable GetCarByTariffId(int id)
    {
        var car = GetAll().Where(car => car.tariffId == id);
        return car;
    }

    public IQueryable GetFreeCarsByTariffId(int id)
    {
        var cars = GetAll().Where(car => car.driver.status == 1).Where(tariff => tariff.tariffId == id);
        return cars;
    }
}