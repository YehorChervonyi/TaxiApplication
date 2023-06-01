using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TaxiApplication.BL.Models;
using TaxiApplication.BL.Services.Interfaces;
using TaxiApplication.DTOs;

namespace TaxiApplication.Controllers;
public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UserController(ILogger<UserController> logger, IUserService userService, IMapper mapper)
    {
        _logger = logger;
        _userService = userService;
        _mapper = mapper;
    }
    
    [HttpPost("newUser")]
    public async Task<IActionResult> newUser(UserDto user)
    {
        var mappedUser = _mapper.Map<UserModel>(user);
        await _userService.AddUserAsync(mappedUser);
        return Ok();
    }

    [HttpPut("updateUser")]
    public async Task<IActionResult> updateUser(int id, UserDto user)
    {
        var mappedUser = _mapper.Map<UserModel>(user);
        await _userService.UpdateUserAsync(mappedUser, id);
        return Ok();
    }

    [HttpDelete("deleteUser")]
    public async Task<IActionResult> deleteUser(int id)
    {
        await _userService.DeleteUserAsync(id);
        return Ok();
    }

    [HttpGet("getAllUsers")]
    public async Task<IActionResult> AllUsers()
    {
        var allUsers =  _userService.GetAllUsers();
        var users =  _mapper.ProjectTo<UserDto>(allUsers);
        return Ok(await JsonConvert.SerializeObjectAsync(users));
    }
    
    [HttpGet("getUserById")]
    public async Task<IActionResult> getUserById( int id)
    {
       var user = await _userService.GetUserById(id);
       var mappedUser = _mapper.Map<UserDto>(user);
       
       return Ok(mappedUser);
    }
    
    [HttpGet("getUserByOrderId")]
    public async Task<IActionResult> getUserByOrderId(int id)
    {
        var allUsers =  _userService.GetUserByOrderId(id);
        var users =  _mapper.ProjectTo<UserDto>(allUsers);
        return Ok(await JsonConvert.SerializeObjectAsync(users));
    }
    
    [HttpGet("getUserByLogin")]
    public async Task<IActionResult> getUserByLogin(string login)
    {
        var allUsers =  _userService.GetUserByLogin(login);
        var users =  _mapper.ProjectTo<UserDto>(allUsers);
        return Ok(await JsonConvert.SerializeObjectAsync(users));
    }
    
}