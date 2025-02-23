using Microsoft.AspNetCore.Mvc;

namespace SportMatch.Controllers;

public class AboutUsController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}