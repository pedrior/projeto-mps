namespace EventHub.Entities;

public sealed class BasicUser : User
{
    public override User CopyWith(string? email = null,
        string? password = null,
        string? firstName = null,
        string? lastName = null) =>
        new BasicUser
        {
            Id = Id,
            Email = email ?? Email,
            Password = password ?? Password,
            FirstName = firstName ?? FirstName,
            LastName = lastName ?? LastName
        };
}
