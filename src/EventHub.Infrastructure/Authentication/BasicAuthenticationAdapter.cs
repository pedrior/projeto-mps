using EventHub.Entities;
using EventHub.Infrastructure.Persistence.Repositories;

namespace EventHub.Infrastructure.Authentication;

public sealed class BasicAuthenticationAdapter : IAuthentication
{
    private readonly IUserRepository userRepository;

    public BasicAuthenticationAdapter(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }
    
    public User? Authenticate(string email, string password)
    {
        var user = userRepository.FindByEmail(email);
        return user == null ? null : user.Password != password ? null : user;
    }
}