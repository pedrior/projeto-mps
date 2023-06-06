using EventHub.Business.Exceptions;
using EventHub.Business.Reporting;
using EventHub.Business.Reporting.UserStatistics;
using EventHub.Business.Validations;
using EventHub.Entities;
using EventHub.Infrastructure.Authentication;
using EventHub.Infrastructure.Persistence.Context;
using EventHub.Infrastructure.Persistence.Repositories;

namespace EventHub.Business.Controllers;

public sealed class UserController
{
    private readonly DbContext dbContext;
    private readonly IUserRepository userRepository;
    private readonly Validator<User> userValidator;
    private readonly IAuthentication authentication;

    private readonly List<IUserStatisticUnit> userStatisticUnits = new();

    public UserController()
    {
        dbContext = new DbFactory().GetDefaultContext();
        userRepository = new UserRepository(dbContext);
        userValidator = new UserValidator();
        authentication = new BasicAuthenticationAdapter(userRepository);
    }

    public void GenerateHtmlUserStatisticsReport() =>
        UserStatisticsReportFactory.CreateReport(ReportFormat.Html).Generate(userStatisticUnits);

    public void GeneratePdfUserStatisticsReport() =>
        UserStatisticsReportFactory.CreateReport(ReportFormat.Pdf).Generate(userStatisticUnits);

    public Guid SignIn(string email, string password)
    {
        var user = authentication.Authenticate(email, password) ??
                   throw new AuthenticationException("Invalid login or password");

        userStatisticUnits.Add(new UserLoginStatisticUnit(user.FullName));

        return user.Id;
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

        userStatisticUnits.Add(new UserLoginStatisticUnit(user.FullName));
    }
}