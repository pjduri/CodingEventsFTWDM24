using Microsoft.AspNetCore.Mvc;

namespace CodingEvents;

public class EventsController : Controller
{
    public IActionResult Index()
    {
        ViewBag.events = EventData.GetAll();

        return View();
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost("/events/add")]
    public IActionResult NewEvent(Event newEvent)
    {
        EventData.Add(newEvent);
        return Redirect("/events");
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
