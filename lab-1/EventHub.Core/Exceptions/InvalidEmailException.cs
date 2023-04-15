namespace EventHub.Core.Exceptions;

public sealed class InvalidEmailException : ValidationException
{
    public InvalidEmailException()
    {
    }
    
    public InvalidEmailException(string? message) : base(message)
    {
    }
    
    public InvalidEmailException(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }
}