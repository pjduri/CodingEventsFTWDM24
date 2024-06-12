﻿using CodingEvents.ViewModels;
using CodingEvents.Models;
using CodingEvents.Data;
using Microsoft.AspNetCore.Mvc;

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
        List<Event> events = context.Events.ToList();

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
            Event newEvent =
                new()
                {
                    Name = addEventViewModel.Name,
                    Description = addEventViewModel.Description,
                    ContactEmail = addEventViewModel.ContactEmail,
                    Type = addEventViewModel.Type
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
            context.Events.Remove(theEvent);
        }
        context.SaveChanges();

        return Redirect("/events");
    }
}
