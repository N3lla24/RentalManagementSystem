using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalManagement.Data;
using RentalManagement.Models;
using RentalManagement.ViewModel;
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

            var requisitions = _context.Requisition
                .Include(r => r.Tenant)
                .Include(r => r.RequisitionItems)
                .Include(r => r.RequisitionServices)
                .Where(r => r.TenantId == tenantId.Value)
                .ToList();


            return View(requisitions);
        }
        //GET:Create
        public IActionResult Create()
        {
            var loggedInTenantId = GetId();

            if (loggedInTenantId == null)
            {
                return RedirectToAction("Index", "Login");
            }

            ReqVM vm = new ReqVM
            {
                Requisition = new Requisition(),
                RequisitionItem = new List<RequisitionItem>(),
                RequisitionService = new List<RequisitionService>(),
                Inventories = _context.Inventory.ToList()
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReqVM r)
        {

            int? tenantId = GetId();

            if (tenantId == null)
            {
                Debug.WriteLine("TenantId is null. Redirecting to Index action of Login controller.");
                return RedirectToAction("Index", "Login");
            }

            

            Requisition req = new Requisition
            {
                Requisition_CreatedAt = DateTime.Now,
                Requisition_Remarks = r.Requisition.Requisition_Remarks,
                Requisition_DueDate = r.Requisition.Requisition_DueDate,
                Requisition_Status = "Pending",
                Requisition_Type = r.Requisition.Requisition_Type,
                TenantId = tenantId.Value
            };

            _context.Requisition.Add(req);
            _context.SaveChanges();


            if (r.Requisition.Requisition_Type == "REQUEST_ITEM")
            {
                foreach (var item in r.RequisitionItem)
                {
                    item.RequisitionId = req.RequisitionId;
                    _context.RequisitionItem.Add(item);
                }
                r.RequisitionService = null;
                _context.SaveChanges();

            }
            else if (r.Requisition.Requisition_Type == "REQUEST_SERVICE")
            {
                foreach (var service in r.RequisitionService)
                {
                    service.RequisitionId = req.RequisitionId;
                    _context.RequisitionService.Add(service);
                }
                r.RequisitionItem = null;
                _context.SaveChanges();

            }

            return RedirectToAction("Index", "TenantHome");

        }

    }
}
