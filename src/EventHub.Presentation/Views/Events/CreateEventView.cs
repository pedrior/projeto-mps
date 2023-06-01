using EventHub.Business.Controllers;
using EventHub.Business.Facades;
using EventHub.Business.Validations;
using EventHub.Entities;
using EventHub.Presentation.Common;
using EventHub.Presentation.Common.Controls;
using EventHub.Presentation.Common.Views;

namespace EventHub.Presentation.Views.Events;

public sealed class CreateEventView : NavigationView
{
    private readonly UserFacade userFacade = UserFacade.Current;
    private readonly EventController eventController = new();
    private readonly CategoryController categoryController = new();

    public CreateEventView(IView ancestor) : base(ancestor)
    {
    }

    public override string Title => "Events – Create Event";

    protected override void BuildContent()
    {
        var name = ConsoleHelper.ReadRequiredString("Name");
        var description = ConsoleHelper.ReadRequiredString("Description");
        var startDate = ConsoleHelper.ReadRequiredDateTime("Start date");
        var endDate = ConsoleHelper.ReadRequiredDateTime("End date");
        var capacity = ConsoleHelper.ReadRequiredInt("Capacity");

        Console.WriteLine("\nNow select a category:\n");

        var categories = categoryController.GetAllCategories().ToList();
        var categoryMenu = BuildCategoryMenu(categories);

        categoryMenu.Display();

        var selectedCategory = categoryMenu.GetSelectedMenuItem();
        var category = categories.FirstOrDefault(c => c.Name == selectedCategory.Title);
        if (category is null)
        {
            Console.WriteLine("\nInvalid category selected!\n");
            if (ConsoleHelper.ReadYesNo("Do you want to try again?"))
            {
                Reshow();
            }
            else
            {
                GoBack();
            }
        }

        var @event = new Event
        {
            OwnerId = userFacade.GetCurrentUser()!.Id,
            CategoryId = category!.Id,
            Name = name,
            Description = description,
            StartDate = startDate,
            EndDate = endDate,
            Capacity = capacity
        };

        try
        {
            eventController.AddEvent(@event);

            Console.ForegroundColor = ConsoleColor.Green;

            for (var i = 2; i > 0; i--)
            {
                Console.Write($"\rEvent created successfully! {i}");
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }

            Console.ResetColor();
            GoBack();
        }
        catch (ValidationException ve)
        {
            Console.Write($"\r{ve.Message}\n");
            if (ConsoleHelper.ReadYesNo("\nEvent creation failed! Do you want to try again?"))
            {
                Reshow();
            }
            else
            {
                GoBack();
            }
        }

        base.BuildContent();
    }

    private static Menu BuildCategoryMenu(List<Category> categories)
    {
        var categoryMenuBuilder = new MenuBuilder();
        categories.ForEach(c => categoryMenuBuilder.AddMenuItem(c.Name, () => { }));

        return categoryMenuBuilder.Build();
    }

    protected override Menu BuildMenu()
    {
        return new MenuBuilder()
            .AddMenuItem("Go back", GoBack)
            .Build();
    }

    private void GoBack() => Navigator.Back(this);
}