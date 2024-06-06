﻿namespace CodingEvents;

public class Event()
{
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    private static int nextId = 1;
    public int Id { get; } = nextId++;

    public Event(string name, string description) : this()
    {
        Name = name;
        Description = description;
    }

    public override string ToString()
    {
        return Name;
    }

    public override bool Equals(object? obj)
    {
        return obj is Event @event && Id == @event.Id;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id);
    }
}
