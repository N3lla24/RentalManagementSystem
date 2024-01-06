using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentalManagement.Data;
using RentalManagement.Models;
using SixLabors.ImageSharp;

namespace RentalManagement.Controllers
{
    public class InvoicesController : Controller
    {
        private readonly RentalManagementContext _context;

        public InvoicesController(RentalManagementContext context)
        {
            _context = context;
        }

        // GET: Invoices
        public async Task<IActionResult> Index()
        {
            // Filter invoices based on status (e.g., only show invoices with status "Pending")
            var invoices = await _context.Invoice
                .Include(i => i.PaymentDetail)
                .Include(i => i.Tenant)
                .Where(i => i.Inv_Status == "Pending")
                .ToListAsync();

            return View(invoices);
        }

        // GET: Invoices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Invoice == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoice
                .Include(i => i.PaymentDetail)
                .Include(i => i.Tenant)
                .FirstOrDefaultAsync(m => m.Inv_ID == id);
            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }

        // GET: Invoices/Create
        public IActionResult Create()
        {
            ViewData["Pay_ID"] = new SelectList(_context.PaymentDetail, "Pay_ID", "Pay_ID");
            ViewData["TenantId"] = new SelectList(_context.Tenant, "TenantId", "Tenant_Email");
            return View();
        }

        // GET: Invoices/CheckInvoice/5
        public async Task<IActionResult> CheckInvoice(int? id)
        {
            if (id == null || _context.Invoice == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoice
                .Include(i => i.PaymentDetail)
                .Include(i => i.Tenant)
                .FirstOrDefaultAsync(m => m.Inv_ID == id);

            if (invoice == null)
            {
                return NotFound();
            }

            // You may want to check if the invoice is pending before displaying details
            if (invoice.Inv_Status != "Pending")
            {
                return RedirectToAction(nameof(Index));
            }

            // Load payment details, proof of payment, and calculate total fees
            var paymentDetail = await _context.PaymentDetail.FindAsync(invoice.Pay_ID);

            if (paymentDetail == null)
            {
                return NotFound();
            }

            // Calculate total fees
            decimal totalFees = paymentDetail.Pay_RentPrice +
                                paymentDetail.Pay_UtilityFee +
                                paymentDetail.Pay_GarbageFee +
                                paymentDetail.Pay_AirconFee +
                                paymentDetail.Pay_InternetFee +
                                paymentDetail.Pay_RefrigeratorFee +
                                paymentDetail.Pay_WashingFee;

            ViewBag.TotalFees = totalFees;

            return View(invoice);
        }

        // POST: Invoices/SelectPaymentMethod/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SelectPaymentMethod(int id, string paymentMethod)
        {
            var invoice = await _context.Invoice.FindAsync(id);

            if (invoice == null)
            {
                return NotFound();
            }

            invoice.Inv_Method = paymentMethod;
            _context.Update(invoice);
            await _context.SaveChangesAsync();

            if (paymentMethod == "Gcash")
            {
                return RedirectToAction(nameof(GcashPayment), new { id = invoice.Inv_ID });
            }
            else if (paymentMethod == "Cash")
            {
                return RedirectToAction(nameof(CashPayment), new { id = invoice.Inv_ID });
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Invoices/GcashPayment/5
        public IActionResult GcashPayment(int? id)
        {
            // Implement your Gcash payment form view
            return View();
        }

        // POST: Invoices/GcashPayment/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GcashPayment(int id, IFormFile proofOfPayment)
        {
            try
            {

                if (proofOfPayment != null && proofOfPayment.Length > 0)
                {
                    // Custom validation for proof of payment file
                    if (!IsValidImage(proofOfPayment))
                    {
                        ModelState.AddModelError("proofOfPayment", "Invalid file format. Please upload a valid image.");
                        return View();
                    }

                    // Handle file upload and save to database
                    using (var memoryStream = new MemoryStream())
                    {
                        await proofOfPayment.CopyToAsync(memoryStream);

                        var invoice = await _context.Invoice
                            .Include(i => i.PaymentDetail)
                            .FirstOrDefaultAsync(i => i.Inv_ID == id);

                        if (invoice != null && invoice.PaymentDetail != null)
                        {
                            invoice.Inv_ProofPayment = memoryStream.ToArray();
                            _context.Update(invoice.PaymentDetail);
                            await _context.SaveChangesAsync();
                        }
                    }
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (ImageProcessingException ex)
            {
                // Log the exception
                ModelState.AddModelError("proofOfPayment", "An error occurred during payment processing. Please try again.");
                return View();
            }

            ModelState.AddModelError("proofOfPayment", "Please upload a file.");
            return View();
        }

        // GET: Invoices/CashPayment/5
        public IActionResult CashPayment(int? id)
        {
            // Implement your Cash payment form view
            return View();
        }

        // POST: Invoices/CashPayment/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CashPayment(int id, IFormFile proofOfPayment)
        {
            try
            {

                if (proofOfPayment != null && proofOfPayment.Length > 0)
                {
                    // Custom validation for proof of payment file
                    if (!IsValidImage(proofOfPayment))
                    {
                        ModelState.AddModelError("proofOfPayment", "Invalid file format. Please upload a valid image.");
                        return View();
                    }

                    // Handle file upload and save to database
                    using (var memoryStream = new MemoryStream())
                    {
                        await proofOfPayment.CopyToAsync(memoryStream);

                        var invoice = await _context.Invoice
                            .Include(i => i.PaymentDetail)
                            .FirstOrDefaultAsync(i => i.Inv_ID == id);

                        if (invoice != null && invoice.PaymentDetail != null)
                        {
                            invoice.Inv_ProofPayment = memoryStream.ToArray();
                            _context.Update(invoice.PaymentDetail);
                            await _context.SaveChangesAsync();
                        }
                    }
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (ImageProcessingException ex)
            {
                // Log the exception
                ModelState.AddModelError("proofOfPayment", "An error occurred during payment processing. Please try again.");
                return View();
            }

            ModelState.AddModelError("proofOfPayment", "Please upload a file.");
            return View();
        }

        private bool IsValidImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return false; // No file provided
            }

            try
            {
                using (var image = Image.Load(file.OpenReadStream()))
                {
                    return true; // The file is a valid image
                }
            }
            catch
            {
                return false; // The file is not a valid image
            }
        }

        // POST: Invoices/CompletePayment/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CompletePayment(int id)
        {
            var invoice = await _context.Invoice.FindAsync(id);

            if (invoice == null)
            {
                return NotFound();
            }

            // Update invoice status to completed
            invoice.Inv_Status = "Completed";
            _context.Update(invoice);
            await _context.SaveChangesAsync();

            // Send email to the tenant
            // You can implement your logic for sending emails here

            return RedirectToAction(nameof(Index));
        }

        // POST: Invoices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Inv_ID,Inv_CreatedAt,Inv_Method,Inv_Status,TenantId,Pay_ID")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invoice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Pay_ID"] = new SelectList(_context.PaymentDetail, "Pay_ID", "Pay_ID", invoice.Pay_ID);
            ViewData["TenantId"] = new SelectList(_context.Tenant, "TenantId", "Tenant_Email", invoice.TenantId);
            return View(invoice);
        }

        // GET: Invoices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Invoice == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoice.FindAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }
            ViewData["Pay_ID"] = new SelectList(_context.PaymentDetail, "Pay_ID", "Pay_ID", invoice.Pay_ID);
            ViewData["TenantId"] = new SelectList(_context.Tenant, "TenantId", "Tenant_Email", invoice.TenantId);
            return View(invoice);
        }

        // POST: Invoices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Inv_ID,Inv_CreatedAt,Inv_Method,Inv_Status,TenantId,Pay_ID")] Invoice invoice)
        {
            if (id != invoice.Inv_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invoice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvoiceExists(invoice.Inv_ID))
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
            ViewData["Pay_ID"] = new SelectList(_context.PaymentDetail, "Pay_ID", "Pay_ID", invoice.Pay_ID);
            ViewData["TenantId"] = new SelectList(_context.Tenant, "TenantId", "Tenant_Email", invoice.TenantId);
            return View(invoice);
        }

        // GET: Invoices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Invoice == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoice
                .Include(i => i.PaymentDetail)
                .Include(i => i.Tenant)
                .FirstOrDefaultAsync(m => m.Inv_ID == id);
            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }

        // POST: Invoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Invoice == null)
            {
                return Problem("Entity set 'RentalManagementContext.Invoice'  is null.");
            }
            var invoice = await _context.Invoice.FindAsync(id);
            if (invoice != null)
            {
                _context.Invoice.Remove(invoice);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvoiceExists(int id)
        {
            return (_context.Invoice?.Any(e => e.Inv_ID == id)).GetValueOrDefault();
        }
    }
}