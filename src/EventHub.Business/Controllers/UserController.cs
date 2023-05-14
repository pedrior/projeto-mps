using EventHub.Business.Exceptions;
using EventHub.Business.Validations;
using EventHub.Entities;
using EventHub.Infrastructure.Persistence.Context;
using EventHub.Infrastructure.Persistence.Repositories;
using FluentValidation;

namespace EventHub.Business.Controllers;

public sealed class UserController
{
    private readonly DbContext dbContext;
    private readonly IUserRepository userRepository;
    private readonly IValidator<User> userValidator;

    public UserController()
    {
        dbContext = new DbFactory().GetDefaultContext();
        userRepository = new UserRepository(dbContext);
        userValidator = new UserValidator();
    }

    public User GetUserById(Guid userId) => userRepository.GetById(userId)
                                            ?? throw new UserNotFoundException($"User not found with id: {userId}");

    public IEnumerable<User> GetAllUsers() => userRepository.GetAll();

    public void AddAdminUser(AdminUser user) => AddUser(user);

    public void AddBasicUser(BasicUser user) => AddUser(user);

    public void UpdateUser(User user)
    {
        if (!userRepository.Any(u => u.Id == user.Id))
        {
            throw new UserNotFoundException($"User not found with id: {user.Id}");
        }

        userValidator.ValidateAndThrow(user);

        userRepository.Update(user);
        dbContext.SaveChanges();
    }

    public void DeleteUserById(Guid id)
    {
        var user = userRepository.GetById(id);
        if (user is null)
        {
            throw new UserNotFoundException($"User not found with id: {id}");
        }

        userRepository.Delete(user);
        dbContext.SaveChanges();
    }

    private void AddUser(User user)
    {
        if (userRepository.Any(u => u.Email.Equals(user.Email, StringComparison.OrdinalIgnoreCase)))
        {
            throw new UserAlreadyExistsException($"User already exists with email: {user.Email}");
        }

        userValidator.ValidateAndThrow(user);

        userRepository.Add(user);
        dbContext.SaveChanges();
    }
}