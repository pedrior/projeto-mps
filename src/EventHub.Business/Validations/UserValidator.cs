using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using EventHub.Entities;

namespace EventHub.Business.Validations;

internal sealed class UserValidator : Validator<User>
{
    [StringSyntax(StringSyntaxAttribute.Regex)]
    private const string EmailRegex = @"^[a-zA-Z0-9.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";

    [StringSyntax(StringSyntaxAttribute.Regex)]
    private const string NameRegex = @"^[a-zA-ZÀ-ÿ]+([ '.][a-zA-ZÀ-ÿ]+)*$";

    public UserValidator()
    {
        NewRule(x => x.Id != Guid.Empty, "Must be a valid ID");

        NewRule(x => !string.IsNullOrEmpty(x.Email), "Email is required");
        NewRule(x => Regex.IsMatch(x.Email, EmailRegex), "Must be a valid email address");

        NewRule(x => !string.IsNullOrEmpty(x.Password), "Password is required");

        NewRule(x => x.Password.Length is >= 8 and <= 20, "Password must be between 8 and 20 characters");

        NewRule(x => Regex.IsMatch(x.Password, @"^(?=.*\d.*\d)(?=.*[A-Za-z])[A-Za-z0-9]+$"),
            "Password must be between 8 and 20 characters and contain at least 2 digits");

        NewRule(x => !string.IsNullOrEmpty(x.FirstName), "First name is required");
        NewRule(x => x.FirstName.Length is >= 2 and <= 30, "First name must be between 2 and 30 characters");
        NewRule(x => Regex.IsMatch(x.FirstName, NameRegex), "First name must contain only letters");

        NewRule(x => !string.IsNullOrEmpty(x.LastName), "Last name is required");
        NewRule(x => x.LastName.Length is >= 2 and <= 30, "Last name must be between 2 and 30 characters");
        NewRule(x => Regex.IsMatch(x.LastName, NameRegex), "Last name must contain only letters");
    }
}