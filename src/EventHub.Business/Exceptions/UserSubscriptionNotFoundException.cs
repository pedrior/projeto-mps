namespace EventHub.Business.Exceptions;

public sealed class UserSubscriptionNotFoundException : Exception
{
    public UserSubscriptionNotFoundException()
    {
    }

    public UserSubscriptionNotFoundException(string? message) : base(message)
    {
    }

    public UserSubscriptionNotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}