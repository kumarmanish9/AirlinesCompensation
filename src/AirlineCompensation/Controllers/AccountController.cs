using Microsoft.AspNetCore.Mvc;

namespace AirlineCompensation.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
