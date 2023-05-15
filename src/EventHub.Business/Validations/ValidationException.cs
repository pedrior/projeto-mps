namespace EventHub.Business.Validations;

public class ValidationException : Exception
{
    public ValidationException(string message) : base(message)
    {
    }
}