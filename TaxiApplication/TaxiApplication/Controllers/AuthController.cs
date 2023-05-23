using System.Net.Http.Headers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TaxiApplication.BL.Models;
using TaxiApplication.BL.Services.Interfaces;
using TaxiApplication.DTOs;

namespace TaxiApplication.Controllers;

public class AuthController : Controller
{
    private readonly ILogger<CarController> _logger;
    private readonly IAuthService _authService;
    private readonly IMapper _mapper;

    public AuthController(ILogger<CarController> logger, IAuthService authService, IMapper mapper)
    {
        _logger = logger;
        _authService = authService;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<IActionResult> register(UserDto user)
    {
        var mappedUser = _mapper.Map<UserModel>(user);
        await _authService.Registrate(mappedUser);
        return Ok();
    }
    
    [HttpGet("login")]
    public async Task<IActionResult> login(UserDto user)
    {
        var mappedUser = _mapper.Map<UserModel>(user);
        var result = await _authService.Login(mappedUser);
        Request.Headers.Add("Bearer", result);
        return Ok(await JsonConvert.SerializeObjectAsync(result));
    }

    [HttpGet("checkForLogin")]
    public async Task<IActionResult> checkForLogin(UserDto user)
    {
        var mappedUser = _mapper.Map<UserModel>(user);
        var result = await _authService.CheckForLogin(mappedUser);
        return Ok(await JsonConvert.SerializeObjectAsync(result));
    }
    [HttpGet("checkPhone")]
    public async Task<IActionResult> checkPhone(UserDto user)
    {
        var mappedUser = _mapper.Map<UserModel>(user);
        var result = await _authService.CheckForPhone(mappedUser);
        return Ok(await JsonConvert.SerializeObjectAsync(result));
    }
    [HttpGet("checkLogining")]
    public async Task<IActionResult> checkLogining(UserDto user)
    {
        var mappedUser = _mapper.Map<UserModel>(user);
        var result = await _authService.CheckLogining(mappedUser);
        return Ok(await JsonConvert.SerializeObjectAsync(result));
    }

    // [HttpPost("logout")]
    // public async Task<IActionResult> logout()
    // {
    //     return Ok();
    // }
}