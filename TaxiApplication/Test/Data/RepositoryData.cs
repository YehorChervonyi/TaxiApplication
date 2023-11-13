﻿using TaxiApplication.DAL.Entities;

namespace Test.Data;

public class RepositoryData
{
    public static IEnumerable<User> ExpectedUsers =>
        new List<User>
        {
            new User
            { id = 1, name = "Андрій", surname = "Ткаченко", phone = "123123", login = "login1", password = "pass1", },
            new User
            { id = 2, name = "Борис", surname = "Кравчук", phone = "123123", login = "login2", password = "pass2", }
        };

    public static IEnumerable<Tariff> ExpectedTariffs =>
        new List<Tariff>
        {
            new Tariff()
                { id = 1, name = "Економ", price = 8, fee = 35 },
            new Tariff()
                { id = 2, name = "Стандарт", price = 9, fee = 40 },
            new Tariff()
                { id = 3, name = "Бізнес", price = 11, fee = 50 },
            new Tariff()
                { id = 4, name = "Мікроавтобус", price = 11, fee = 70 }
        };

    public static IEnumerable<Driver> ExpectedDrivers =>
        new List<Driver>
        {
            new Driver()
            { id = 1, name = "Василь", surname = "Ткач", experience = 1, status = 1, },
            new Driver()
            { id = 2, name = "Всеволод", surname = "Білоус", experience = 2, status = 1, },
            new Driver()
            { id = 3, name = "Данило", surname = "Дяченко", experience = 2, status = 1, },
            new Driver()
            { id = 4, name = "Євген", surname = "Мазур", experience = 2, status = 1, }
        };

    public static IEnumerable<Car> ExpectedCars =>
        new List<Car>
        {
            new Car()
            { id = 1, tariffId = 1, driverId = 1, plate = "ВА1234АВ", brand = "Daewoo", model = "Lanos", seats = 4 },
            new Car()
            { id = 2, tariffId = 2, driverId = 2, plate = "АР7642АВ", brand = "Ford", model = "Mondeo", seats = 4 },
            new Car()
            { id = 3, tariffId = 3, driverId = 1, plate = "ВА2345АВ", brand = "Mercedes-Benz", model = "S350d L", seats = 4 },
            new Car()
            { id = 4, tariffId = 4, driverId = 2, plate = "КА4567АA", brand = "Mercedes-Benz", model = "Vito", seats = 9 }
        };

    public static IEnumerable<Order> ExpectedOrders =>
        new List<Order>
        {
            new Order()
            { id = 1, userId = 1, driverId = 2, start = "start", finish = "finish", status = 0, price = 123, timeStart = new DateTime(), timeFinish = new DateTime() },
            new Order() 
            { id = 2, userId = 2, driverId = 1, start = "start", finish = "finish", status = 0, price = 123, timeStart = new DateTime(), timeFinish = new DateTime() },
            new Order()
            { id = 3, userId = 2, driverId = 1, start = "start", finish = "finish", status = 0, price = 123, timeStart = new DateTime(), timeFinish = new DateTime() },
            new Order()
            { id = 4, userId = 1, driverId = 2, start = "start", finish = "finish", status = 0, price = 123, timeStart = new DateTime(), timeFinish = new DateTime() }
        };
}