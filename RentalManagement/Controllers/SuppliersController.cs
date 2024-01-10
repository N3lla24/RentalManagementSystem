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

        [HttpGet]
        public IActionResult GetSuppliers()
        {
            var suppliers = _context.Supplier.ToList();
            return Json(suppliers);
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

            return Json(supplier);
        }

        // GET: Suppliers/Create
        public IActionResult Create()
        {
            return View();
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

        [HttpPost]
        public IActionResult InsertSupplier([FromBody] Supplier supplier)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(supplier);
                    _context.SaveChanges();
                    return Json(new { success = true });
                }
                else
                {
                    // Return validation errors to the client
                    var errors = ModelState.ToDictionary(
                        kvp => kvp.Key,
                        kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToList()
                    );

                    return Json(new { success = false, errors });
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return Json(new { success = false, error = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult CheckNameExists(string name)
        {
            // Your logic to check if the name already exists in the database
            bool exists = _context.Supplier.Any(s => s.Suppliers_Name == name);

        return Json(new { exists });
        }

        // GET: Suppliers/Edit/5
        public async Task<IActionResult> Edit(int? id)
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
            return Json(supplier);
        }

        // POST: Suppliers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SuppliersId,Suppliers_Name,Suppliers_Email,Suppliers_PhoneNumber,Suppliers_Address,Supplier_CreatedAt,Supplier_UpdatedAt")] Supplier supplier)
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
                return RedirectToAction(nameof(Index));
            }
            return Json(supplier);
        }

        // POST: /Suppliers/DeleteSupplier/1
        [HttpPost]
        public JsonResult DeleteSupplier(int id)
        {
            try
            {
                // Find the supplier by ID
                var supplier = _context.Supplier.Find(id);

                if (supplier != null)
                {
                    // Remove the supplier from the database
                    _context.Supplier.Remove(supplier);
                    _context.SaveChanges();

                    return Json(new { success = true });
                }
                else
                {
                    // Supplier not found
                    return Json(new { success = false, error = "Supplier not found" });
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                return Json(new { success = false, error = ex.Message });
            }
        }

        private bool SupplierExists(int id)
        {
          return (_context.Supplier?.Any(e => e.SuppliersId == id)).GetValueOrDefault();
        }
    }
}
