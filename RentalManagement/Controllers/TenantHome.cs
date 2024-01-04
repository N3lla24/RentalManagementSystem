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

        public async Task<IActionResult> Index()
        {

            if(GetId() is null) { return RedirectToAction("Index", "Login"); }

            return _context.Tenant != null ?
                          View(await _context.Tenant
                          .FirstOrDefaultAsync(m => m.TenantId == GetId())) :
                          Problem("Entity set 'RentalManagementContext.Tenant'  is null.");
        }

        //Get Account Details for Settings
        public async Task<IActionResult> Settings()
        {

            if (GetId() == null || _context.Tenant == null)
            {
                return  RedirectToAction("Index", "TenantHome");
            }

            var tenant = await _context.Tenant.FindAsync(GetId());
            if (tenant == null)
            {
                return RedirectToAction("Index", "TenantHome");
            }
            return View(tenant);
        }

        //Get Account Notifications
        public async Task<IActionResult> Notifications(int? id)
        {
            /*return _context.Tenant != null ?
                         View(await _context.Tenant.ToListAsync()) :
                         Problem("No Notifications Yet");*/
            return View();

        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("accountid"); //for logging out
            return RedirectToAction("Index", "Login");
        }

        private bool TenantExists()
        {
            return (_context.Tenant?.Any(e => e.TenantId == GetId())).GetValueOrDefault();
        }

        private int? GetId()
        {
            var id = HttpContext.Session.GetInt32("accountid");
            if (id is not null) { return id; }
            return null;
        }
    }
}
