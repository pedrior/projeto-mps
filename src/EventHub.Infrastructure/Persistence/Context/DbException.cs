namespace EventHub.Infrastructure.Persistence.Context;

public sealed class DbException : Exception
{
    public DbException()
    {
    }

    public DbException(string message) : base(message)
    {
    }

    public DbException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}