using System.Text.RegularExpressions;

namespace EventHub.Business.Validators;

internal static class EmailValidator
{
    public static bool IsValid(string? email) =>
        email is not null && Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
}