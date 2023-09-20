using Dora.Architecture.Domain.Constants;
using Dora.Architecture.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Dora.Architecture.EntityFrameworkCore;

public static class DependencyInjection
{
    public static IServiceCollection AddEfCore(this IServiceCollection services)
    {
        services
            .AddDbContextPool<DbContext, DoraDbContext>(opt => opt.UseInMemoryDatabase(AppConsts.APP_NAME))
            .AddScoped(typeof(IRepository<,>), typeof(Repository<,>))
            .AddScoped(typeof(IRepository<>), typeof(Repository<>));

        return services;
    }
}
