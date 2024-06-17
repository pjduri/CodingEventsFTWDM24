using System.ComponentModel.DataAnnotations;

namespace CodingEvents.Models;

public class Event
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? ContactEmail { get; set; }
    public EventCategory Category { get; set; }
    public int CategoryId { get; set; }
    public ICollection<Tag>? Tags { get; set; }

    public Event(){}
    public Event(string? name, string? description, string? contactEmail)
    {
        Name = name;
        Description = description;
        ContactEmail = contactEmail;
        Tags = [];
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
