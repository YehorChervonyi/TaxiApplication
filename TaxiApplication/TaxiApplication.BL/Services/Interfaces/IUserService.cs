using TaxiApplication.BL.Models;

namespace TaxiApplication.BL.Services.Interfaces;

public interface IUserService
{
    Task AddUserAsync(UserModel user);
    Task UpdateUserAsync(UserModel user, int id);
    Task DeleteUserAsync(int id);
    IQueryable GetAllUsers();
    Task<UserModel> GetUserById(int id);
    IQueryable GetUserByOrderId(int id);
    IQueryable GetUserByLogin(string login);
}