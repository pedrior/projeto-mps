using EventHub.Business.Data;
using EventHub.Business.Entities.Users;
using EventHub.Core.Persistence;

namespace EventHub.Infrastructure.Persistence;

public sealed class DataContext : DbContext, IDataContext
{
    private DbSet<User>? users;
    
    public DbSet<User> Users => users ??= Set<User>();
}