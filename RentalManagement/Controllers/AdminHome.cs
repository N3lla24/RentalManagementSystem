using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalManagement.Data;
using System.Threading.Tasks;

namespace RentalManagement.Controllers
{
    public class AdminHome : Controller
    {
        private readonly RentalManagementContext _context;

        private readonly ILogger<AdminHome> _logger;

        public AdminHome(ILogger<AdminHome> logger, RentalManagementContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Home()
        {
            return View();
        }

        //public async Task<IActionResult> ManageRental()
        //{
        //    try
        //    {
        //        var tenant = await _context.Tenant.ToListAsync();
        //        var requisition = await _context.Requisition.ToListAsync();
        //        var room = await _context.Room.ToListAsync();
        //        var feedback = await _context.Feedback.ToListAsync();
        //        var applicants = await _context.Applicants.ToListAsync();

        //        //if (tenant != null && requisition != null && room != null && feedback != null && applicants != null)
        //        //{
        //        //    var viewModel = new RentalViewModels
        //        //    {
        //        //        Tenant = tenant,
        //        //        Requisition = requisition,
        //        //        Room = room,
        //        //        Feedback = feedback,
        //        //        Applicants = applicants
        //        //    };

        //        //    return View(viewModel);
        //        //}
        //        //else
        //        //{
        //        //    return Problem("Error fetching data from the database.");
        //        //}
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log and handle the exception
        //        _logger.LogError(ex, "An error occurred while processing the application.");
        //        return Content("An unexpected error occurred. Please try again later.");
        //    }
        //}


        //public IActionResult Logout()
        //{
        //    HttpContext.Session.Remove("AdminID");
        //    return RedirectToAction("Index", "Home");
        //}
    }
}
