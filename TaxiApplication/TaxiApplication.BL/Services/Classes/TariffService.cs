using AutoMapper;
using TaxiApplication.BL.Models;
using TaxiApplication.BL.Services.Interfaces;
using TaxiApplication.DAL.Entities;
using TaxiApplication.DAL.Repository.Interfaces;

namespace TaxiApplication.BL.Services.Classes;

public class TariffService : ITariffService
{
    private readonly ITariffRepository _tariffRepository;
    private readonly IMapper _mapper;

    public TariffService(ITariffRepository tariffRepository, IMapper mapper)
    {
        _tariffRepository = tariffRepository;
        _mapper = mapper;
    }

    public async Task AddTariffAsync(TariffModel tariff)
    {
        var mappedTariff = _mapper.Map<Tariff>(tariff);
        await _tariffRepository.AddAsync(mappedTariff);
    }

    public async Task UpdateTariffAsync(TariffModel tariff, int id)
    {
        var mappedTariff = _mapper.Map<Tariff>(tariff);
        await _tariffRepository.UpdateAsync(mappedTariff, id);
    }

    public async Task DeleteTariffAsync(int id)
    {
        await _tariffRepository.DeleteAsync(id);
    }

    public IQueryable GetAllTariffs()
    {
        var tariffs = _tariffRepository.GetAll();
        return _mapper.ProjectTo<TariffModel>(tariffs);
    }

    public async Task<TariffModel> GetTariffById(int id)
    {
        var tariff = await _tariffRepository.GetById(id); 
        return _mapper.Map<TariffModel>(tariff);
    }

    public IQueryable GetTariffByCarId(int id)
    {
        var tariff =  _tariffRepository.GetTariffByCarId(id); 
        return _mapper.ProjectTo<TariffModel>(tariff);
    }

    public IQueryable GetTariffByName(string name)
    {
        var tariff =  _tariffRepository.GetTariffByName(name); 
        return _mapper.ProjectTo<TariffModel>(tariff);
    }
}