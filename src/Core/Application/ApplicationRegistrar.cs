using Application.Interfaces;
using Application.Internal;

namespace Microsoft.Extensions.DependencyInjection;

public static class ApplicationRegistrar
{
    public static IAppBuilder AddApplication(this IServiceCollection services)
    {
        return new AppBuilder(services);
    }
}