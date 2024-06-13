﻿namespace CodingEvents.Models;

public class EventCategory()
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public EventCategory(string name) : this()
    {
        Name = name;
    }

    
}
