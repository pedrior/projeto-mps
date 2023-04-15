namespace EventHub.Core.Exceptions;

public sealed class InvalidPasswordException : ValidationException
{
    public InvalidPasswordException()
    {
    }
    
    public InvalidPasswordException(string? message) : base(message)
    {
    }
    
    public InvalidPasswordException(string? message, Exception? innerException) 
        : base(message, innerException)
    {
    }
}