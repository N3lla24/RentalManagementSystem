using Microsoft.AspNetCore.Mvc;
using RentalManagement.Data;
using RentalManagement.Models;
using System.Diagnostics;

namespace RentalManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly RentalManagementContext _context;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, RentalManagementContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            ClearRejected();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult Application()
        {
            return RedirectToAction("Create", "Applicants");
        }

        public void ClearRejected()
        {
            //List<Applicants> applicants = _context.Applicants.ToList();
            //foreach (Applicants applicant in applicants)
            //{
            //    TimeSpan difference = applicant.Applicant_CreatedAt - DateTime.Now;
            //    if (applicant.Application_Status == "Reject" && difference.TotalDays < 30)
            //    {
            //        _context.Applicants.Remove(applicant);
            //    }
            //}
        }
    }
}