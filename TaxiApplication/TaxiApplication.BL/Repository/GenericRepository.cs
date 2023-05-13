using TaxiApplication.DAL.Context;
using TaxiApplication.DAL.Entities;

namespace TaxiApplication.BL.Repository;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
{
    private readonly DBContext _context;

    public GenericRepository(DBContext context)
    {
        _context = context;
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        var result = await _context.Set<TEntity>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
        // _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.Set<TEntity>().FindAsync(id);
        if (entity != null)
        {
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
    
    public IQueryable<TEntity> GetAll()
    {
        return _context.Set<TEntity>().AsQueryable();
    }
}