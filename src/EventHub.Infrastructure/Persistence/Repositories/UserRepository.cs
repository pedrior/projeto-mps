using EventHub.Entities;
using EventHub.Infrastructure.Persistence.Context;

namespace EventHub.Infrastructure.Persistence.Repositories;

public sealed class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(DbContext context) : base(context)
    {
    }

    public User? FindByEmail(string email) =>
        Set.AsQueryable().FirstOrDefault(x => x.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
}