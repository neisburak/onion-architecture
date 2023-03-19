using Microsoft.Extensions.DependencyInjection;

namespace Application.Interfaces;

public interface IAppBuilder
{
    IServiceCollection Services { get; }
}