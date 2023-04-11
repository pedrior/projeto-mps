namespace EventHub.Utils.Exceptions;

public sealed class DuplicateUserUsernameException : Exception
{
    public DuplicateUserUsernameException()
    {
    }

    public DuplicateUserUsernameException(string? message) : base(message)
    {
    }

    public DuplicateUserUsernameException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}