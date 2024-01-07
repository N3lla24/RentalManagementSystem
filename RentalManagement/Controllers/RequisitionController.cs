using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalManagement.Data;
using RentalManagement.Models;
using System.Diagnostics;


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
        
        private int? GetId()
        {
            var id = HttpContext.Session.GetInt32("accountid");
            if (id is not null) { return id; }
            return null;
        }
        public IActionResult Details()
        {
            int? tenantId = GetId();

            if (!tenantId.HasValue)
            {
                return NotFound();
            }

            var requisition = _context.Requisition
            .Include(r => r.Tenant)
            .Include(r => r.RequisitionItems)
            .Include(r => r.RequisitionServices)
            .Where(r => r.TenantId == tenantId.Value)
            .ToList();

            if (requisition == null || requisition.Count == 0)
            {
                return View("Index","TenantHome"); 
            }
            

            return View(requisition);
        }
        
        public async Task<IActionResult> Create()
        {
            var loggedInTenantId = GetId();

            if (loggedInTenantId == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var requisition = new RentalManagement.Models.Requisition();

            
            return View(requisition);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Requisition requisition)
        {
            try
            {

                int? tenantId = GetId();

                if (tenantId == null)
                {
                    Debug.WriteLine("TenantId is null. Redirecting to Index action of Login controller.");
                    return RedirectToAction("Index", "Login");
                }

                requisition.Requisition_CreatedAt = DateTime.Now;
                requisition.TenantId = tenantId.Value;

                if (requisition.Requisition_Type == "REQUEST_ITEM")
                {
                    foreach (var item in requisition.RequisitionItems)
                    {
                        item.RequisitionId = requisition.RequisitionId;
                        _context.RequisitionItem.Add(item);
                    }
                    requisition.RequisitionServices = null;

                }
                else if (requisition.Requisition_Type == "REQUEST_SERVICE")
                {
                    foreach (var service in requisition.RequisitionServices)
                    {
                        service.RequisitionId = requisition.RequisitionId;
                        _context.RequisitionService.Add(service);
                    }
                    requisition.RequisitionItems = null;
                }
                _context.Requisition.Add(requisition);
                _context.SaveChanges();

                return RedirectToAction("Index","TenantHome");

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error processing the request: " + ex.Message);
                return View("Index", requisition);
            }

        }

    }
}
