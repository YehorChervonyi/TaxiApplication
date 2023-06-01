using TaxiApplication.DAL.Entities;

namespace TaxiApplication.DAL.Repository.Interfaces;

public interface IDriverRepository : IGenericRepository<Driver>
{
    IQueryable GetDriversByCarId(int id);
    IQueryable GetDriversByOrderId(int id);

}