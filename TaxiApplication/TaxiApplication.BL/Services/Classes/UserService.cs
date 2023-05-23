using AutoMapper;
using AutoMapper.QueryableExtensions;
using TaxiApplication.BL.Models;
using TaxiApplication.BL.Services.Interfaces;
using TaxiApplication.DAL.Entities;
using TaxiApplication.DAL.Repository.Interfaces;

namespace TaxiApplication.BL.Services.Classes;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task AddUserAsync(UserModel user)
    {
        var mappedUser = _mapper.Map<User>(user);
        await _userRepository.AddAsync(mappedUser);
    }

    public async Task UpdateUserAsync(UserModel user, int id)
    {
        var mappedUser = _mapper.Map<User>(user);
        await _userRepository.UpdateAsync(mappedUser, id);
    }

    public async Task DeleteUserAsync(int id)
    {
        await _userRepository.DeleteAsync(id);
    }

    public IQueryable GetAllUsers()
    {
        var users =  _userRepository.GetAll();
        return _mapper.ProjectTo<UserModel>(users);
    }

    public async Task<UserModel> GetUserById(int id)
    {
        var user = await _userRepository.GetById(id);
        return _mapper.Map<UserModel>(user);
    }

    public IQueryable GetUserByOrderId(int id)
    {
        var user = _userRepository.GetUserByOrderId(id);
        return _mapper.ProjectTo<UserModel>(user);
    }
    public IQueryable GetUserByLogin(string login)
    {
        var user = _userRepository.GetUserByLogin(login);
        return _mapper.ProjectTo<UserModel>(user);
    }
}