using System.Linq.Expressions;
using ZenBlog.Domain.Entities.Common;

namespace ZenBlog.Application.Contracts.Persistence;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
    Task<List<TEntity>> GetAllAsync();

    IQueryable<TEntity> GetQueryAsync();
    Task<TEntity> GetByIdAsync(Guid id);
    Task CreateAsync(TEntity entity);
    Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> filter);
    void DeleteAsync(TEntity entity);

    void UpdateAsync(TEntity entity);
}
