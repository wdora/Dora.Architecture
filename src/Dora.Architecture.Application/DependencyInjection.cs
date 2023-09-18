using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Dora.Architecture.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services.AddMediatR(typeof(DependencyInjection).Assembly);
    }
}
