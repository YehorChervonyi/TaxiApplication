using TaxiApplication.BL.Models;
using TaxiApplication.DAL.Entities;

namespace TaxiApplication.BL.Services.Interfaces;

public interface ITariffService
{
    Task AddTariffAsync(TariffModel tariff);
    Task UpdateTariffAsync(TariffModel tariff, int id);
    Task DeleteTariffAsync(int id);
    IQueryable GetAllTariffs();
    Task<TariffModel> GetTariffById(int id);
}