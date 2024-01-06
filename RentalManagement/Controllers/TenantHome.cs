using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalManagement.Data;
using RentalManagement.Models;
using RentalManagement.Services;
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
        public IActionResult Settings()
        {

            if (GetId() == null || _context.Tenant == null)
            {
                return  RedirectToAction("Index", "TenantHome");
            }

            var tenant = _context.Tenant.Find(GetId());
            if (tenant == null)
            {
                return RedirectToAction("Index", "TenantHome");
            }
            return View(tenant);
        }


        public async Task<IActionResult> Edit([Bind("TenantId,Tenant_FirstName,Tenant_MiddleName,Tenant_LastName,Tenant_UserName,Tenant_Email,Tenant_PhoneNumber,Tenant_Password,Tenant_RoomNumber,Tenant_UnitNumber,Tenant_CreatedAt,Tenant_UpdatedAt")] Tenant tenant)
        {
            Tenant currenttenant = await _context.Tenant.FirstOrDefaultAsync(q => q.TenantId == GetId());

            if (currenttenant != null)
            {
                currenttenant.Tenant_Password = Hashing.HashPass(tenant.Tenant_Password);
                try
                {
                    _context.Update(currenttenant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TenantExists())
                    {
                        ViewData["SuccessfulEdit"] = null;
                        ViewData["ErrorEdit"] = "Not Found";
                        return View("Settings");
                    }
                    else
                    {
                        throw;
                    }
                }
                ViewData["ErrorEdit"] = null;
                ViewData["SuccessfulEdit"] = "Edit Successfully";
                return View("Settings");
            }
            ViewData["SuccessfulEdit"] = null;
            ViewData["ErrorEdit"] = "Edit Failed";
            return View("Settings");
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
