namespace EventHub.Entities;

public sealed class AdminUser : User
{
    public override bool IsAdmin => true;

    public override User CopyWith(string? email = null,
        string? password = null,
        string? firstName = null,
        string? lastName = null) =>
        new AdminUser
        {
            Id = Id,
            Email = email ?? Email,
            Password = password ?? Password,
            FirstName = firstName ?? FirstName,
            LastName = lastName ?? LastName
        };
}
