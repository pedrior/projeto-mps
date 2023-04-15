using EventHub.Business.Controls;
using EventHub.Business.Entities.Users;
using EventHub.Infrastructure.Persistence;
using EventHub.Core.Exceptions;

var userControl = new UserControl(new DataContext());

int choice;

do
{
    Console.Clear();
    Console.WriteLine("Welcome to FitLeague!");

    Console.WriteLine("Select an option:");
    Console.WriteLine("1. Create user");
    Console.WriteLine("2. List users");
    Console.WriteLine("3. Exit");

    choice = int.Parse(Console.ReadLine() ?? "0");

    switch (choice)
    {
        case 1:
            CreateUser();
            break;
        case 2:
            ListUsers();
            break;
    }
} while (choice is not 3);

Console.WriteLine("Press any key to exit...");
Console.ReadLine();

void CreateUser()
{
    var allowedRoles = new[]
    {
        UserRoles.Admin.ToUpper(),
        UserRoles.Organizer.ToUpper(),
        UserRoles.Participant.ToUpper()
    };

    Console.Clear();
    Console.WriteLine("Adding user...\n");

    string[]? roles;

    do
    {
        Console.WriteLine("Enter roles (separated by spaces):");
        Console.WriteLine($"Allowed roles: {string.Join(", ", allowedRoles)}");

        roles = Console.ReadLine()?
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(x => x.ToUpper())
            .ToArray();

        if (roles is null || roles.All(x => allowedRoles.Contains(x)))
        {
            continue;
        }

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nInvalid roles!\n");
        Console.ResetColor();
    } while (roles is null || !roles.All(x => allowedRoles.Contains(x)));

    CreateUserWithRoles(roles);
}

void CreateUserWithRoles(params string[] roles)
{
    Console.Clear();
    Console.WriteLine("Adding user...\n");

    Console.WriteLine("Enter email:");
    var email = Console.ReadLine();

    Console.WriteLine("Enter username:");
    var username = Console.ReadLine();

    Console.WriteLine("Enter password:");
    var password = Console.ReadLine();

    Console.WriteLine("Enter first name:");
    var firstName = Console.ReadLine();

    Console.WriteLine("Enter last name:");
    var lastName = Console.ReadLine();

    var user = new User
    {
        Email = email ?? string.Empty,
        Username = username ?? string.Empty,
        Password = password ?? string.Empty,
        FirstName = firstName ?? string.Empty,
        LastName = lastName ?? string.Empty
    };

    foreach (var role in roles)
    {
        user.AddRole(role);
    }

    try
    {
        userControl.CreateUser(user);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nUser added successfully!\n");
        Console.ResetColor();
        Console.WriteLine("\nPress any key to go back...");
        Console.ReadLine();
    }
    catch (ValidationException e)
    {
        LogError("Could not add user due to a validation error:", e.Message);
    }
    catch (Exception e) when (e is DuplicateUserEmailException or DuplicateUserUsernameException)
    {
        LogError("Could not add user due to a conflict error:", e.Message);
    }
}

void ListUsers()
{
    Console.Clear();
    var users = userControl.GetUsers().ToList();

    Console.WriteLine(users.Any() ? "Listing users...\n" : "No users found.\n");

    foreach (var user in users)
    {
        Console.WriteLine(user);
    }

    Console.WriteLine("\nPress any key to go back...");
    Console.ReadLine();
}

void LogError(string title, string message)
{
    Console.WriteLine($"\n{title}\n");
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(message);
    Console.ResetColor();
    Console.WriteLine("\nPress any key to go back...");
    Console.ReadLine();
}