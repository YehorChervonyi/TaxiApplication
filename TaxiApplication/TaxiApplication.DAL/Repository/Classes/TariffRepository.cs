using TaxiApplication.DAL.Context;
using TaxiApplication.DAL.Entities;
using TaxiApplication.DAL.Repository.Interfaces;

namespace TaxiApplication.DAL.Repository.Classes;

public class TariffRepository: GenericRepository<Tariff>, ITariffRepository
{
    public TariffRepository(DBContext context) : base(context)
    {
        
    }
}