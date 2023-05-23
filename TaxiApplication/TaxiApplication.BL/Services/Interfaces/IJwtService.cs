using Microsoft.Extensions.Configuration;
using TaxiApplication.BL.Models;

namespace TaxiApplication.BL.Services.Interfaces;

public interface IJwtService
{
     string CreateJWT(UserModel user, IConfiguration configuration);
     int GetId(string token);
}