using Microsoft.AspNetCore.Mvc;

namespace SportMatch.Controllers
{
    public class DoorController : Controller
    {
        public IActionResult Door()
        {
            return View();
        }
    }
}
