using CodingEvents.Data;
using CodingEvents.Models;
using CodingEvents.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodingEvents.Controllers;

public class EventsController : Controller
{
    private EventDbContext context;

    public EventsController(EventDbContext dbContext)
    {
        context = dbContext;
    }

    public IActionResult Index()
    {
        List<Event> events = context.Events.Include(e => e.Category).ToList();

        return View(events);
    }

    [HttpGet]
    public IActionResult Add()
    {
        List<EventCategory> categories = context.EventCategories.ToList();
        AddEventViewModel addEventViewModel = new(categories);

        return View(addEventViewModel);
    }

    [HttpPost]
    public IActionResult Add(AddEventViewModel addEventViewModel)
    {
        if (ModelState.IsValid)
        {
            EventCategory category = context.EventCategories.Find(addEventViewModel.CategoryId);

            Event newEvent =
                new()
                {
                    Name = addEventViewModel.Name,
                    Description = addEventViewModel.Description,
                    ContactEmail = addEventViewModel.ContactEmail,
                    Category = category
                };
            context.Events.Add(newEvent);
            context.SaveChanges();

            return Redirect("/events");
        }
        return View(addEventViewModel);
    }

    public IActionResult Delete()
    {
        ViewBag.events = context.Events.ToList();

        return View();
    }

    [HttpPost]
    public IActionResult Delete(int[] eventIds)
    {
        foreach (int eventId in eventIds)
        {
            Event? theEvent = context.Events.Find(eventId);
            if (theEvent is null) break;
            
            context.Events.Remove(theEvent);
        }
        context.SaveChanges();

        return Redirect("/events");
    }

    public IActionResult Detail(int id)
    {
        Event theEvent = context.Events
            .Include(e => e.Category)
            .Include(e => e.Tags)
            .Single(e => e.Id == id);
        EventDetailViewModel viewModel = new(theEvent);
        return View(viewModel);
    }
}
