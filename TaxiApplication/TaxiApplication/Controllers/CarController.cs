using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TaxiApplication.BL.Models;
using TaxiApplication.BL.Services.Interfaces;
using TaxiApplication.DTOs;

namespace TaxiApplication.Controllers;

public class CarController : Controller
{
    private readonly ILogger<CarController> _logger;
    private readonly ICarService _carService;
    private readonly IMapper _mapper;

    public CarController(ILogger<CarController> logger, ICarService carService, IMapper mapper)
    {
        _logger = logger;
        _carService = carService;
        _mapper = mapper;
    }

    [HttpPost("newCar")]
    public async Task<IActionResult> newCar(CarDto car)
    {
        var mappedCar = _mapper.Map<CarModel>(car);
        await  _carService.AddCarAsync(mappedCar);
        return Ok();
    }

    [HttpPut("updateCar")]
    public async Task<IActionResult> updateCar(int id ,CarDto car)
    {
        var mappedCar = _mapper.Map<CarModel>(car);
        await _carService.UpdateCarAsync(mappedCar, id);
        return Ok();
    }

    [HttpDelete("deleteCar")]
    public async Task<IActionResult> deleteCar(int id)
    {
        await _carService.DeleteCarAsync(id);
        return Ok();
    }

    [HttpGet("getAllCars")]
    public async Task<IActionResult> getAllCars()
    {
        var allCars = _carService.GetAllCars();
        var cars = _mapper.ProjectTo<CarDto>(allCars);
        return Ok(await JsonConvert.SerializeObjectAsync(cars));
    }

    [HttpGet("getCarById")]
    public async Task<IActionResult> getCarById(int id)
    {
        var car =  await _carService.GetCarById(id);
        var mappedCar = _mapper.Map<CarDto>(car);
        return Ok(await JsonConvert.SerializeObjectAsync(mappedCar));
    }
    
    [HttpGet("getCarByDriverId")]
    public async Task<IActionResult> getCarByDriverId(int id)
    {
        var car =  _carService.GetCarByDriverId(id);
        var mappedCar = _mapper.ProjectTo<CarDto>(car);
        return Ok(await JsonConvert.SerializeObjectAsync(mappedCar));
    }
    
    [HttpGet("getCarByTariffId")]
    public async Task<IActionResult> getCarByTariffId(int id)
    {
        var car =  _carService.GetCarByTariffId(id);
        var mappedCar = _mapper.ProjectTo<CarDto>(car);
        return Ok(await JsonConvert.SerializeObjectAsync(mappedCar));
    }
    
    [HttpGet("getFreeCarsByTariffId")]
        public async Task<IActionResult> getFreeCarsByTariffId(int id)
        {
            var car =  _carService.GetFreeCarsByTariffId(id);
            var mappedCar = _mapper.ProjectTo<CarDto>(car);
            return Ok(await JsonConvert.SerializeObjectAsync(mappedCar));
        }
}