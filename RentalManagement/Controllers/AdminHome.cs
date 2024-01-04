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
            HttpContext.Session.Remove("AdminID");
            return RedirectToAction("Index", "Home");
        }
    }
}
