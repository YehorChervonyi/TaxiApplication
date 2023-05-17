using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TaxiApplication.BL.Models;
using TaxiApplication.BL.Services.Interfaces;
using TaxiApplication.DTOs;

namespace TaxiApplication.Controllers;

public class DriverController : Controller
{
    private readonly ILogger<DriverController> _logger;
    private readonly IDriverService _driverService;
    private readonly IMapper _mapper;
    
    public DriverController(ILogger<DriverController> logger, IDriverService driverService, IMapper mapper)
    {
        _logger = logger;
        _driverService = driverService;
        _mapper = mapper;
    }
    
    [HttpPost("newDriver")]
    public async Task<IActionResult> newDriver(DriverDto driver)
    {
        var mappedDriver = _mapper.Map<DriverModel>(driver);
        await  _driverService.AddDriverAsync(mappedDriver);
        return Ok();
    }

    [HttpPut("updateDriver")]
    public async Task<IActionResult> updateDriver(int id ,DriverDto driver)
    {
        var mappedDriver = _mapper.Map<DriverModel>(driver);
        await _driverService.UpdateDriverAsync(mappedDriver, id);
        return Ok();
    }

    [HttpDelete("deleteDriver")]
    public async Task<IActionResult> deleteDriver(int id)
    {
        await _driverService.DeleteDriverAsync(id);
        return Ok();
    }

    [HttpGet("getAllDrivers")]
    public async Task<IActionResult> getAllDrivers()
    {
        var allDrivers = _driverService.GetAllDrivers();
        var drivers = _mapper.ProjectTo<DriverDto>(allDrivers);
        return Ok(await JsonConvert.SerializeObjectAsync(drivers));
    }

    [HttpGet("getDriverById")]
    public async Task<IActionResult> getDriverById(int id)
    {
        var driver =  await _driverService.GetDriverById(id);
        var mappedDriver = _mapper.Map<DriverDto>(driver);
        return Ok(await JsonConvert.SerializeObjectAsync(mappedDriver));
    }

    [HttpGet("getDriversByCarId")]
    public async Task<IActionResult> getDriversByCarId(int id)
    {
        var drivers = _driverService.GetDriversByCarId(id);
        var mappedDrivers = _mapper.ProjectTo<DriverDto>(drivers);
        // return Ok(mappedDrivers);
        return Ok( await JsonConvert.SerializeObjectAsync(mappedDrivers));
    }
}