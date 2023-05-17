using TaxiApplication.DAL.Context;
using TaxiApplication.DAL.Entities;
using TaxiApplication.DAL.Repository.Interfaces;

namespace TaxiApplication.DAL.Repository.Classes;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(DBContext context) : base(context)
    {
        
    }
}