using System.Runtime.Serialization;

namespace EventHub.Business.Exceptions;

public sealed class UndoNotSupportedException : Exception
{
    public UndoNotSupportedException()
    {
    }

    public UndoNotSupportedException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public UndoNotSupportedException(string? message) : base(message)
    {
    }
}