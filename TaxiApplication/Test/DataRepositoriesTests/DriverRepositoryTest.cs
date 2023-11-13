using TaxiApplication.DAL.Context;
using TaxiApplication.DAL.Entities;
using TaxiApplication.DAL.Repository.Classes;
using Test.Data;

namespace Test.DataRepositoriesTests;

public class DriverRepositoryTest
{
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    [TestCase(4)]
    public async Task DriverRepository_GetDriversByCarId_ReturnsDriver(int id)
    {
        // arrange
        
        using var context = new DBContext(UnitTestHelper.UnitTestGetDBOptioons());
        var driverRepository = new DriverRepository(context);

        var expected = RepositoryData.ExpectedDrivers.FirstOrDefault(x => x.cars.Any(y=> y.id == id));

        // act

        var result =  driverRepository.GetDriversByCarId(id);
        var driver = result.Cast<Driver>();
        var resultDriver = driver.First();

        // assert
        
        Assert.IsNotNull(resultDriver, message: "Expected not null");
        Assert.That(true, message: "Result is invalid");
    }
    
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    [TestCase(4)]
    public async Task DriverRepository_GetDriversByOrderId_ReturnsDriver(int id)
    {
        // arrange
        
        using var context = new DBContext(UnitTestHelper.UnitTestGetDBOptioons());
        var driverRepository = new DriverRepository(context);
        
        var expected = RepositoryData.ExpectedDrivers.FirstOrDefault(x => x.orders.Any(y=> y.id == id));

        // act

        var result =  driverRepository.GetDriversByOrderId(id);
        var driver = result.Cast<Driver>();
        var resultDriver = driver.First();

        // assert
        
        Assert.IsNotNull(resultDriver, message: "Expected not null");
        Assert.That(true, message: "Result is invalid");
    }
}