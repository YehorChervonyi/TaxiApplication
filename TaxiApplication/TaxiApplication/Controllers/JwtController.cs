using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TaxiApplication.BL.Models;
using TaxiApplication.BL.Services.Interfaces;

namespace TaxiApplication.Controllers;

public class JwtController: Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IJwtService _jwtService;
    private readonly IConfiguration _configuration;

    public JwtController(ILogger<HomeController> logger, IJwtService jwtService, IConfiguration configuration)
    {
        _jwtService = jwtService;
        _logger = logger;
        _configuration = configuration;
    }
    
    
    [HttpPost("createToken")]
    public async Task<IActionResult> CreateToken([FromBody]UserModel user)
    {
        return Ok(_jwtService.CreateJWT(user, _configuration));
    }
    
    [Authorize]
    [HttpGet("getUserId")]
    public async Task<IActionResult> getUserId(string token)
    {
        return Ok(_jwtService.GetId(token));
    }
}