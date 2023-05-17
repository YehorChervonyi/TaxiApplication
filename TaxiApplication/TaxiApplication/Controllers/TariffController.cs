using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TaxiApplication.BL.Models;
using TaxiApplication.BL.Services.Interfaces;
using TaxiApplication.DTOs;

namespace TaxiApplication.Controllers;

public class TariffController : Controller
{
    private readonly ILogger<TariffController> _logger;
    private readonly ITariffService _tariffService;
    private readonly IMapper _mapper;
    
    public TariffController(ILogger<TariffController> logger, ITariffService tariffService, IMapper mapper)
    {
        _logger = logger;
        _tariffService = tariffService;
        _mapper = mapper;
    }
    
    [HttpPost("newTariff")]
    public async Task<IActionResult> newTariff(TariffDto tariff)
    {
        var mappedTariff = _mapper.Map<TariffModel>(tariff);
        await  _tariffService.AddTariffAsync(mappedTariff);
        return Ok();
    }

    [HttpPut("updateTariff")]
    public async Task<IActionResult> updateTariff(int id ,TariffDto tariff)
    {
        var mappedTariff = _mapper.Map<TariffModel>(tariff);
        await _tariffService.UpdateTariffAsync(mappedTariff, id);
        return Ok();
    }

    [HttpDelete("deleteTariff")]
    public async Task<IActionResult> deleteTariff(int id)
    {
        await _tariffService.DeleteTariffAsync(id);
        return Ok();
    }

    [HttpGet("getAllTariffs")]
    public async Task<IActionResult> getAllTariffs()
    {
        var allTariffs = _tariffService.GetAllTariffs();
        var tariffs = _mapper.ProjectTo<TariffDto>(allTariffs);
        return Ok(await JsonConvert.SerializeObjectAsync(tariffs));
    }

    [HttpGet("getTariffById")]
    public async Task<IActionResult> getTariffById(int id)
    {
        var tariff =  await _tariffService.GetTariffById(id);
        var mappedTariff = _mapper.Map<TariffDto>(tariff);
        return Ok(await JsonConvert.SerializeObjectAsync(mappedTariff));
    }
    
}