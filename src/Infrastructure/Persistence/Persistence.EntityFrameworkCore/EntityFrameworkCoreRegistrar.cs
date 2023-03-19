using System;
using Application.Interfaces;
using Persistence.EntityFrameworkCore;
using Persistence.EntityFrameworkCore.Internal;

namespace Microsoft.Extensions.DependencyInjection;

public static class EntityFrameworkCoreRegistrar
{
    public static IEntityFrameworkBuilder AddEntityFrameworkCore(this IAppBuilder builder)
    {
        return new EntityFrameworkBuilder(builder);
    }

    public static IEntityFrameworkBuilder AddDbContext(this IEntityFrameworkBuilder builder, Action<DbContextOptions> options)
    {
        return builder;
    }
}