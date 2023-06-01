using EventHub.Business.Controllers;
using EventHub.Business.Validations;
using EventHub.Entities;
using EventHub.Presentation.Common;
using EventHub.Presentation.Common.Controls;
using EventHub.Presentation.Common.Views;

namespace EventHub.Presentation.Views.Events;

public sealed class EditEventView : NavigationView
{
    private readonly EventController eventController = new();
    private readonly Event @event;

    public EditEventView(IView ancestor, Event @event) : base(ancestor)
    {
        this.@event = @event;
    }

    public override string Title => $"Events – Edit {@event.Name}";

    protected override void BuildContent()
    {
        var name = ConsoleHelper.ReadRequiredString("Name");
        var description = ConsoleHelper.ReadRequiredString("Description");
        var capacity = ConsoleHelper.ReadRequiredInt("Capacity");
        var startDate = ConsoleHelper.ReadRequiredDateTime("Start date");
        var endDate = ConsoleHelper.ReadRequiredDateTime("End date");

        @event.Name = name;
        @event.Description = description;
        @event.Capacity = capacity;
        @event.StartDate = startDate;
        @event.EndDate = endDate;

        try
        {
            eventController.UpdateEvent(@event);
        }
        catch (ValidationException ve)
        {
            Console.WriteLine(ve.Message);
            if (ConsoleHelper.ReadYesNo("\nDo you want to try again?"))
            {
                Reshow();
            }
            else
            {
                Cancel();
            }
        }

        Navigator.Back(this);
    }

    protected override Menu BuildMenu()
    {
        return new MenuBuilder()
            .AddMenuItem("Cancel (Go back)", Cancel)
            .Build();
    }

    private void Cancel() => Navigator.Back(this);
}