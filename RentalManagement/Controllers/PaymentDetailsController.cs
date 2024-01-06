using System;
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
    public class PaymentDetailsController : Controller
    {
        private readonly RentalManagementContext _context;

        public PaymentDetailsController(RentalManagementContext context)
        {
            _context = context;
        }

        // GET: PaymentDetails
        public async Task<IActionResult> Index()
        {
            return _context.PaymentDetail != null ?
                        View(await _context.PaymentDetail.ToListAsync()) :
                        Problem("Entity set 'RentalManagementContext.PaymentDetail'  is null.");
        }

        // GET: PaymentDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PaymentDetail == null)
            {
                return NotFound();
            }

            var paymentDetail = await _context.PaymentDetail
                .FirstOrDefaultAsync(m => m.Pay_ID == id);
            if (paymentDetail == null)
            {
                return NotFound();
            }

            return View(paymentDetail);
        }

        // GET: PaymentDetails/Create
        public IActionResult Create()
        {
            // Assume you have a list of tenants to choose from
            ViewBag.Tenants = new SelectList(_context.Tenant.ToList(), "TenantId", "Tenant_FirstName");

            return View();
        }

        // POST: PaymentDetails/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Pay_ID,Pay_DueDate,Pay_RentPrice,Pay_UtilityFee,Pay_GarbageFee,Pay_AirconFee,Pay_InternetFee,Pay_RefrigeratorFee,Pay_WashingFee,Pay_CreatedAt,TenantId,Inv_Method")] PaymentDetail paymentDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paymentDetail);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            // If ModelState is not valid, repopulate the Tenant dropdown
            ViewBag.Tenants = new SelectList(_context.Tenant.ToList(), "TenantId", "Tenant_FirstName", paymentDetail.TenantId);

            return View(paymentDetail);
        }

        // GET: PaymentDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PaymentDetail == null)
            {
                return NotFound();
            }

            var paymentDetail = await _context.PaymentDetail.FindAsync(id);
            if (paymentDetail == null)
            {
                return NotFound();
            }
            return View(paymentDetail);
        }

        // POST: PaymentDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Pay_ID,Pay_DueDate,Pay_RentPrice,Pay_UtilityFee,Pay_GarbageFee,Pay_AirconFee,Pay_InternetFee,Pay_RefrigeratorFee,Pay_WashingFee,Pay_CreatedAt")] PaymentDetail paymentDetail)
        {
            if (id != paymentDetail.Pay_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paymentDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentDetailExists(paymentDetail.Pay_ID))
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
            return View(paymentDetail);
        }

        // GET: PaymentDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PaymentDetail == null)
            {
                return NotFound();
            }

            var paymentDetail = await _context.PaymentDetail
                .FirstOrDefaultAsync(m => m.Pay_ID == id);
            if (paymentDetail == null)
            {
                return NotFound();
            }

            return View(paymentDetail);
        }

        // POST: PaymentDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PaymentDetail == null)
            {
                return Problem("Entity set 'RentalManagementContext.PaymentDetail'  is null.");
            }
            var paymentDetail = await _context.PaymentDetail.FindAsync(id);
            if (paymentDetail != null)
            {
                _context.PaymentDetail.Remove(paymentDetail);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentDetailExists(int id)
        {
            return (_context.PaymentDetail?.Any(e => e.Pay_ID == id)).GetValueOrDefault();
        }
    }
}