using TaxiApplication.DAL.Entities;

namespace TaxiApplication.BL.Repository;

public interface IGenericRepository<TEntity> where TEntity : BaseEntity
{
    Task<TEntity> AddAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity);
    Task DeleteAsync(int id);
    IQueryable<TEntity> GetAll();
}