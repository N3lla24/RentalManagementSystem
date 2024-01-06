﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Dynamic;
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
    public class ApplicantsController : Controller
    {
        private readonly RentalManagementContext _context;

        public ApplicantsController(RentalManagementContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET: Applicants
        public async Task<IActionResult> Indexf(Applicants applicants)
        {
            if (applicants.Applicants_Email != null && applicants.Applicants_PhoneNumber != null)
            {
                Applicants searchapplicant = await _context.Applicants.SingleOrDefaultAsync(q => q.Applicants_Email == applicants.Applicants_Email && q.Applicants_PhoneNumber == applicants.Applicants_PhoneNumber);
                if (searchapplicant != null)
                {
                    ViewData["SearchErrorMessage"] = null;
                    return RedirectToAction("Details", new {id = searchapplicant.ApplicationId});
                }
                ViewData["SearchErrorMessage"] = "Incorrect Username or Password";
                return View(applicants);
            }
            ViewData["SearchErrorMessage"] = "Incorrect Username or Password";
            return View(applicants);
        }

        // GET: Room/Details
        public async Task<IActionResult> RoomDetails(int? id)
        {
            if (id == null || _context.Room == null)
            {
                return NotFound();
            }

            var room = await _context.Room
                .FirstOrDefaultAsync(m => m.RoomId == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
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
            //Format Number
            if (applicants.Applicants_PhoneNumber.Length >= 4)
            {
                // Extract the first four digits and the rest of the phone number
                string firstFourDigits = applicants.Applicants_PhoneNumber.Substring(0, 4);
                string restOfNumber = applicants.Applicants_PhoneNumber.Substring(4);

                // Mask characters in the rest of the phone number with asterisks
                string maskedNumber = new string('*', restOfNumber.Length);

                // Combine the masked phone number
                string formattedPhoneNumber = $"{firstFourDigits}{maskedNumber}";

                // You can perform additional actions or validations here if needed

                // Return the formatted phone number
                applicants.Applicants_PhoneNumber = formattedPhoneNumber;
            }

            // Format Email
            string[] emailParts = applicants.Applicants_Email.Split('@');
            if (emailParts.Length == 2)
            {
                string username = emailParts[0];
                string domain = emailParts[1];

                // Mask characters in the username, keeping the first character visible
                string maskedUsername = username.Length > 1
                    ? $"{username[0]}{new string('*', username.Length - 1)}"
                    : username;

                // Mask characters in the domain, keeping the first character of each part visible
                string[] domainParts = domain.Split('.');
                for (int i = 0; i < domainParts.Length; i++)
                {
                    domainParts[i] = domainParts[i].Length > 1
                        ? $"{domainParts[i][0]}{new string('*', domainParts[i].Length - 1)}"
                        : domainParts[i];
                }

                // Join the masked domain parts back together
                string maskedDomain = string.Join(".", domainParts);

                // Assign the formatted email to a variable
                string formattedEmail = $"{maskedUsername}@{maskedDomain}";

                // You can perform additional actions or validations here if needed

                // Return the formatted email
                applicants.Applicants_Email =  formattedEmail;
            }
            return View(applicants);
        }

        // GET: Rooms
        public async Task<IActionResult> RoomPicking()
        {
            ApplicationViewModel obj = new ApplicationViewModel();
            obj.RoomModel = _context.Room.ToList();
            obj.UnitModel = _context.Unit.ToList();
            return View(obj);
        }

        // GET: Applicants/Create
        public IActionResult Create(int? id)
        {
            if (id == null || _context.Room == null)
            {
                return NotFound();
            }
            var roomnum = _context.Room.Find(id);
            var unitnum = _context.Unit.Find(roomnum.UnitId);
            if (roomnum == null || unitnum == null)
            {
                return NotFound();
            }
            ViewBag.Roomnum = roomnum.Room_Num;
            ViewBag.Unitnum = unitnum.Unit_Num;
            return View();
        }

        // POST: Applicants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ApplicationId,Applicants_FirstName,Applicants_MiddleName,Applicants_LastName,Applicants_Email,Applicants_PhoneNumber,Applicants_Address, Application_RoomNumber, Application_UnitNumber, Applicant_CreatedAt,Applicant_UpdatedAt")] Applicants applicants)
        {
            Applicants existingApplication = await _context.Applicants.FirstOrDefaultAsync(q => q.Applicants_Email == applicants.Applicants_Email && q.Applicants_PhoneNumber == applicants.Applicants_PhoneNumber);

            if (existingApplication == null)
            {
                applicants.Application_Status = "Pending";
                ViewData["ExistingApplicant"] = null;
                ViewData["Successful"] = "Success";
                _context.Add(applicants);
                await _context.SaveChangesAsync();
                return View();
            }
            ViewData["Successful"] = null;
            ViewData["ExistingApplicant"] = "Applicant Existing";
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
        public async Task<IActionResult> Edit(int id, [Bind("ApplicationId,Applicants_FirstName,Applicants_MiddleName,Applicants_LastName,Applicants_Email,Applicants_PhoneNumber,Applicants_Address,Applicant_CreatedAt,Applicant_UpdatedAt")] Applicants applicants)
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
