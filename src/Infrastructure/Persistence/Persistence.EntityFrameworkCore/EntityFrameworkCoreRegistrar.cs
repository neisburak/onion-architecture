using Application.Common.Interfaces;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Persistence.EntityFrameworkCore;
using Persistence.EntityFrameworkCore.Interceptors;
using Persistence.EntityFrameworkCore.Repositories;

namespace Microsoft.Extensions.DependencyInjection;

public static class EntityFrameworkCoreRegistrar
{
    public static IEntityFrameworkBuilder AddEntityFrameworkCore(this IAppBuilder builder)
    {
        builder.Services.TryAddScoped<AuditableEntitySaveChangesInterceptor>();

        builder.Services.TryAddScoped(typeof(IRepository<,>), typeof(Repository<,>));
        builder.Services.TryAddScoped(typeof(IRepository<>), typeof(Repository<>));

        builder.Services.TryAddScoped<IUnitOfWork, UnitOfWork>();

        builder.Services.TryAddScoped<IAsyncQueryExecuter, AsyncQueryExecuter>();

        builder.Services.TryAddScoped<IKanbanRepository, KanbanRepository>();
        builder.Services.TryAddScoped<IKanbanListRepository, KanbanListRepository>();
        builder.Services.TryAddScoped<IKanbanCardRepository, KanbanCardRepository>();

        return new EntityFrameworkBuilder(builder);
    }

    public static IEntityFrameworkBuilder AddDbContext(this IEntityFrameworkBuilder builder, Action<DbContextConfigurationOptions> optionsAction)
    {
        var configuration = new DbContextConfigurationOptions();
        optionsAction.Invoke(configuration);

        ArgumentNullException.ThrowIfNull(configuration.ConnectionString, nameof(DbContextConfigurationOptions));

        builder.Services.AddDbContext<DbContext, AppDbContext>(options => options.UseSqlServer(configuration.ConnectionString));

        return builder;
    }
}