namespace EventHub.Business.Exceptions;

public sealed class EventNotFoundException : Exception
{
    public EventNotFoundException()
    {
    }

    public EventNotFoundException(string? message) : base(message)
    {
    }

    public EventNotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}