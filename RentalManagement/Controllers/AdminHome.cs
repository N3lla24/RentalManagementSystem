using Microsoft.AspNetCore.Mvc;

namespace RentalManagement.Controllers
{
    public class AdminHome : Controller
    {
        public IActionResult Home()
        {
            return View();
        }

        public IActionResult ManageRental()
        {
            return View();
        }

        public IActionResult Logout()
        {
            /*HttpContext.Session.Remove("accountlogin");*/ //for logging out
            return RedirectToAction("Index", "Home");
        }
    }
}
