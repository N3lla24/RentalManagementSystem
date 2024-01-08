﻿using Microsoft.AspNetCore.Mvc;
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
                return RedirectToAction("Index", "TenantHome");
            }

            var tenant = _context.Tenant.Find(GetId());
            if (tenant == null)
            {
                return RedirectToAction("Index", "TenantHome");
            }
            return View(tenant);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Settings([Bind("TenantId,Tenant_FirstName,Tenant_MiddleName,Tenant_LastName,Tenant_UserName,Tenant_Email,Tenant_PhoneNumber,Tenant_Password,Tenant_RoomNumber,Tenant_UnitNumber,Tenant_CreatedAt,Tenant_UpdatedAt")] Tenant tenant)
        {
            Tenant currenttenant = await _context.Tenant.FirstOrDefaultAsync(q => q.TenantId == GetId());

            if (currenttenant != null)
            {
                try
                {
                    currenttenant.Tenant_FirstName = tenant.Tenant_FirstName;
                    currenttenant.Tenant_MiddleName = tenant.Tenant_MiddleName;
                    currenttenant.Tenant_LastName = tenant.Tenant_LastName;
                    currenttenant.Tenant_UserName = tenant.Tenant_UserName;
                    currenttenant.Tenant_Email = tenant.Tenant_Email;
                    currenttenant.Tenant_PhoneNumber = tenant.Tenant_PhoneNumber;
                    currenttenant.Tenant_UpdatedAt = tenant.Tenant_UpdatedAt;

                    _context.Update(currenttenant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TenantExists())
                    {
                        ViewData["SuccessfulEdit"] = null;
                        ViewData["ErrorEdit"] = "Not Found";
                        return View();
                    }
                    else
                    {
                        throw;
                    }
                }
                ViewData["ErrorEdit"] = null;
                ViewData["SuccessfulEdit"] = "Edit Successfully";
                return View();
            }
            ViewData["SuccessfulEdit"] = null;
            ViewData["ErrorEdit"] = "Edit Failed";
            return View(currenttenant);
        }

        public IActionResult ChangePass()
        {

            if (GetId() == null || _context.Tenant == null)
            {
                return RedirectToAction("Index", "TenantHome");
            }

            var tenant = _context.Tenant.Find(GetId());
            if (tenant == null)
            {
                return RedirectToAction("Index", "TenantHome");
            }
            return View(tenant);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePass([Bind("Tenant_Password")] Tenant tenant)
        {
            Tenant currenttenant = await _context.Tenant.FirstOrDefaultAsync(q => q.TenantId == GetId());

            if (currenttenant != null)
            {
                try
                {
                    if(currenttenant.Tenant_Password == Hashing.HashPass(tenant.Tenant_Password))
                    {
                        ViewData["SamePass"] = "Same Password";
                        return View();
                    }
                    currenttenant.Tenant_Password = Hashing.HashPass(tenant.Tenant_Password);
                    _context.Update(currenttenant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TenantExists())
                    {
                        ViewData["ChangePassSuccessful"] = null;
                        ViewData["ChangePassFail"] = "Not Found";
                        return View();
                    }
                    else
                    {
                        throw;
                    }
                }
                ViewData["ChangePassFail"] = null;
                ViewData["ChangePassSuccessful"] = "Changed Successfully";
                return View();
            }
            ViewData["ChangePassSuccessful"] = null;
            ViewData["ChangePassFail"] = "Changing Failed";
            return View();
        }

        public IActionResult ValidatePass()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ValidatePass([Bind("Tenant_Password")] Tenant tenant)
        {
            try
            {
                var pass = Hashing.HashPass(tenant.Tenant_Password);
                if (pass == null)
                {
                    ViewData["ValidationError"] = "ErrorPass";
                    return View();
                }
                Tenant currenttenant = await _context.Tenant.FirstOrDefaultAsync(q => q.TenantId == GetId() && q.Tenant_Password == Hashing.HashPass(tenant.Tenant_Password));

                if (currenttenant == null)
                {
                    ViewData["ValidationError"] = "ErrorPass";
                    return View();
                }
                ViewData["ValidationSuccess"] = "ValidateComp";
                return RedirectToAction("ChangePass", "TenantHome");
            }
            catch
            {
                ViewData["ValidationError"] = "ErrorPass";
                return View();
            }
        }

        // GET: Tenants/Delete/5
        public async Task<IActionResult> Delete()
        {
            if (GetId() == null || _context.Tenant == null)
            {
                return RedirectToAction("Index", "TenantHome");
            }

            var tenant = await _context.Tenant
                .FirstOrDefaultAsync(m => m.TenantId == GetId());
            if (tenant == null)
            {
                return NotFound();
            }

            return View(tenant);
        }

        // POST: Tenants/Delete/
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
