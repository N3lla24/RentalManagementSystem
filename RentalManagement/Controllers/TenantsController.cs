using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentalManagement.Data;
using RentalManagement.Models;
using RentalManagement.Services;

namespace RentalManagement.Controllers
{
    public class TenantsController : Controller
    {
        private readonly RentalManagementContext _context;

        public TenantsController(RentalManagementContext context)
        {
            _context = context;
        }

        // GET: Tenants
        public async Task<IActionResult> Index()
        {
              return _context.Tenant != null ? 
                          View(await _context.Tenant.ToListAsync()) :
                          Problem("Entity set 'RentalManagementContext.Tenant'  is null.");
        }

        // GET: Tenants/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: Tenants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tenants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TenantId,Tenant_FirstName,Tenant_MiddleName,Tenant_LastName,Tenant_UserName,Tenant_Email,Tenant_PhoneNumber,Tenant_Password,Tenant_RoomNumber,Tenant_UnitNumber,Tenant_CreatedAt,Tenant_UpdatedAt")] Tenant tenant)
        {
            Admin existingadmin = await _context.Admin.FirstOrDefaultAsync(a => a.Admin_Email == tenant.Tenant_Email && a.Admin_PhoneNumber == tenant.Tenant_PhoneNumber);
            if (existingadmin != null) 
            { 
                ViewData["ExistingUser"] = "Existing"; return View(tenant); 
            }

            Tenant existingTenant = await _context.Tenant.FirstOrDefaultAsync(q => q.Tenant_Email == tenant.Tenant_Email && q.Tenant_PhoneNumber == tenant.Tenant_PhoneNumber && q.Tenant_RoomNumber == tenant.Tenant_RoomNumber && q.Tenant_UnitNumber == tenant.Tenant_UnitNumber);

            if (existingTenant == null) 
            { 
                ViewData["UserNotFound"] = "Not Found"; return View(tenant);
            }

            if (existingTenant.Tenant_UserName != "N/A" && existingTenant.Tenant_Password != "N/A")
            {
                ViewData["ExistingUser"] = "Existing";
                return View(tenant);
            }

            Tenant existingusername = await _context.Tenant.FirstOrDefaultAsync(q => q.Tenant_UserName == tenant.Tenant_UserName);
            Admin existingadminname = await _context.Admin.FirstOrDefaultAsync(q => q.Admin_UserName == tenant.Tenant_UserName);
            if (existingusername != null || existingadminname != null)
            {
                ViewData["ExistingUserName"] = "Existing Username";
                return View(tenant);
            }
            try
            {
                existingTenant.Tenant_UserName = tenant.Tenant_UserName;
                existingTenant.Tenant_Password = Hashing.HashPass(tenant.Tenant_Password);
                ViewData["ExistingUser"] = null;
                Room room = await _context.Room.FirstOrDefaultAsync(q => q.Room_Num == existingTenant.Tenant_RoomNumber && q.UnitId == existingTenant.Tenant_UnitNumber);
                if (room == null) { return Content("Room and Unit Number not found. Contact the admin"); }
                room.TenantId = existingTenant.TenantId;
                _context.Update(room);
                _context.Update(existingTenant);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TenantExists(existingTenant.TenantId))
                {
                    ViewData["UserNotFound"] = "Not Found"; 
                    return View(tenant);
                }
                else
                {
                    throw;
                }
            }
            ViewData["Successful"] = "Successful Registration";
            
            return View();
        }

        // GET: Tenants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tenant == null)
            {
                return NotFound();
            }

            var tenant = await _context.Tenant.FindAsync(id);
            if (tenant == null)
            {
                return NotFound();
            }
            return View(tenant);
        }

        // POST: Tenants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TenantId,Tenant_FirstName,Tenant_MiddleName,Tenant_LastName,Tenant_UserName,Tenant_Email,Tenant_PhoneNumber,Tenant_Password,Tenant_RoomNumber,Tenant_UnitNumber,Tenant_CreatedAt,Tenant_UpdatedAt")] Tenant tenant)
        {
            if (id != tenant.TenantId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tenant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TenantExists(tenant.TenantId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tenant);
        }

        // GET: Tenants/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: Tenants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tenant == null)
            {
                return Problem("Entity set 'RentalManagementContext.Tenant'  is null.");
            }
            var tenant = await _context.Tenant.FindAsync(id);
            if (tenant != null)
            {
                _context.Tenant.Remove(tenant);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TenantExists(int id)
        {
          return (_context.Tenant?.Any(e => e.TenantId == id)).GetValueOrDefault();
        }
    }
}
