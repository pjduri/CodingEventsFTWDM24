using CodingEvents.Models;

namespace CodingEvents;

public class Tag
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public List<Event> Events { get; set; }

    public Tag(){}
    public Tag(string? name)
    {
        Name = name;
    }
    
}
