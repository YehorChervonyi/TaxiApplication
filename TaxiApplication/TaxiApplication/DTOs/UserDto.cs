﻿namespace TaxiApplication.DTOs;

public class UserDto
{
    public int id { get; set; }
    public string name { get; set; }
    public string? surname { get; set; }
    public string phone { get; set; }
    public string login { get; set; }
    public string password { get; set; }
}