using CodingEvents.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CodingEvents;

public class EventsController : Controller
{
    public IActionResult Index()
    {
        List<Event> events = new(EventData.GetAll());

        return View(events);
    }

    [HttpGet]
    public IActionResult Add()
    {
        AddEventViewModel addEventViewModel = new();

        return View(addEventViewModel);
    }

    [HttpPost]
    public IActionResult Add(AddEventViewModel addEventViewModel)
    {
        if (ModelState.IsValid)
        {
            Event newEvent = new Event
            {
                Name = addEventViewModel.Name,
                Description = addEventViewModel.Description,
                ContactEmail = addEventViewModel.ContactEmail
            };

            EventData.Add(newEvent);

            return Redirect("/Events");
        }

        return View(addEventViewModel);
    }

    public IActionResult Delete()
    {
        ViewBag.events = EventData.GetAll();

        return View();
    }

    [HttpPost]
    public IActionResult Delete(int[] eventIds)
    {
        foreach (int eventId in eventIds)
        {
            EventData.Remove(eventId);
        }

        return Redirect("/events");
    }
}
