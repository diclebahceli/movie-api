using movie.Domain;

namespace movie.Application;

public interface IWriteRepository<T> where T : class, IEntityBase, new()
{

    Task AddAsync(T entity);
    Task AddRangeAsync(IList<T> entities);
    Task<T> UpdateAsync(T entity);
    Task SoftDeleteAsync(T entity);
    Task HardDeleteAsync(T entity);

}
