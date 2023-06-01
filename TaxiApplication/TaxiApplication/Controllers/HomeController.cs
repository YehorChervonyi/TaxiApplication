using System.Diagnostics;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaxiApplication.BL.Services.Interfaces;
using TaxiApplication.Models;

namespace TaxiApplication.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return Map();
    }
    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Map()
    {
        return View();
    }

    public IActionResult SignIn()
    {
        return View();
    }

    public IActionResult LogIn()
    {
        return View();
    }
    public IActionResult Logout()
    {
        return Map();
    }
    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}