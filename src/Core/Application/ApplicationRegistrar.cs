using Application.KanbanCards;
using Application.KanbanLists;
using Application.Kanbans;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.Extensions.DependencyInjection;

public static class ApplicationRegistrar
{
    public static IAppBuilder AddApplication(this IServiceCollection services)
    {
        services.TryAddScoped<IKanbanService, KanbanManager>();
        services.TryAddScoped<IKanbanListService, KanbanListManager>();
        services.TryAddScoped<IKanbanCardService, KanbanCardManager>();

        return new AppBuilder(services);
    }
}