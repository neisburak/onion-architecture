using Application.Common.Interfaces;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.Extensions.DependencyInjection;

public static class InfrastructureRegistrar
{
    public static IAppBuilder AddInfrastructure(this IAppBuilder builder)
    {
        builder.Services.TryAddSingleton<ISystemClock, SystemClock>();

        return builder;
    }
}