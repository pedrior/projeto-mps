namespace EventHub.Core.Exceptions;

public sealed class DuplicateUserEmailException : Exception
{
    public DuplicateUserEmailException()
    {
    }

    public DuplicateUserEmailException(string? message) : base(message)
    {
    }

    public DuplicateUserEmailException(string? message, Exception? innerException) 
        : base(message, innerException)
    {
    }
}