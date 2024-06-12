using CodingEvents.Models;

namespace CodingEvents.Data;

public class EventData
{
    private static readonly Dictionary<int, Event> Events = [];

    public static IEnumerable<Event> GetAll()
    {
        return Events.Values;
    }

    public static void Add(Event newEvent)
    {
        Events.Add(newEvent.Id, newEvent);
    }

    public static void Remove(int id)
    {
        Events.Remove(id);
    }

    public static Event GetById(int id)
    {
        return Events[id];
    }

}
