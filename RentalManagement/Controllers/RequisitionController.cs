using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalManagement.Data;
using RentalManagement.Models;
using RentalManagement.ViewModel;

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
            var reqVM = new ReqVM();
            return View(reqVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ReqVM vm)
        {
            
                if (!ModelState.IsValid)
                {
                    // Log or inspect ModelState errors
                    var errors = ModelState.Values.SelectMany(v => v.Errors);
                    foreach (var error in errors)
                    {
                        Console.WriteLine($"ModelState Error: {error.ErrorMessage}");
                    }

                    return View(vm);
                }
                var tenantId = HttpContext.Session.GetInt32("TenantId");
                if (!tenantId.HasValue)
                {
                    // If TenantId is not found in session, redirect to login or handle as needed
                    return RedirectToAction("Index", "Login"); // Redirect to login page
                }


                Requisition requisition = new Requisition
                {
                    Requisition_Type = vm.Requisition_Type,
                    Requisition_Status_Remarks = vm.Requisition_Status_Remarks,
                    Requistition_CreatedAt = vm.Requistition_CreatedAt != DateTime.MinValue ? vm.Requistition_CreatedAt : DateTime.Now,
                    Requisition_DueDate = vm.Requisition_DueDate,
                    Requisition_Status = vm.Requisition_Status,
                    TenantId = vm.TenantId
                };

                if (vm.Requisition_Type == "REQUEST ITEM" && vm.ReqItem != null)
                {
                    requisition.RequisitionItems = vm.ReqItem.Select(item => new RequisitionItem
                    {
                        Req_Item_Name = item.Req_Item_Name,
                        Req_Item_Quantity = item.Req_Item_Quantity,
                        Req_Item_Units = item.Req_Item_Units
                    }).ToList();

                }
                else if (vm.Requisition_Type == "REQUEST SERVICE" && vm.ReqServ != null)
                {
                    requisition.RequisitionServices = vm.ReqServ.Select(service => new RequisitionService
                    {
                        Req_Serv_Name = service.Req_Serv_Name
                    }).ToList();

                }

                _context.Requisition.Add(requisition);
                _context.SaveChanges();
                return RedirectToAction("Details", "Requisition");
            
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
