namespace EventHub.Business.Controllers;

internal sealed class EventMementoCaretaker
{
    private readonly Stack<EventMemento> mementos = new();


    public void SaveMemento(EventMemento memento) => mementos.Push(memento);

    public EventMemento? RestoreMemento() => mementos.Count > 0 ? mementos.Pop() : null;
}