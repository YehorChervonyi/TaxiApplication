using TaxiApplication.DAL.Entities;

namespace TaxiApplication.DAL.Repository.Interfaces;

public interface ITariffRepository : IGenericRepository<Tariff>
{
    IQueryable GetTariffByCarId(int id);
    IQueryable GetTariffByName(string name);
}