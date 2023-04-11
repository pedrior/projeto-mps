using System.Text.RegularExpressions;

namespace EventHub.Business.Validators;

internal sealed class NameValidator
{
    public static bool IsValid(string? name) =>
        name is not null && Regex.IsMatch(name, @"^[a-zA-ZÀ-ÿ]+([ '.][a-zA-ZÀ-ÿ]+)*$");
}