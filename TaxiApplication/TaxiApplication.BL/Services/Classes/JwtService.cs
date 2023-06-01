using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TaxiApplication.BL.Models;
using TaxiApplication.BL.Services.Interfaces;

namespace TaxiApplication.BL.Services.Classes;

public class JwtService: IJwtService
{
    public string CreateJWT(UserModel user, IConfiguration configuration)
    {
        var secretkey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(configuration["SecretKey"]));
        var credentials = new SigningCredentials(secretkey, SecurityAlgorithms.HmacSha256Signature);

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.name),
            new Claim(JwtRegisteredClaimNames.Sub, user.name),
            new Claim(JwtRegisteredClaimNames.Sub, user.surname),
            new Claim("id", user.id.ToString()),
            new Claim(JwtRegisteredClaimNames.UniqueName, user.login),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N"))
        };

        var token = new JwtSecurityToken(issuer: "Auth", audience: "Auth", claims: claims, expires: DateTime.Now.AddDays(1), signingCredentials: credentials);
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public int GetId(string token)
    {
        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        JwtSecurityToken jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;
        string userId = jwtToken.Claims.First(c => c.Type == "id").Value;
        return Int32.Parse(userId);
    }
}