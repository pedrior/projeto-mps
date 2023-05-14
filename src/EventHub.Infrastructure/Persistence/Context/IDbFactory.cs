namespace EventHub.Infrastructure.Persistence.Context;

public interface IDbFactory
{
    DbContext GetDefaultContext();
}