using EventHub.Entities;
using EventHub.Infrastructure.Authentication.Providers;

namespace EventHub.Infrastructure.Authentication;

public sealed class GoogleAuthenticationAdapter : IAuthentication
{
    private readonly IGoggleAuthenticationProvider provider;

    public GoogleAuthenticationAdapter(IGoggleAuthenticationProvider provider)
    {
        this.provider = provider;
    }

    public User? Authenticate(string email, string password)
    {
        provider.AuthenticateWithGoogle();
        return null;
    }
}