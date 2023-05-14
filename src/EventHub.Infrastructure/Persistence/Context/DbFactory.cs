using EventHub.Infrastructure.Persistence.Context.JsonDb;

namespace EventHub.Infrastructure.Persistence.Context;

public sealed class DbFactory : IDbFactory
{
    private static readonly Lazy<DbContext> JsonDbContextInstance =
        new(() => new JsonDbContext(), LazyThreadSafetyMode.PublicationOnly);

    public DbContext GetDefaultContext() => JsonDbContextInstance.Value;
}