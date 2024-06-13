using CodingEvents.Data;
using CodingEvents.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodingEvents.Controllers;

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
}
