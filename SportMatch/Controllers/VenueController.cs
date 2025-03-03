using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportMatch.Models;

namespace SportMatch.Controllers;

public class VenueController : Controller
{
    
    private readonly MyDbContext _context;
    private readonly ILogger<VenueController> _logger;
    public VenueController(MyDbContext context, ILogger<VenueController> logger)
    {
        _context = context;
        _logger = logger;
    }

    // GET
    public async Task<IActionResult> Index()
    {
        var venues = await _context.Venues.ToListAsync();
        var venue = _context.Venues.FirstOrDefault();
        _logger.LogInformation("Venue Name: {VenueName}",venue?.VenueName??"無資料");
        ViewData["VenueName"] = venue?.VenueName;
        return View(venues);
    }

  

    // public async Task<IActionResult> SearchVenue([FromQuery] string? location, [FromQuery] string? sport)
    // {
    //     var query = _context.Venues.AsQueryable();
    //     
    //     if()
    // }
}