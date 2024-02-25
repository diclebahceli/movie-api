using Microsoft.EntityFrameworkCore;
using movie.Application;
using movie.Application.Interfaces.UnitOfWorks;

namespace movie.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private AppDbContext dbContext;

    public UnitOfWork(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async ValueTask DisposeAsync() => await dbContext.DisposeAsync();


    public int SaveChanges() => dbContext.SaveChanges();

    public async Task<int> SaveChangesAsync() => await dbContext.SaveChangesAsync();
    IReadRepository<T> IUnitOfWork.GetReadRepository<T>() => new ReadRepository<T>(dbContext);

    IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>() => new WriteRepository<T>(dbContext);
}
