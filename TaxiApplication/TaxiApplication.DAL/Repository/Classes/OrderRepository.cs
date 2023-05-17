using TaxiApplication.DAL.Context;
using TaxiApplication.DAL.Entities;
using TaxiApplication.DAL.Repository.Interfaces;

namespace TaxiApplication.DAL.Repository.Classes;

public class OrderRepository: GenericRepository<Order>, IOrderRepository
{
    public OrderRepository(DBContext context) : base(context)
    {
        
    }
}