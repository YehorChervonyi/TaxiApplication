using TaxiApplication.DAL.Context;
using TaxiApplication.DAL.Entities;
using TaxiApplication.DAL.Repository.Classes;
using Test.Data;

namespace Test.DataRepositoriesTests;

public class OrderRepositoryTest
{
    [TestCase(1)]
    [TestCase(2)]
    public async Task OrderRepository_GetOrdersByUserId_ReturnsOrder(int id)
    {
        // arrange
        
        using var context = new DBContext(UnitTestHelper.UnitTestGetDBOptioons());
        var orderRepository = new OrderRepository(context);
        var user = RepositoryData.ExpectedUsers.FirstOrDefault(x => x.id == id);
        var expected = RepositoryData.ExpectedOrders.FirstOrDefault(x => x.userId == user.id);

        // act

        var result =  orderRepository.GetOrdersByUserId(id);
        var order = result.Cast<Order>();
        var resultOrder = order.First();

        // assert
        
        Assert.IsNotNull(resultOrder, message: "Expected not null");
        Assert.That(resultOrder, Is.EqualTo(expected).Using(new Comparator.OrderEqualityComparer()), message: "Result is invalid");
    }
    
    [TestCase(1)]
    [TestCase(2)]
    public async Task OrderRepository_GetOrdersByDriverId_ReturnsOrder(int id)
    {
        // arrange
        
        using var context = new DBContext(UnitTestHelper.UnitTestGetDBOptioons());
        var orderRepository = new OrderRepository(context);
        var driver = RepositoryData.ExpectedDrivers.FirstOrDefault(x => x.id == id);
        var expected = RepositoryData.ExpectedOrders.FirstOrDefault(x => x.driverId == driver.id);

        // act

        var result =  orderRepository.GetOrdersByDriverId(id);
        var order = result.Cast<Order>();
        var resultOrder = order.First();

        // assert
        
        Assert.IsNotNull(resultOrder, message: "Expected not null");
        Assert.That(resultOrder, Is.EqualTo(expected).Using(new Comparator.OrderEqualityComparer()), message: "Result is invalid");
    }
}