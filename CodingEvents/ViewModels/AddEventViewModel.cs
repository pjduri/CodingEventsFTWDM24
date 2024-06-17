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
    public int CategoryId { get; set; }

    public List<SelectListItem>? Categories { get; set; }

    public AddEventViewModel(){}
    public AddEventViewModel(List<EventCategory> categories)
    {
      Categories = [];
      foreach (var category in categories)
      {
         Categories.Add(new SelectListItem
         {
            Value = category.Id.ToString(),
            Text = category.Name
         });
      }
    }
}
