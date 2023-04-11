namespace EventHub.Utils.Exceptions;

public sealed class InvalidNameException : ValidationException
{
    public InvalidNameException()
    {
    }
    
    public InvalidNameException(string? message) : base(message)
    {
    }
    
    public InvalidNameException(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }
}