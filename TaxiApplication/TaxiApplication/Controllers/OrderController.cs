using AutoMapper;
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
    
    [HttpPost("newOrder")]
    public async Task<IActionResult> newOrder(OrderDto order)
    {
        var mappedOrder = _mapper.Map<OrderModel>(order);
        await  _orderService.AddOrderAsync(mappedOrder);
        return Ok();
    }

    [HttpPut("updateOrder")]
    public async Task<IActionResult> updateOrder(int id ,OrderDto order)
    {
        var mappedOrder = _mapper.Map<OrderModel>(order);
        await _orderService.UpdateOrderAsync(mappedOrder, id);
        return Ok();
    }

    [HttpDelete("deleteOrder")]
    public async Task<IActionResult> deleteOrder(int id)
    {
        await _orderService.DeleteOrderAsync(id);
        return Ok();
    }

    [HttpGet("getAllOrders")]
    public async Task<IActionResult> getAllOrders()
    {
        var allOrders = _orderService.GetAllOrders();
        var orders = _mapper.ProjectTo<OrderDto>(allOrders);
        return Ok(await JsonConvert.SerializeObjectAsync(orders));
    }

    [HttpGet("getOrderById")]
    public async Task<IActionResult> getOrderById(int id)
    {
        var order =  await _orderService.GetOrderById(id);
        var mappedOrder = _mapper.Map<OrderDto>(order);
        return Ok(await JsonConvert.SerializeObjectAsync(mappedOrder));
    }
    
}