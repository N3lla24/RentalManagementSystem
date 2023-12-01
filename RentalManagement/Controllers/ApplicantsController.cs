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
    public class ApplicantsController : Controller
    {
        private readonly RentalManagementContext _context;

        public ApplicantsController(RentalManagementContext context)
        {
            _context = context;
        }

        // GET: Applicants
        public async Task<IActionResult> Index()
        {
              return _context.Applicants != null ? 
                          View(await _context.Applicants.ToListAsync()) :
                          Problem("Entity set 'RentalManagementContext.Applicants'  is null.");
        }

        // GET: Applicants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Applicants == null)
            {
                return NotFound();
            }

            var applicants = await _context.Applicants
                .FirstOrDefaultAsync(m => m.ApplicationId == id);
            if (applicants == null)
            {
                return NotFound();
            }

            return View(applicants);
        }

        // GET: Applicants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Applicants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ApplicationId,Applicants_Name,Applicants_Email,Applicants_PhoneNumber,Applicants_Address,Applicant_CreatedAt,Applicant_UpdatedAt")] Applicants applicants)
        {
            if (ModelState.IsValid)
            {
                _context.Add(applicants);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(applicants);
        }

        // GET: Applicants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Applicants == null)
            {
                return NotFound();
            }

            var applicants = await _context.Applicants.FindAsync(id);
            if (applicants == null)
            {
                return NotFound();
            }
            return View(applicants);
        }

        // POST: Applicants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ApplicationId,Applicants_Name,Applicants_Email,Applicants_PhoneNumber,Applicants_Address,Applicant_CreatedAt,Applicant_UpdatedAt")] Applicants applicants)
        {
            if (id != applicants.ApplicationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(applicants);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicantsExists(applicants.ApplicationId))
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
            return View(applicants);
        }

        // GET: Applicants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Applicants == null)
            {
                return NotFound();
            }

            var applicants = await _context.Applicants
                .FirstOrDefaultAsync(m => m.ApplicationId == id);
            if (applicants == null)
            {
                return NotFound();
            }

            return View(applicants);
        }

        // POST: Applicants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Applicants == null)
            {
                return Problem("Entity set 'RentalManagementContext.Applicants'  is null.");
            }
            var applicants = await _context.Applicants.FindAsync(id);
            if (applicants != null)
            {
                _context.Applicants.Remove(applicants);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicantsExists(int id)
        {
          return (_context.Applicants?.Any(e => e.ApplicationId == id)).GetValueOrDefault();
        }
    }
}
