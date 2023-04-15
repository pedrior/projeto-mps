using EventHub.Business.Entities.Users;
using EventHub.Utils.Persistence;

namespace EventHub.Business.Data;

public interface IDataContext
{
    DbSet<User> Users { get; }
}