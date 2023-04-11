namespace EventHub.Infrastructure.Persistence;

public sealed class MemoryCollectionException : Exception
{
    public MemoryCollectionException()
    {
    }

    public MemoryCollectionException(string? message) : base(message)
    {
    }

    public MemoryCollectionException(string? message, Exception? innerException) 
        : base(message, innerException)
    {
    }
}