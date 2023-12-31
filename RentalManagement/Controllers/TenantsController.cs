using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult NavToLogin()
        {
            return RedirectToAction("Index", "Login");
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

        // GET: Tenant/Dashboard
        public IActionResult UserDashboard() { return View(); }

        // POST: Tenants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TenantId,Tenant_FirstName,Tenant_MiddleName,Tenant_LastName, Tenant_UserName, Tenant_Email,Tenant_PhoneNumber, Tenant_Password, Tenant_RoomNumber,Tenant_UnitNumber,Tenant_RentTot,Tenant_RentPaid,Tenant_CreatedAt,Tenant_UpdatedAt")] Tenant tenant)
        {
            if (ModelState.IsValid)
            {
                Tenant existingUser = await _context.Tenant.FirstOrDefaultAsync(q => q.Tenant_Email == tenant.Tenant_Email && q.Tenant_PhoneNumber == tenant.Tenant_PhoneNumber);

                if(existingUser == null)
                {
                    ViewData["ExistedUser"] = null;
                    string HashPass = Hashing.HashPass(tenant.Tenant_Password);
                    tenant.Tenant_Password = HashPass;

                    /*_context.Update(tenant);*/
                    await _context.SaveChangesAsync();
                    ViewData["Title"] = "Successfull";
                    return RedirectToAction(nameof(Index));
                }

                ViewData["ExistedUser"] = "Account already exists.";
                return View(existingUser);
            }
            return View(tenant);
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
        public async Task<IActionResult> Edit(int id, [Bind("TenantId,Tenant_FirstName,Tenant_MiddleName,Tenant_LastName,Tenant_Email,Tenant_PhoneNumber,Tenant_RoomNumber,Tenant_UnitNumber,Tenant_RentTot,Tenant_RentPaid,Tenant_CreatedAt,Tenant_UpdatedAt")] Tenant tenant)
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

        //GET REGISTER
        public IActionResult Register()
        {
            return View();
        }

        //Register Tenant (Complete Info)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("TenantId, Tenant_UserName, Tenant_Email,Tenant_PhoneNumber, Tenant_Password")] Tenant tenant)
        {
            if (ModelState.IsValid)
            {
                Tenant existingUser = await _context.Tenant.FirstOrDefaultAsync(q => q.Tenant_Email == tenant.Tenant_Email && q.Tenant_PhoneNumber == tenant.Tenant_PhoneNumber);
                if (existingUser != null)
                {
                    ViewData["Title"] = "Successfull";
                }
                return View(tenant);
            }
            return View(tenant);
        }



        private bool TenantExists(int id)
        {
          return (_context.Tenant?.Any(e => e.TenantId == id)).GetValueOrDefault();
        }
    }
}
