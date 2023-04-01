namespace Microsoft.Extensions.DependencyInjection;

internal class AppBuilder : IAppBuilder
{
    public AppBuilder(IServiceCollection services)
    {
        Services = services;
    }

    public IServiceCollection Services { get; }
}