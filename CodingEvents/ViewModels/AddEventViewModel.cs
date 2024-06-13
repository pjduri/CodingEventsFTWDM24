using System.ComponentModel.DataAnnotations;
using CodingEvents.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CodingEvents.ViewModels;

public class AddEventViewModel
{
    [Required(ErrorMessage = "Name is required")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Event name must be between 3 and 50 characters")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Description is required")]
    [StringLength(500, ErrorMessage = "Max length is 500 characters")]
    public string? Description { get; set; }

    [EmailAddress]
    public string? ContactEmail { get; set; }
    public EventType Type { get; set; }
       public List<SelectListItem> EventTypes { get; set; } = new List<SelectListItem>
   {
      new(EventType.Conference.ToString(), ((int)EventType.Conference).ToString()),
      new(EventType.Meetup.ToString(), ((int)EventType.Meetup).ToString()),
      new(EventType.Social.ToString(), ((int)EventType.Social).ToString()),
      new(EventType.Workshop.ToString(), ((int)EventType.Workshop).ToString())
   };
}
