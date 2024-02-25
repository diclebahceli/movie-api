using movie.Domain;

namespace movie.Application.Interfaces.UnitOfWorks;
public interface IUnitOfWork : IAsyncDisposable
{
    IReadRepository<T> GetReadRepository<T>() where T : class, IEntityBase, new();
    IWriteRepository<T> GetWriteRepository<T>() where T : class, IEntityBase, new();
    Task<int> SaveChangesAsync();
    int SaveChanges();
}
