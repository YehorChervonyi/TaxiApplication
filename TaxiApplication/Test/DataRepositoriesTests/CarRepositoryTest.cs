using TaxiApplication.DAL.Context;
using TaxiApplication.DAL.Entities;
using TaxiApplication.DAL.Repository.Classes;
using Test.Data;

namespace Test.DataRepositoriesTests;

public class CarRepositoryTest
{
    [TestCase(1)]
    [TestCase(2)]
    public async Task CarRepository_GetCarByDriverId_ReturnsCar(int id)
    {
        // arrange
        
        using var context = new DBContext(UnitTestHelper.UnitTestGetDBOptioons());
        var carRepository = new CarRepository(context);

        var driver = RepositoryData.ExpectedDrivers.FirstOrDefault(x => x.id == id);
        var expected = RepositoryData.ExpectedCars.FirstOrDefault(x => x.driverId == driver.id);

        // act

        var result =  carRepository.GetCarByDriverId(id);
        var car = result.Cast<Car>();
        var resultCar = car.First();

        // assert
        
        Assert.IsNotNull(resultCar, message: "Expected not null");
        Assert.That(resultCar, Is.EqualTo(expected).Using(new Comparator.CarEqualityComparer()), message: "Result is invalid");
    }
    
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    [TestCase(4)]
    public async Task CarRepository_GetCarByTariffId_ReturnsCar(int id)
    {
        // arrange
        
        using var context = new DBContext(UnitTestHelper.UnitTestGetDBOptioons());
        var carRepository = new CarRepository(context);

        var tariff = RepositoryData.ExpectedTariffs.FirstOrDefault(x => x.id == id);
        var expected = RepositoryData.ExpectedCars.FirstOrDefault(x => x.tariffId == tariff.id);

        // act

        var result =  carRepository.GetCarByTariffId(id);
        var car = result.Cast<Car>();
        var resultCar = car.First();

        // assert
        
        Assert.IsNotNull(resultCar, message: "Expected not null");
        Assert.That(resultCar, Is.EqualTo(expected).Using(new Comparator.CarEqualityComparer()), message: "Result is invalid");
    }
}