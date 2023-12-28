﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentalManagement.Data;
using RentalManagement.Models;

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

        // GET: Tenant/Dashboard
        public IActionResult UserDashboard() { return View(); }

        // POST: Tenants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TenantId,Tenant_FirstName,Tenant_MiddleName,Tenant_LastName,Tenant_Email,Tenant_PhoneNumber,Tenant_RoomNumber,Tenant_UnitNumber,Tenant_RentTot,Tenant_RentPaid,Tenant_CreatedAt,Tenant_UpdatedAt")] Tenant tenant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tenant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
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

        private bool TenantExists(int id)
        {
          return (_context.Tenant?.Any(e => e.TenantId == id)).GetValueOrDefault();
        }
    }
}
