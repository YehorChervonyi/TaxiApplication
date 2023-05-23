using TaxiApplication.DAL.Context;
using TaxiApplication.DAL.Entities;
using TaxiApplication.DAL.Repository.Interfaces;

namespace TaxiApplication.DAL.Repository.Classes;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(DBContext context) : base(context)
    {
        
    }
    
    public IQueryable GetUserByOrderId(int id)
    {
        var users = GetAll().Where(user => user.orders.Any(order => order.id == id));
        return users;
    }

    public IQueryable GetUserByLogin(string login)
    {
        var users = GetAll().Where(user => user.login == login);
        return users;
    }
}