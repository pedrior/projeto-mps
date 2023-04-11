using System.Text.RegularExpressions;

namespace EventHub.Business.Validators;

internal static class UsernameValidator
{
    public static bool IsValid(string? username) =>
        username is not null && Regex.IsMatch(username, @"^[a-zA-Z_]{1,12}$");
}