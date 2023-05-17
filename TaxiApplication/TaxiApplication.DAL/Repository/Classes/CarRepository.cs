using TaxiApplication.DAL.Context;
using TaxiApplication.DAL.Entities;
using TaxiApplication.DAL.Repository.Interfaces;

namespace TaxiApplication.DAL.Repository.Classes;

public class CarRepository: GenericRepository<Car>, ICarRepository
{
    public CarRepository(DBContext context) : base(context)
    {
        
    }
}