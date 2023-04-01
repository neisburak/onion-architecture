namespace Microsoft.Extensions.DependencyInjection;

public interface IAppBuilder
{
    IServiceCollection Services { get; }
}