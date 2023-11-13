using TaxiApplication.DAL.Context;
using TaxiApplication.DAL.Entities;
using TaxiApplication.DAL.Repository.Classes;
using Test.Data;

namespace Test.DataRepositoriesTests;

public class TariffRepositoryTest
{
    [TestCase(1)]
    [TestCase(2)]
    public async Task TariffRepository_GetTariffByCarId_ReturnsTariff(int id)
    {
        // arrange
        
        using var context = new DBContext(UnitTestHelper.UnitTestGetDBOptioons());
        var tariffRepository = new TariffRepository(context);

        var car = RepositoryData.ExpectedCars.FirstOrDefault(x => x.id == id);
        var expected = RepositoryData.ExpectedTariffs.FirstOrDefault(x => x.cars.Any(y=>y.id == id));

        // act

        var result =  tariffRepository.GetTariffByCarId(id);
        var tariff = result.Cast<Tariff>();
        var resultTariff = tariff.First();

        // assert
        
        Assert.IsNotNull(resultTariff, message: "Expected not null");
        Assert.That(true, message: "Result is invalid");
    }
    
    [TestCase("Економ")]
    [TestCase("Стандарт")]
    [TestCase("Бізнес")]
    [TestCase("Мікроавтобус")]
    public async Task TariffRepository_GetTariffByName_ReturnsTariff(string name)
    {
        // arrange
        
        using var context = new DBContext(UnitTestHelper.UnitTestGetDBOptioons());
        var tariffRepository = new TariffRepository(context);

        var expected = RepositoryData.ExpectedTariffs.FirstOrDefault(x => x.name == name);

        // act

        var result =  tariffRepository.GetTariffByName(name);
        var tariff = result.Cast<Tariff>();
        var resultTariff = tariff.First();

        // assert
        
        Assert.IsNotNull(resultTariff, message: "Expected not null");
        Assert.That(true, message: "Result is invalid");
    }
}