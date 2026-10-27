using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Domain.Entities.Common;
using ZenBlog.Persistence.Context;

namespace ZenBlog.Persistence.Concrete;

public class GenericRepository<TEntity>(AppDbContext _appDbContext) : IRepository<TEntity> where TEntity : BaseEntity
{
    private readonly DbSet<TEntity> _table = _appDbContext.Set<TEntity>();
    public async Task CreateAsync(TEntity entity)
    {
        await _table.AddAsync(entity);
    }

    public void DeleteAsync(TEntity entity)
    {
        _table.Remove(entity);
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        return await _table.AsNoTracking().ToListAsync();
    }

    public async Task<TEntity> GetByIdAsync(Guid id)
    {
        return await _table.FindAsync(id);
    }

    public IQueryable<TEntity> GetQueryAsync()
    {
        return _table;
    }

    public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> filter)
    {
        return await _table.AsNoTracking().FirstOrDefaultAsync(filter);
    }

    public void UpdateAsync(TEntity entity)
    {
        _table.Update(entity);
    }
}
