using Application.Interfaces;

namespace Microsoft.Extensions.DependencyInjection;

public static class InfrastructureRegistrar
{
    public static IAppBuilder AddInfrastructure(this IAppBuilder builder)
    {
        return builder;
    }
}