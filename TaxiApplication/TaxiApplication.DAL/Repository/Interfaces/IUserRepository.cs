using TaxiApplication.DAL.Entities;

namespace TaxiApplication.DAL.Repository.Interfaces;

public interface IUserRepository : IGenericRepository<User>
{
    IQueryable GetUserByOrderId(int id);
    IQueryable GetUserByLogin(string login);
}