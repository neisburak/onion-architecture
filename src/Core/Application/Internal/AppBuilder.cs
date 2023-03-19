using Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Internal;

internal class AppBuilder : IAppBuilder
{
    public AppBuilder(IServiceCollection services)
    {
        Services = services;
    }

    public IServiceCollection Services { get; }
}