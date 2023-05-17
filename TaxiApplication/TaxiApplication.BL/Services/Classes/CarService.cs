using AutoMapper;
using TaxiApplication.BL.Models;
using TaxiApplication.BL.Services.Interfaces;
using TaxiApplication.DAL.Entities;
using TaxiApplication.DAL.Repository.Interfaces;

namespace TaxiApplication.BL.Services.Classes;

public class CarService : ICarService
{
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;

    public CarService(ICarRepository carRepository, IMapper mapper)
    {
        _carRepository = carRepository;
        _mapper = mapper;
    }

    public async Task AddCarAsync(CarModel car)
    {
        var mappedCar = _mapper.Map<Car>(car);
        await _carRepository.AddAsync(mappedCar);
    }

    public async Task UpdateCarAsync(CarModel car, int id)
    {
        var mappedCar = _mapper.Map<Car>(car);
        await _carRepository.UpdateAsync(mappedCar, id);
    }

    public async Task DeleteCarAsync(int id)
    {
        await _carRepository.DeleteAsync(id);
    }

    public IQueryable GetAllCars()
    {
        var cars = _carRepository.GetAll();
        return _mapper.ProjectTo<CarModel>(cars);
    }

    public async Task<CarModel> GetCarById(int id)
    {
        var car = await _carRepository.GetById(id);
        return _mapper.Map<CarModel>(car);
    }  
}