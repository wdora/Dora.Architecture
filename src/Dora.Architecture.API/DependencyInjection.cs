using Dora.Architecture.API.Services;
using Dora.Architecture.Application.Common.Interfaces.Services;
using Hangfire;
using Hangfire.InMemory;

namespace Dora.Architecture.API;

public static class DependencyInjection
{
    public static IServiceCollection AddWebApiServices(this IServiceCollection services)
    {
        services
            .AddHangfire(config => config.UseStorage(new InMemoryStorage()))
            .AddHangfireServer()
            .AddHttpContextAccessor()
            .AddScoped<ICurrentUserService, CurrentUserService>();

        return services;
    }
}
