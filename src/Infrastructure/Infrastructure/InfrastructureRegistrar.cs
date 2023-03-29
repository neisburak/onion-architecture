using Application.Interfaces;
using Infrastructure.Services;

namespace Microsoft.Extensions.DependencyInjection;

public static class InfrastructureRegistrar
{
    public static IAppBuilder AddInfrastructure(this IAppBuilder builder)
    {
        builder.Services.AddSingleton<ISystemClock, SystemClock>();

        return builder;
    }
}