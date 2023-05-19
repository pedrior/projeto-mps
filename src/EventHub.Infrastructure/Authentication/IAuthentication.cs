using EventHub.Entities;

namespace EventHub.Infrastructure.Authentication;

public interface IAuthentication
{
    User? Authenticate(string email, string password);
}