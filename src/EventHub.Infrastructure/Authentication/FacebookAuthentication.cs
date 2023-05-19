using EventHub.Entities;
using EventHub.Infrastructure.Authentication.Providers;

namespace EventHub.Infrastructure.Authentication;

public sealed class FacebookAuthentication : IAuthentication
{
    private readonly IFacebookAuthenticationProvider provider;

    public FacebookAuthentication(IFacebookAuthenticationProvider provider)
    {
        this.provider = provider;
    }

    public User? Authenticate(string email, string password)
    {
        provider.AuthenticateWithFacebook();
        return null;
    }
}