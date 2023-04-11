using System.Text;
using EventHub.Utils.Entities;

namespace EventHub.Business.Entities.Users;

public sealed class User : Entity<UserId>
{
    private readonly IList<string> roles = new List<string>();

    public override UserId Id { get; init; } = UserId.New();

    public required string Email { get; init; }

    public required string Username { get; init; }

    public required string Password { get; init; }

    public required string FirstName { get; init; }

    public required string LastName { get; init; }

    public IReadOnlyList<string> Roles => roles.AsReadOnly();

    public void AddRole(string role)
    {
        ArgumentNullException.ThrowIfNull(role);

        if (!roles.Any(r => r.Equals(role, StringComparison.OrdinalIgnoreCase)))
        {
            roles.Add(role);
        }
    }

    public void RemoveRole(string role)
    {
        var existingRole = roles.FirstOrDefault(r => r.Equals(role, StringComparison.OrdinalIgnoreCase));
        if (existingRole is not null)
        {
            roles.Remove(existingRole);
        }
    }

    public override string ToString() =>
        new StringBuilder()
            .Append($"Email: {Email}")
            .Append($", Username: {Username}")
            .Append($", Password: {Password}")
            .Append($", FirstName: {FirstName}")
            .Append($", LastName: {LastName}")
            .Append($", Roles: {string.Join(", ", Roles)}")
            .ToString();
}