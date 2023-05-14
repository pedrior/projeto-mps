using System.Text;

namespace EventHub.Entities;

public abstract class User : Entity
{
    public required string Email { get; init; }

    public required string Password { get; init; }

    public required string FirstName { get; init; }

    public required string LastName { get; init; }

    public virtual bool IsAdmin { get; } = false;

    public bool CheckPassword(string password) =>
        password.Equals(Password, StringComparison.InvariantCultureIgnoreCase);

    public string FullName => $"{FirstName} {LastName}";

    public abstract User CopyWith(string? email = null,
        string? password = null,
        string? firstName = null,
        string? lastName = null);

    public override string ToString() =>
        new StringBuilder()
            .AppendLine($"Email address: {Email}")
            .AppendLine($"Full name: {FullName}")
            .AppendLine($"Admin: {IsAdmin.ToString().ToLowerInvariant()}")
            .ToString();
}