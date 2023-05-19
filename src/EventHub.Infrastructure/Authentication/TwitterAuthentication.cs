using EventHub.Entities;
using EventHub.Infrastructure.Authentication.Providers;

namespace EventHub.Infrastructure.Authentication;

public sealed class TwitterAuthentication : IAuthentication
{
    private readonly ITwitterAuthenticationProvider provider;

    public TwitterAuthentication(ITwitterAuthenticationProvider provider)
    {
        this.provider = provider;
    }

    public User? Authenticate(string email, string password)
    {
        provider.AuthenticateWithTwitter();
        return null;
    }
}