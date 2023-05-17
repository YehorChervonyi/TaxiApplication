using TaxiApplication.BL.Models;
using TaxiApplication.DAL.Entities;

namespace TaxiApplication.BL.Services.Interfaces;

public interface ICarService
{
    Task AddCarAsync(CarModel car);
    Task UpdateCarAsync(CarModel car, int id);
    Task DeleteCarAsync(int id);
    IQueryable GetAllCars();
    Task<CarModel> GetCarById(int id);

}