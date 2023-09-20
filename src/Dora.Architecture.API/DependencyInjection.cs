using Dora.Architecture.API.Services;
using Dora.Architecture.Application.Common.Interfaces.Services;

namespace Dora.Architecture.API;

public static class DependencyInjection
{
    public static IServiceCollection AddWebApiServices(this IServiceCollection services)
    {
        services
            .AddHttpContextAccessor()
            .AddScoped<ICurrentUserService, CurrentUserService>();

        return services;
    }
}
