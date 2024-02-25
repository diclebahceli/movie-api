using Microsoft.EntityFrameworkCore;
using movie.Application;
using movie.Domain;

namespace movie.Persistence;

public class WriteRepository<T> : IWriteRepository<T> where T : class, IEntityBase, new()
{

    private DbContext dbContext;
    private DbSet<T> Table => dbContext.Set<T>();

    public WriteRepository(DbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public async Task AddAsync(T entity)
    {
        await dbContext.AddAsync(entity);
    }

    public async Task AddRangeAsync(IList<T> entities)
    {
        await dbContext.AddRangeAsync(entities);
    }

    public async Task HardDeleteAsync(T entity)
    {
        await Task.Run(() => dbContext.Remove(entity));
    }

    public async Task SoftDeleteAsync(T entity)
    {
        (entity as EntityBase).IsDeleted = true;
        await UpdateAsync(entity);
    }

    public async Task<T> UpdateAsync(T entity)
    {
        await Task.Run(() => dbContext.Update(entity));
        return entity;
    }
}
