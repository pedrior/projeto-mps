using EventHub.Business.Controllers;
using EventHub.Entities;

namespace EventHub.Business.Facades.commands;

public sealed class GetEventSubscribersCommand : ICommand<Event, IEnumerable<User>>
{
    private readonly UserController userController;

    public GetEventSubscribersCommand(UserController userController)
    {
        this.userController = userController;
    }

    public IEnumerable<User> Execute(Event @event)
    {
        var subscriberIds = @event.Subscriptions.Select(s => s.SubscriberId);
        return subscriberIds.Select(subscriberId => userController.GetUserById(subscriberId));
    }
}