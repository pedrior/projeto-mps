using EventHub.Entities;

namespace EventHub.Business.Facades.commands;

public sealed class GetIsSubscribedCommand : ICommand<Event, bool>
{
    private readonly User user;
    
    public GetIsSubscribedCommand(User user)
    {
        this.user = user;
    }

    public bool Execute(Event @event) => @event.Subscriptions.Any(s => s.SubscriberId == user.Id);
}