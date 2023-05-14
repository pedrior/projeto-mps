using EventHub.Entities;

namespace EventHub.Infrastructure.Persistence.Repositories;

public interface IUserRepository : IRepository<User>
{
    User? FindByEmail(string email);
}