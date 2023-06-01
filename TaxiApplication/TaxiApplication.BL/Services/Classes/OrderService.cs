using AutoMapper;
using TaxiApplication.BL.Models;
using TaxiApplication.BL.Services.Interfaces;
using TaxiApplication.DAL.Entities;
using TaxiApplication.DAL.Repository.Interfaces;

namespace TaxiApplication.BL.Services.Classes;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public OrderService(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task AddOrderAsync(OrderModel order)
    {
        var mappedOrder = _mapper.Map<Order>(order);
        await _orderRepository.AddAsync(mappedOrder);
    }

    public async Task UpdateOrderAsync(OrderModel order, int id)
    {
        var mappedOrder = _mapper.Map<Order>(order);
        await _orderRepository.UpdateAsync(mappedOrder, id);
    }

    public async Task DeleteOrderAsync(int id)
    {
        await _orderRepository.DeleteAsync(id);
    }

    public IQueryable GetAllOrders()
    {
        var orders =  _orderRepository.GetAll();
        return _mapper.ProjectTo<OrderModel>(orders);
    }

    public async Task<OrderModel> GetOrderById(int id)
    {
        var order = await _orderRepository.GetById(id);
        return _mapper.Map<OrderModel>(order);
    }

    public IQueryable GetOrdersByUserId(int id)
    {
        var orders = _orderRepository.GetOrdersByUserId(id);
        return _mapper.ProjectTo<OrderModel>(orders);
    }

    public IQueryable GetOrdersByDriverId(int id)
    {
        var orders = _orderRepository.GetOrdersByDriverId(id);
        return _mapper.ProjectTo<OrderModel>(orders);
    }

    public IQueryable GetOrdersByStatus(int status)
    {
        var orders = _orderRepository.GetOrdersByStatus(status);
        return _mapper.ProjectTo<OrderModel>(orders);
    }
}