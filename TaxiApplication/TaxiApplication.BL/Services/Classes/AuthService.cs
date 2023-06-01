using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TaxiApplication.BL.Models;
using TaxiApplication.BL.Services.Interfaces;
using TaxiApplication.DAL.Entities;

namespace TaxiApplication.BL.Services.Classes;

public class AuthService: IAuthService
{
    private readonly IUserService _userService;
    private readonly IJwtService _jwtService;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;

    public AuthService(IUserService userService, IJwtService jwtService, IMapper mapper, IConfiguration configuration)
    {
        _userService = userService;
        _jwtService = jwtService;
        _mapper = mapper;
        _configuration = configuration;
    }
    
    
    public async Task Registrate(UserModel user)
    {
        if (! await CheckForLogin(user))
        {
            if (! await CheckForPhone(user))
            {
                await _userService.AddUserAsync(user);
            }
        }
    }

    public async Task<string?> Login(UserModel user)
    {
        if (await CheckLogining(user))
        {
            var users = _userService.GetUserByLogin(user.login);
            var forUser = _mapper.ProjectTo<User>(users).First();
            var token = _jwtService.CreateJWT(_mapper.Map<UserModel>(forUser), _configuration);
            return token;
        }

        return null;
    }
    
    public async Task<bool> CheckForLogin(UserModel user)
    {
        var users = _userService.GetAllUsers();
        var mappedUsers = _mapper.ProjectTo<User>(users);
        return await mappedUsers.AnyAsync(users => users.login == user.login);
    }
    
    public async Task<bool> CheckLogining(UserModel user)
    {
        var users = _userService.GetUserByLogin(user.login);
        var mappedUsers = _mapper.ProjectTo<User>(users);
        return await mappedUsers.AnyAsync(users => users.password == user.password);

    }
    
    public async Task<bool> CheckForPhone(UserModel user)
    {
        var users = _userService.GetAllUsers();
        var mappedUsers = _mapper.ProjectTo<User>(users);
        return await mappedUsers.AnyAsync(users => users.phone == user.phone);
    }
    
}