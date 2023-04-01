namespace Microsoft.Extensions.DependencyInjection;

internal class EntityFrameworkBuilder : IEntityFrameworkBuilder
{
    public EntityFrameworkBuilder(IAppBuilder builder)
    {
        Services = builder.Services;
    }

    public IServiceCollection Services { get; }
}