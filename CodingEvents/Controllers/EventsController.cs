using Microsoft.AspNetCore.Mvc;

namespace CodingEvents;

public class EventsController : Controller
{
    private static List<string> Events { get; set; } = [];

    [HttpGet]
    public IActionResult Index()
    {
        ViewBag.events = Events;

        return View();
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost("/events/add")]
    public IActionResult NewEvent(string eventName)
    {
        Events.Add(eventName);
        return Redirect("/events");
    }
}
