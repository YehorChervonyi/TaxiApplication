using TaxiApplication.BL.Models;

namespace TaxiApplication.BL.Services.Interfaces;

public interface IAuthService
{
    Task Registrate(UserModel user);
    Task<string?> Login(UserModel user);

    Task<bool> CheckForLogin(UserModel user);
    Task<bool> CheckForPhone(UserModel user);
    Task<bool> CheckLogining(UserModel user);
}