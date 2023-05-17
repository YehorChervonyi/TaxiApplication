using TaxiApplication.BL.Models;
using TaxiApplication.DAL.Entities;

namespace TaxiApplication.BL.Services.Interfaces;

public interface IDriverService
{
    Task AddDriverAsync(DriverModel driver);
    Task UpdateDriverAsync(DriverModel driver, int id);
    Task DeleteDriverAsync(int id);
    IQueryable GetAllDrivers();
    Task<DriverModel> GetDriverById(int id);
    IQueryable GetDriversByCarId(int id);
}