using TaxiApplication.DAL.Context;
using TaxiApplication.DAL.Entities;
using TaxiApplication.DAL.Repository.Interfaces;

namespace TaxiApplication.DAL.Repository.Classes;

public class DriverRepository: GenericRepository<Driver>, IDriverRepository
{
    public DriverRepository(DBContext context) : base(context) 
    {
        
    }

    public IQueryable GetDriversByCarId(int id)
    {
        var driver = GetAll().Where(driver => driver.cars.Any(car => car.id == id));
        return driver;
    }
}