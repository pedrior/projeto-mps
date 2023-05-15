namespace EventHub.Business.Validations;

public abstract class Validator<T>
{
    private const string DefaultErrorMessage = "Invalid value.";

    private readonly List<Func<T, bool>> rules = new();
    private readonly List<string> errorMessages = new();

    public void ValidateAndThrow(T @object)
    {
        for (var i = 0; i < rules.Count; i++)
        {
            if (!rules[i](@object))
            {
                throw new ValidationException(errorMessages[i]);
            }
        }
    }

    protected void NewRule(Func<T, bool> rule, string? errorMessage = null)
    {
        rules.Add(rule);
        errorMessages.Add(errorMessage ?? DefaultErrorMessage);
    }
}