using TaxiApplication.DAL.Context;
using TaxiApplication.DAL.Entities;
using TaxiApplication.DAL.Repository.Classes;
using Test.Data;

namespace Test.DataRepositoriesTests;

public class UserRepositoryTest
{
    [TestCase("login1")]
    [TestCase("login2")]
    public async Task UserReposytory_GetUserByLogin_ReturnsUser(string login)
    {
        // arrange
        
        using var context = new DBContext(UnitTestHelper.UnitTestGetDBOptioons());
        var userRepository = new UserRepository(context);

        var expected = RepositoryData.ExpectedUsers.FirstOrDefault(x => x.login.ToString() == login);

        // act

        var result =  userRepository.GetUserByLogin(login);
        var user = result.Cast<User>();
        var resultUser = user.First();

        // assert
        
        Assert.IsNotNull(resultUser, message: "Expected not null");
        Assert.That(resultUser, Is.EqualTo(expected).Using(new Comparator.UserEqualityComparer()), message: "Result is invalid");
    }
    
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    [TestCase(4)]
    public async Task UserReposytory_GetUserByOrderId_ReturnsUser(int id)
    {
        // arrange
        
        using var context = new DBContext(UnitTestHelper.UnitTestGetDBOptioons());
        var userRepository = new UserRepository(context);

        var order = RepositoryData.ExpectedOrders.FirstOrDefault(x=> x.id == id);
        var expected = RepositoryData.ExpectedUsers.FirstOrDefault(x => x.id == order.userId);

        // act

        var result =  userRepository.GetUserByOrderId(id);
        var user = result.Cast<User>();
        var resultUser = user.First();

        // assert
        
        Assert.IsNotNull(resultUser, message: "Expected not null");
        Assert.That(resultUser, Is.EqualTo(expected).Using(new Comparator.UserEqualityComparer()), message: "Result is invalid");
    }
}