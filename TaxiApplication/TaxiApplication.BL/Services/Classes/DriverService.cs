using AutoMapper;
using TaxiApplication.BL.Models;
using TaxiApplication.BL.Services.Interfaces;
using TaxiApplication.DAL.Entities;
using TaxiApplication.DAL.Repository.Interfaces;

namespace TaxiApplication.BL.Services.Classes;

public class DriverService : IDriverService
{
    private readonly IDriverRepository _driverRepository;
    private readonly IMapper _mapper;

    public DriverService(IDriverRepository driverRepository, IMapper mapper)
    {
        _driverRepository = driverRepository;
        _mapper = mapper;
    }

    public async Task AddDriverAsync(DriverModel driver)
    { 
        var mappedDriver = _mapper.Map<Driver>(driver);
        await _driverRepository.AddAsync(mappedDriver);
    }

    public async Task UpdateDriverAsync(DriverModel driver, int id)
    {
        var mappedDriver = _mapper.Map<Driver>(driver);
        await _driverRepository.UpdateAsync(mappedDriver, id);
    }
    
    public async Task DeleteDriverAsync(int id)
    {
        await _driverRepository.DeleteAsync(id);
    }
    
    public IQueryable GetAllDrivers()
    {
        var drivers =  _driverRepository.GetAll();
        return _mapper.ProjectTo<DriverModel>(drivers);
    }
    
    public async Task<DriverModel> GetDriverById(int id)
    {
        var driver =  await _driverRepository.GetById(id);
        return _mapper.Map<DriverModel>(driver);
    }

    public IQueryable GetDriversByCarId(int id)
    {
        var drivers = _driverRepository.GetDriversByCarId(id);
        return _mapper.ProjectTo<DriverModel>(drivers);
    }
}