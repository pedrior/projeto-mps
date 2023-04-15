namespace EventHub.Core.Exceptions;

public abstract class ValidationException : Exception
{
    protected ValidationException()
    {
    }
    
    protected ValidationException(string? message) : base(message)
    {
    }
    
    protected ValidationException(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }
}