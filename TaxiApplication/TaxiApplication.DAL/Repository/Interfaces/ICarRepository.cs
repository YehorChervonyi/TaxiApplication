using TaxiApplication.DAL.Entities;

namespace TaxiApplication.DAL.Repository.Interfaces;

public interface ICarRepository: IGenericRepository<Car>
{
    IQueryable GetCarByDriverId(int id);
    IQueryable GetCarByTariffId(int id);
    IQueryable GetFreeCarsByTariffId(int id);
}