using TaxiApplication.DAL.Entities;

namespace TaxiApplication.DAL.Repository.Interfaces;

public interface IOrderRepository : IGenericRepository<Order>
{
    IQueryable GetOrdersByUserId(int id);
    IQueryable GetOrdersByDriverId(int id);
    IQueryable GetOrdersByStatus(int status);
}