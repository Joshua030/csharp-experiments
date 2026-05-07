using System;
namespace EventsApp;

public delegate void NotifyEvent(string message);

public class EventPublisher
{
    // The "On " prefix makes it inmediately clear that themethod
    // is associated with an event.
    //It signifies that the method is not just a regular method but
    //one that is called when a specific event occurs.
    public event NotifyEvent? OnNotify;

    public void RaiseEvent(string message)
    {
        OnNotify?.Invoke(message);
    }
}

public class EventSubscriber
{
    public void OnEventRaised(string message)
    {
        Console.WriteLine("Event received: " + message);
    }
}
