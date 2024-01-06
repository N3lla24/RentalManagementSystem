using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalManagement.Data;
using RentalManagement.Models;
using RentalManagement.ViewModel;
using System.Linq;

namespace RentalManagement.Controllers
{
    public class RequisitionController : Controller
    {
        private readonly RentalManagementContext _context;
        public RequisitionController(RentalManagementContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            // Retrieve the requisition details from the database based on the provided id
            Requisition requisition = _context.Requisition
                .Include(r => r.Tenant)
                .Include(r => r.RequisitionItems)
                .Include(r => r.RequisitionServices)
                .FirstOrDefault(r => r.RequisitionId == id);

            if (requisition == null)
            {
                return NotFound(); // Return a 404 Not Found if requisition is not found
            }

            // Check if the TenantId of the requisition matches the TenantId in the session
            var tenantId = HttpContext.Session.GetInt32("TenantId");
            if (tenantId != requisition.TenantId)
            {
                // If TenantId doesn't match, the user is not authorized to view this requisition
                return Forbid(); // Or redirect to an unauthorized page
            }

            return View(requisition); /// Pass the requisition object to the view
        }

        public ActionResult Create()
        {
            // Initialize your ViewModel and pass it to the view
            var requisition = new RentalManagement.Models.Requisition();

            // Your logic to populate the requisition model

            return View(requisition);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Requisition requisition)
        {
            try
            {
                var loggedInTenantId = HttpContext.Session.GetInt32("TenantId");

                if (!loggedInTenantId.HasValue)
                {
                    // Redirect or handle the case where TenantId is not in the session
                    return RedirectToAction("Login");
                }

                requisition.TenantId = loggedInTenantId.Value;
                // Handle the dynamic fields here
                if (requisition.Requisition_Type == "REQUEST_ITEM")
                {
                    // Save RequisitionItems data to the database
                    foreach (var item in requisition.RequisitionItems)
                    {
                        // Ensure each item is associated with the correct Requisition
                        item.RequisitionId = requisition.RequisitionId;
                        _context.RequisitionItem.Add(item);
                    }
                    requisition.RequisitionServices = null;

                }
                else if (requisition.Requisition_Type == "REQUEST_SERVICE")
                {
                    // Save RequisitionServices data to the database
                    foreach (var service in requisition.RequisitionServices)
                    {
                        // Ensure each service is associated with the correct Requisition
                        service.RequisitionId = requisition.RequisitionId;
                        _context.RequisitionService.Add(service);
                    }
                    requisition.RequisitionItems = null;
                }
                // Save Requisition data to the database
                _context.Requisition.Add(requisition);
                _context.SaveChanges();

                return RedirectToAction("Details");
            }
            catch (Exception ex)
            {
                // Handle errors
                ModelState.AddModelError(string.Empty, "Error processing the request: " + ex.Message);
                return View("Index", requisition);
            }
        }

    }
}
