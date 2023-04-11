namespace EventHub.Utils.Exceptions;

public sealed class InvalidUsernameException : ValidationException
{
    public InvalidUsernameException()
    {
    }

    public InvalidUsernameException(string? message) : base(message)
    {
    }
    
    public InvalidUsernameException(string? message, Exception? innerException) 
        : base(message, innerException)
    {
    }
}