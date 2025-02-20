using Microsoft.AspNetCore.Mvc;
using SportMatch.Services;
using SportMatch.Models;

namespace SportMatch.Controllers
{
    [Route("Acocunt")]
    public class AccountController : Controller
    {
        private readonly AuthenticationService? _authenticationService;

        public AccountController(AuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] Login login)
        {
            if (_authenticationService!.VaildateUser(login.Account,login.Password)) { 
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

    }
}
