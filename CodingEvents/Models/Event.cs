using System.ComponentModel.DataAnnotations;

namespace CodingEvents.Models;

public class Event()
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? ContactEmail { get; set; }
    private static int nextId = 1;
    public int Id { get; } = nextId++;

    public Event(string? name, string? description, string? contactEmail) : this()
    {
        Name = name;
        Description = description;
        ContactEmail = contactEmail;
    }



    public override string ToString()
    {
        return Name ??= "No name provided";
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
