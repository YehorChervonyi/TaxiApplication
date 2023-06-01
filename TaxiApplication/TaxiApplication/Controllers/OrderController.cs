using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TaxiApplication.BL.Models;
using TaxiApplication.BL.Services.Interfaces;
using TaxiApplication.DTOs;

namespace TaxiApplication.Controllers;

public class OrderController : Controller
{
    private readonly ILogger<OrderController> _logger;
    private readonly IOrderService _orderService;
    private readonly IMapper _mapper;
    
    public OrderController(ILogger<OrderController> logger, IOrderService orderService, IMapper mapper)
    {
        _logger = logger;
        _orderService = orderService;
        _mapper = mapper;
    }
    [Authorize]
    [HttpPost("newOrder")]
    public async Task<IActionResult> newOrder(OrderDto order)
    {
        var mappedOrder = _mapper.Map<OrderModel>(order);
        await  _orderService.AddOrderAsync(mappedOrder);
        return Ok();
    }
    
    [Authorize]
    [HttpPut("updateOrder")]
    public async Task<IActionResult> updateOrder(int id , [FromBody]OrderDto order)
    {
        var mappedOrder = _mapper.Map<OrderModel>(order);
        await _orderService.UpdateOrderAsync(mappedOrder, id);
        return Ok();
    }
    
    [Authorize]
    [HttpDelete("deleteOrder")]
    public async Task<IActionResult> deleteOrder(int id)
    {
        await _orderService.DeleteOrderAsync(id);
        return Ok();
    }
    
    [Authorize]
    [HttpGet("getAllOrders")]
    public async Task<IActionResult> getAllOrders()
    {
        var allOrders = _orderService.GetAllOrders();
        var orders = _mapper.ProjectTo<OrderDto>(allOrders);
        return Ok(await JsonConvert.SerializeObjectAsync(orders));
    }

    [Authorize]
    [HttpGet("getOrderById")]
    public async Task<IActionResult> getOrderById(int id)
    {
        var order =  await _orderService.GetOrderById(id);
        var mappedOrder = _mapper.Map<OrderDto>(order);
        return Ok(await JsonConvert.SerializeObjectAsync(mappedOrder));
    }
    
    [Authorize]
    [HttpGet("getOrdersByUserId")]
    public async Task<IActionResult> getOrdersByUserId(int id)
    {
        var orders = _orderService.GetOrdersByUserId(id);
        var mappedOrders = _mapper.ProjectTo<OrderDto>(orders);
        return Ok(await JsonConvert.SerializeObjectAsync(mappedOrders));
    }
    
    [Authorize]
    [HttpGet("getOrdersByDriverId")]
    public async Task<IActionResult> getOrdersByDriverId(int id)
    {
        var orders = _orderService.GetOrdersByDriverId(id);
        var mappedOrders = _mapper.ProjectTo<OrderDto>(orders);
        return Ok(await JsonConvert.SerializeObjectAsync(mappedOrders));
    }
    
    [Authorize]
    [HttpGet("getOrdersByStatus")]
    public async Task<IActionResult> getOrdersByStatus(int id)
    {
        var orders = _orderService.GetOrdersByStatus(id);
        var mappedOrders = _mapper.ProjectTo<OrderDto>(orders);
        return Ok(await JsonConvert.SerializeObjectAsync(mappedOrders));
    }
    
    [Authorize]
    [HttpPost("setStatusToLastUserOrder")]
    public async Task<IActionResult> cancelOrder(int userId, int status)
    {
        var orders =  _orderService.GetOrdersByUserId(userId);
        var mappedOrder = _mapper.ProjectTo<OrderDto>(orders);
        var lastCalledOrder = mappedOrder.OrderBy(x=>x.id).Last();
        lastCalledOrder.status = status;
        var mappedLastCalledOrder = _mapper.Map<OrderModel>(lastCalledOrder);
        await _orderService.UpdateOrderAsync(mappedLastCalledOrder, lastCalledOrder.id);
        return Ok();
    }

}