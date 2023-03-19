using Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence.EntityFrameworkCore.Internal;

internal class EntityFrameworkBuilder : IEntityFrameworkBuilder
{
    public EntityFrameworkBuilder(IAppBuilder builder)
    {
        Services = builder.Services;
    }

    public IServiceCollection Services { get; }
}