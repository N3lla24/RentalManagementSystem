using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalManagement.Data;
using RentalManagement.Models;
using System.Diagnostics;

namespace RentalManagement.Controllers
{
    public class TenantHome : Controller
    {
        private readonly RentalManagementContext _context;

        public TenantHome(RentalManagementContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        //Get Account Details for Settings
        public async Task<IActionResult> Settings(int? id)
        {
            if (id == null || _context.Tenant == null)
            {
                return NotFound();
            }

            var tenant = await _context.Tenant
                .FirstOrDefaultAsync(m => m.TenantId == id);
            if (tenant == null)
            {
                return NotFound();
            }

            return View(tenant);
        }

        //Get Account Notifications
        public async Task<IActionResult> Notifications(int? id)
        {
            return _context.Tenant != null ?
                         View(await _context.Tenant.ToListAsync()) :
                         Problem("No Notifications Yet");
        }

        public IActionResult Logout()
        {
            /*HttpContext.Session.Remove("accountlogin");*/ //for logging out
            return RedirectToAction("Index", "Login");
        }
    }
}
