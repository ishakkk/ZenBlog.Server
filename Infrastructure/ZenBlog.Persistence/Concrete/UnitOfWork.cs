using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Persistence.Context;

namespace ZenBlog.Persistence.Concrete;

public class UnitOfWork(AppDbContext _appDbContext) : IUnitOfWork
{
    public async Task<bool> SaveChangesAsync()
    {
        return await _appDbContext.SaveChangesAsync() > 0;
    }
}
