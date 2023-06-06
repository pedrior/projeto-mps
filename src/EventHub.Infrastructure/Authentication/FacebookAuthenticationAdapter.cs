using EventHub.Entities;
using EventHub.Infrastructure.Authentication.Providers;

namespace EventHub.Infrastructure.Authentication;

public sealed class FacebookAuthenticationAdapter : IAuthentication
{
    private readonly IFacebookAuthenticationProvider provider;

    public FacebookAuthenticationAdapter(IFacebookAuthenticationProvider provider)
    {
        this.provider = provider;
    }

    public User? Authenticate(string email, string password)
    {
        provider.AuthenticateWithFacebook();
        return null;
    }
}