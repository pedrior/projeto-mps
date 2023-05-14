using System.Diagnostics.CodeAnalysis;
using EventHub.Business.Controllers;
using EventHub.Business.Controllers.Notifications;
using EventHub.Entities;
using EventHub.Infrastructure.Services.Notification;

namespace EventHub.Business.Facades;

public sealed class EventFacade
{
    private static readonly Lazy<EventFacade> LazyInstance = new(() => new EventFacade());

    private readonly UserController userController;
    private readonly EventController eventController;
    private readonly CategoryController categoryController;
    private readonly INotificationDispatcher[] notificationDispatchers;

    [SuppressMessage("ReSharper", "PrivateFieldCanBeConvertedToLocalVariable")]
    private readonly INotificationDispatcherFactory notificationDispatcherFactory;

    private EventFacade()
    {
        userController = new UserController();
        eventController = new EventController();
        categoryController = new CategoryController();
        notificationDispatcherFactory = new NotificationDispatcherFactory();

        notificationDispatchers = new[]
        {
            notificationDispatcherFactory.CreateNotificationDispatcher(NotificationType.Email),
            notificationDispatcherFactory.CreateNotificationDispatcher(NotificationType.Push)
        };
    }

    public static EventFacade Current => LazyInstance.Value;

    public void Subscribe(Event @event, User user)
    {
        eventController.SubscribeToEvent(@event, user.Id);
        DispatchNotification(new EventSubscribedNotification(@event, user));
    }

    public void Unsubscribe(Event @event, User user)
    {
        eventController.UnsubscribeFromEvent(@event, user.Id);
        DispatchNotification(new EventUnsubscribedNotification(@event, user));
    }

    public IEnumerable<User> GetSubscribers(Event @event)
    {
        var subscriberIds = @event.Subscriptions.Select(s => s.SubscriberId);
        return subscriberIds.Select(subscriberId => userController.GetUserById(subscriberId));
    }

    public IDictionary<Category, IEnumerable<Event>> GroupEventsByCategory() =>
        categoryController.GetAllCategories()
            .ToDictionary(category => category, SearchByCategory);

    public IEnumerable<Event> SearchByCategory(Category category) =>
        eventController.GetAllEvents().Where(e => e.CategoryId == category.Id);

    private void DispatchNotification(INotification notification)
    {
        foreach (var dispatcher in notificationDispatchers)
        {
            dispatcher.Dispatch(notification);
        }
    }
}