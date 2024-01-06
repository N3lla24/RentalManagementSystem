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
    public class SuppliersController : Controller
    {
        private readonly RentalManagementContext _context;

        public SuppliersController(RentalManagementContext context)
        {
            _context = context;
        }

        // GET: Suppliers
        public async Task<IActionResult> Index()
        {
            return _context.Supplier != null ?
                         View(await _context.Supplier.ToListAsync()) :
                         Problem("Entity set 'RentalManagementContext.Supplier'  is null.");
        }

        // GET: Suppliers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Supplier == null)
            {
                return NotFound();
            }

            var supplier = await _context.Supplier
                .FirstOrDefaultAsync(m => m.SuppliersId == id);
            if (supplier == null)
            {
                return NotFound();
            }

            return View(supplier);
        }

        // GET: Suppliers/GetSuppliersJson
        public async Task<JsonResult> GetSuppliersJson()
        {
            var suppliers = await _context.Supplier.ToListAsync();
            return Json(suppliers);
        }

        // GET: Suppliers/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSupplier([FromBody] Supplier supplier)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(supplier);
                    await _context.SaveChangesAsync();
                    return Ok(); // Return success status
                }
                else
                {
                    return BadRequest("Invalid supplier data."); // Return bad request status
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}"); // Return internal server error status
            }
        }

        // POST: Suppliers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SuppliersId,Suppliers_Name,Suppliers_Email,Suppliers_PhoneNumber,Suppliers_Address,Supplier_CreatedAt,Supplier_UpdatedAt")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                _context.Add(supplier);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(supplier);
        }

        // GET: Suppliers/Edit/5
        public async Task<IActionResult> EditModal(int? id)
        {
            if (id == null || _context.Supplier == null)
            {
                return NotFound();
            }

            var supplier = await _context.Supplier.FindAsync(id);
            if (supplier == null)
            {
                return NotFound();
            }
            return PartialView("_EditModal", supplier);
        }

        // GET: Suppliers/GetSupplierDetails/5
        [HttpGet]
        public async Task<JsonResult> GetSupplierDetails(int id)
        {
            var supplier = await _context.Supplier
                .FirstOrDefaultAsync(m => m.SuppliersId == id);

            return Json(supplier);
        }

        // POST: Suppliers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditModal(int id, [Bind("SuppliersId,Suppliers_Name,Suppliers_Email,Suppliers_PhoneNumber,Suppliers_Address,Supplier_CreatedAt,Supplier_UpdatedAt")] Supplier supplier)
        {
            if (id != supplier.SuppliersId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supplier);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupplierExists(supplier.SuppliersId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                var updatedSupplier = await _context.Supplier
                .FirstOrDefaultAsync(m => m.SuppliersId == id);

                return Json(updatedSupplier);
            }
            return PartialView("_EditModal", supplier);
        }

        // GET: Suppliers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Supplier == null)
            {
                return NotFound();
            }

            var supplier = await _context.Supplier
                .FirstOrDefaultAsync(m => m.SuppliersId == id);
            if (supplier == null)
            {
                return NotFound();
            }

            return View(supplier);
        }

        // POST: Suppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Supplier == null)
            {
                return Problem("Entity set 'RentalManagementContext.Supplier'  is null.");
            }
            var supplier = await _context.Supplier.FindAsync(id);
            if (supplier != null)
            {
                _context.Supplier.Remove(supplier);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: PurchaseOrders/ViewDeliveryRecords/5
        public async Task<IActionResult> ViewDeliveryRecords(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryRecord = await _context.ReceivingMemo
                .Join(_context.PurchaseOrder,
                    rm => rm.PurchaseId,
                    po => po.PurchaseOrderId,
                    (rm, po) => new { rm, po })
                .Join(_context.PurchaseItem,
                    combined => combined.po.PurchaseOrderId,
                    pi => pi.PurchaseItem_Id,
                    (combined, pi) => new { combined.rm, combined.po, pi })
                .Join(_context.Supplier,
                    combined => combined.po.SuppliersId,
                    s => s.SuppliersId,
                    (combined, s) => new
                    {
                        combined.rm.RM_Date,
                        combined.rm.RM_Remarks,
                        combined.rm.RM_Status,
                        combined.pi.PurchaseItem_Name,
                        combined.pi.PurchaseItem_Quantity,
                        combined.pi.PurchaseItem_Unit,
                        s.Suppliers_Name,
                        s.Suppliers_Address
                    })
                .FirstOrDefaultAsync();

            if (deliveryRecord == null)
            {
                return NotFound();
            }

            return View(deliveryRecord);
        }

        private bool SupplierExists(int id)
        {
            return (_context.Supplier?.Any(e => e.SuppliersId == id)).GetValueOrDefault();
        }
    }
}