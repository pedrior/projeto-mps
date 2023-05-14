namespace EventHub.Business.Exceptions;

public sealed class EventIsFullException : Exception
{
    public EventIsFullException()
    {
    }

    public EventIsFullException(string? message) : base(message)
    {
    }

    public EventIsFullException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}