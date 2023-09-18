using Dora.Architecture.Application.Common.Interfaces;
using Dora.Architecture.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Dora.Architecture.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        return services.AddSingleton<IEmailSender, SmtpEmailSender>();
    }
}
