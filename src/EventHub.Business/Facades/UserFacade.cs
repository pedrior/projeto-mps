using EventHub.Business.Controllers;
using EventHub.Business.Exceptions;
using EventHub.Business.Validations;
using EventHub.Entities;

namespace EventHub.Business.Facades;

public sealed class UserFacade
{
    private static readonly Lazy<UserFacade> LazyInstance = new(() => new UserFacade());

    private readonly UserController userController = new();

    private UserFacade()
    {
    }

    public static UserFacade Current => LazyInstance.Value;

    public bool IsLoggedIn => LoggedInUserId != Guid.Empty;

    private Guid LoggedInUserId { get; set; }

    public bool Login(string email, string password)
    {
        try
        {
            LoggedInUserId = userController.SignIn(email, password);
        }
        catch (AuthenticationException)
        {
            return false;
        }

        return true;
    }

    public (bool succeeded, string? message) Register(
        string email, string password, string firstName, string lastName)
    {
        try
        {
            var user = new BasicUser
            {
                Email = email,
                Password = password,
                FirstName = firstName,
                LastName = lastName
            };

            userController.AddBasicUser(user);
        }
        catch (UserAlreadyExistsException)
        {
            return (false, "User already exists.");
        }
        catch (ValidationException ve)
        {
            return (false, ve.Message);
        }

        return (true, null);
    }

    public void Logout() => LoggedInUserId = Guid.Empty;

    public User? GetCurrentUser() => IsLoggedIn ? userController.GetUserById(LoggedInUserId) : null;
    
    public void GenerateHtmlUserStatisticsReport() => userController.GenerateHtmlUserStatisticsReport();

    public void GeneratePdfUserStatisticsReport() => userController.GeneratePdfUserStatisticsReport();
}