using System.Diagnostics.CodeAnalysis;
using EventHub.Business.Controllers;
using EventHub.Business.Controllers.Notifications;
using EventHub.Business.Facades.commands;
using EventHub.Entities;
using EventHub.Infrastructure.Services.Notification;

namespace EventHub.Business.Facades;

public sealed class EventFacade
{
    private static readonly Lazy<EventFacade> LazyInstance = new(() => new EventFacade());

    private readonly UserController userController;
    private readonly EventController eventController;
    private readonly CategoryController categoryController;
    private readonly List<INotificationDispatcher> notificationDispatchers;
    private readonly List<IEventObserver> observables = new();

    [SuppressMessage("ReSharper", "PrivateFieldCanBeConvertedToLocalVariable")]
    private readonly INotificationDispatcherFactory notificationDispatcherFactory;

    private EventFacade()
    {
        userController = new UserController();
        eventController = new EventController();
        categoryController = new CategoryController();
        notificationDispatcherFactory = new NotificationDispatcherFactory();

        notificationDispatchers = new List<INotificationDispatcher>
        {
            notificationDispatcherFactory.CreateNotificationDispatcher(NotificationType.Email),
            notificationDispatcherFactory.CreateNotificationDispatcher(NotificationType.Push)
        };
    }

    public static EventFacade Current => LazyInstance.Value;

    public void Subscribe(Event @event, User user)
    {
        new EventSubscribeCommand(eventController, user).Execute(@event);
        DispatchNotification(new EventSubscribedNotification(@event, user));
    }

    public void Unsubscribe(Event @event, User user)
    {
        new EventUnsubscribeCommand(eventController, user).Execute(@event);
        DispatchNotification(new EventUnsubscribedNotification(@event, user));
    }

    public IEnumerable<User> GetSubscribers(Event @event) =>
        new GetEventSubscribersCommand(userController).Execute(@event);

    public bool IsUserSubscribed(Event @event, User user) =>
        new GetIsSubscribedCommand(user).Execute(@event);

    public IDictionary<Category, IEnumerable<Event>> GroupEventsByCategory() =>
        categoryController.GetAllCategories()
            .ToDictionary(category => category, SearchByCategory);

    public IEnumerable<Event> SearchByCategory(Category category) =>
        eventController.GetAllEvents().Where(e => e.CategoryId == category.Id);

    public void DeleteEvent(Event @event) => eventController.DeleteEventById(@event.Id);

    public void StartEvent(Event ev)
    {
        new StartEventCommand().Execute(ev);
        NotifyOnEventStart(ev);
    }

    public void EndEvent(Event ev)
    {
        new EndEventCommand().Execute(ev);
        NotifyOnEventEnd(ev);
    }

    public void PublishEvent(Event ev)
    {
        new PublishEventCommand().Execute(ev);
        NotifyOnEventPublish(ev);
    }

    public void CancelEvent(Event ev)
    {
        new CancelEventCommand().Execute(ev);
        NotifyOnEventCancelled(ev);
    }
    
    private void DispatchNotification(INotification notification) =>
        notificationDispatchers.ForEach(n => n.Dispatch(notification));

    public void AttachEventObserver(IEventObserver observer) => observables.Add(observer);

    public void DetachEventObserver(IEventObserver observer) => observables.Remove(observer);

    private void NotifyOnEventStart(Event ev)
    {
        foreach (var observer in observables)
        {
            observer.OnStart(ev);
        }
    }

    private void NotifyOnEventEnd(Event ev)
    {
        foreach (var observer in observables)
        {
            observer.OnEnd(ev);
        }
    }

    private void NotifyOnEventPublish(Event ev)
    {
        foreach (var observer in observables)
        {
            observer.OnPublish(ev);
        }
    }

    private void NotifyOnEventCancelled(Event ev)
    {
        foreach (var observer in observables)
        {
            observer.OnCancelled(ev);
        }
    }

    public IEnumerable<Event> GetAllEvents() => eventController.GetAllEvents();
}