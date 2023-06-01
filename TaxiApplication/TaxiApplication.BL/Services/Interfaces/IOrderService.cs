using TaxiApplication.BL.Models;
using TaxiApplication.DAL.Entities;

namespace TaxiApplication.BL.Services.Interfaces;

public interface IOrderService
{
    Task AddOrderAsync(OrderModel order);
    Task UpdateOrderAsync(OrderModel order, int id);
    Task DeleteOrderAsync(int id);
    IQueryable GetAllOrders();
    Task<OrderModel> GetOrderById(int id);
    IQueryable GetOrdersByUserId(int id);
    IQueryable GetOrdersByDriverId(int id);
    IQueryable GetOrdersByStatus(int status);
}