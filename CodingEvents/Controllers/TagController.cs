using CodingEvents.Data;
using Microsoft.AspNetCore.Mvc;

namespace CodingEvents;

public class TagController : Controller
{
    private EventDbContext context;

    public TagController(EventDbContext dbContext)
    {
        context = dbContext;
    }

    // GET: /<controller>/
    public IActionResult Index()
    {
        List<Tag> tags = context.Tags.ToList();
        return View(tags);
    }

    public IActionResult Add()
    {
        Tag tag = new();
        return View(tag);
    }

    [HttpPost]
    public IActionResult Add(Tag tag)
    {
        if (ModelState.IsValid)
        {
            context.Tags.Add(tag);
            context.SaveChanges();
            return Redirect("/Tag");
        }

        return View(tag);
    }
}
