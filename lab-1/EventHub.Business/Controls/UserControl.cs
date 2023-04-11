using EventHub.Business.Entities.Users;
using EventHub.Business.Validators;
using EventHub.Infrastructure.Persistence;
using EventHub.Utils.Exceptions;

namespace EventHub.Business.Controls;

public sealed class UserControl
{
    private readonly MemoryCollection<User, UserId> users;

    public UserControl(MemoryCollection<User, UserId> users)
    {
        this.users = users;
    }
    
    public IEnumerable<User> GetUsers() => users.GetAll();
    
    public void CreateUser(User user)
    {
        if (!EmailValidator.IsValid(user.Email))
        {
            throw new InvalidEmailException("Invalid email address.");
        }

        if (!UsernameValidator.IsValid(user.Username))
        {
            throw new InvalidUsernameException("Invalid username. The username must be between 1 and 12 characters " +
                                               "long and can only contain letters.");
        }

        if (!PasswordValidator.IsValid(user.Password))
        {
            throw new InvalidPasswordException("Invalid password. The password must be between 8 and 20 characters " +
                                               "long and can only contain letters and at least two numbers.");
        }

        if (!NameValidator.IsValid(user.FirstName))
        {
            throw new InvalidNameException("Invalid name. The first name must be between 2 and 20 characters long " +
                                           "and can only contain letters, spaces, periods and apostrophes.");
        }

        if (!NameValidator.IsValid(user.LastName))
        {
            throw new InvalidNameException("Invalid name. The last name must be between 2 and 20 characters long " +
                                           "and can only contain letters, spaces, periods and apostrophes.");
        }

        if (users.Exists(u => u.Email.Equals(user.Email, StringComparison.OrdinalIgnoreCase)))
        {
            throw new DuplicateUserEmailException("The email address is already in use.");
        }
        
        if (users.Exists(u => u.Username.Equals(user.Username, StringComparison.OrdinalIgnoreCase)))
        {
            throw new DuplicateUserUsernameException("The username is already in use.");
        }

        users.Add(user);
    }
}