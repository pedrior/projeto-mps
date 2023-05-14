namespace EventHub.Business.Exceptions;

public sealed class UserAlreadySubscribedToEventException : Exception
{
    public UserAlreadySubscribedToEventException()
    {
    }

    public UserAlreadySubscribedToEventException(string? message) : base(message)
    {
    }

    public UserAlreadySubscribedToEventException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}