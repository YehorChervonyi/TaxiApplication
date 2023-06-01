using TaxiApplication.DAL.Context;
using TaxiApplication.DAL.Entities;
using TaxiApplication.DAL.Repository.Interfaces;

namespace TaxiApplication.DAL.Repository.Classes;

public class TariffRepository: GenericRepository<Tariff>, ITariffRepository
{
    public TariffRepository(DBContext context) : base(context)
    {
        
    }
    
    public IQueryable GetTariffByCarId(int id)
    {
        var tariffs = GetAll().Where(tariff => tariff.cars.Any(car => car.id == id));
        return tariffs;
    }
    
    public IQueryable GetTariffByName(string name)
    {
        var tariffs = GetAll().Where(tariff => tariff.name == name);
        return tariffs;
    }
}