using System.Text.RegularExpressions;

namespace EventHub.Business.Validators;

internal static class PasswordValidator
{
    public static bool IsValid(string? password) =>
        password is not null && Regex.IsMatch(password, @"^(?=.*\d.*\d)(?=.*[A-Za-z])[A-Za-z0-9]{8,20}$");
}