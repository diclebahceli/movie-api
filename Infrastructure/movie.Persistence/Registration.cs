using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using movie.Application;
using movie.Application.Interfaces.UnitOfWorks;

namespace movie.Persistence;

public static class Registration
{
    public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlite(configuration.GetConnectionString("LiteConnection"));


        });
        services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
        services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
        services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
    }
}
