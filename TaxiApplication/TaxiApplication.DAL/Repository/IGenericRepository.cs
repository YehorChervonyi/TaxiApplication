using TaxiApplication.DAL.Entities;

namespace TaxiApplication.DAL.Repository;

public interface IGenericRepository<TEntity> where TEntity : BaseEntity
{
    Task<TEntity> AddAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity, int id);
    Task DeleteAsync(int id);
    IQueryable<TEntity> GetAll();
    Task<TEntity> GetById(int id);
}