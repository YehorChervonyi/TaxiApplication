using TaxiApplication.DAL.Context;
using TaxiApplication.DAL.Entities;
using TaxiApplication.DAL.Repository.Interfaces;

namespace TaxiApplication.DAL.Repository.Classes;

public class OrderRepository: GenericRepository<Order>, IOrderRepository
{
    public OrderRepository(DBContext context) : base(context)
    {
        
    }
    
    public IQueryable GetOrdersByUserId(int id)
    {
        var orders = GetAll().Where(order => order.userId == id);
        return orders;
    }
    
    public IQueryable GetOrdersByDriverId(int id)
    {
        var orders = GetAll().Where(order => order.driverId == id);
        return orders;
    }
    
    public IQueryable GetOrdersByStatus(int status)
    {
        var orders = GetAll().Where(order => order.status == status);
        return orders;
    }
}