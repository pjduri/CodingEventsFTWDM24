using CodingEvents.Data;
using CodingEvents.Models;
using CodingEvents.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CodingEvents.Controllers;

[Route("EventCategory")]
public class EventCategoryController : Controller
{
    private EventDbContext context;

    public EventCategoryController(EventDbContext dbContext)
    {
        context = dbContext;
    }

    public IActionResult Index()
    {
        List<EventCategory> categories = context.EventCategories.ToList();

        return View(categories);
    }

    [HttpGet("Create")]
    public IActionResult Create()
    {
        EventCategoryViewModel eventCategoryViewModel = new();

        return View(eventCategoryViewModel);
    }

    [HttpPost("Create")]
    public IActionResult ProcessCreateEventCategoryForm(
        EventCategoryViewModel eventCategoryViewModel
    )
    {
        if (ModelState.IsValid)
        {
            EventCategory newEventCategory = new() { Name = eventCategoryViewModel.Name };
            context.EventCategories.Add(newEventCategory);
            context.SaveChanges();
            return Redirect("/EventCategory");
        }
        return View("Create", eventCategoryViewModel);
    }
}
