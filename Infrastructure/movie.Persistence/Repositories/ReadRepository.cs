using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using movie.Application;
using movie.Domain;

namespace movie.Persistence;

public class ReadRepository<T> : IReadRepository<T> where T : class, IEntityBase, new()
{
    private DbContext dbContext;
    private DbSet<T> Table { get => dbContext.Set<T>(); }

    public ReadRepository(DbContext dbContext)
    {
        this.dbContext = dbContext;
    }


    public async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null)
    {
        IQueryable<T> query = Table;
        if (predicate is not null) query = query.Where(predicate);
        return await query.CountAsync();
    }

    public IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool enableTracking = false)
    {
        IQueryable<T> query = Table;
        if (!enableTracking) query = query.AsNoTracking();
        return query.Where(predicate);


    }

    public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool enableTracking = false)
    {
        IQueryable<T> query = Table;
        if (!enableTracking) query = query.AsNoTracking();
        if (include is not null) query = include(query);
        if (predicate is not null) query = query.Where(predicate);
        if (orderBy is not null) query = orderBy(query);
        return await query.ToListAsync();
    }

    public async Task<IList<T>> GetAllByPagingAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool enableTracking = false, int currentPage = 1, int pageSize = 3)
    {
        IQueryable<T> query = Table;
        if (!enableTracking) query = query.AsNoTracking();
        if (include is not null) query = include(query);
        if (predicate is not null) query = query.Where(predicate);
        if (orderBy is not null) query = orderBy(query);
        query.Skip((currentPage - 1) * pageSize).Take(pageSize);
        return await query.ToListAsync();

    }

    public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool enableTracking = false)
    {
        IQueryable<T> query = Table;
        if (!enableTracking) query = query.AsNoTracking();
        if (include is not null) query = include(query);
        query = query.Where(predicate);
        return await query.FirstOrDefaultAsync();
    }
}
