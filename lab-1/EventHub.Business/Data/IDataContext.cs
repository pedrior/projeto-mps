using EventHub.Business.Entities.Users;
using EventHub.Core.Persistence;

namespace EventHub.Business.Data;

public interface IDataContext
{
    DbSet<User> Users { get; }
}