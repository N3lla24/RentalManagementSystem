using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using RentalManagement.Data;
using RentalManagement.Models;
using System.Threading.Tasks;

namespace RentalManagement.Controllers
{
    public class AdminHome : Controller
    {
        private readonly RentalManagementContext _context;

        private readonly ILogger<AdminHome> _logger;

        public AdminHome(ILogger<AdminHome> logger, RentalManagementContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Home()
        {
            return View();
        }

        public async Task<IActionResult> ManageRental()
        {
            try
            {
                var tenant = await _context.Tenant.ToListAsync();
                var requisition = await _context.Requisition.ToListAsync();
                var room = await _context.Room.ToListAsync();
                var feedback = await _context.Feedback.ToListAsync();
                var applicants = await _context.Applicants.ToListAsync();
                var payment = await _context.PaymentDetail.ToListAsync();

                if (tenant != null && requisition != null && room != null && feedback != null && payment != null && applicants != null)
                {
                    var tenantDisplayList = tenant.Select(tenant => new TenantDisplay
                    {
                        TenantId = tenant.TenantId, 
                        Tenant_FirstName = tenant.Tenant_FirstName,
                        Tenant_LastName = tenant.Tenant_LastName,

                    }).ToList();

                    var requisitionDisplayList = requisition.Select(requisition => new RequisitionDisplay
                    {
                        RequisitionId = requisition.RequisitionId,
                        Requisition_Type = requisition.Requisition_Type,
                        Requistition_CreatedAt = requisition.Requistition_CreatedAt,

                    }).ToList();

                    var roomDisplayList = room.Select(room => new RoomDisplay
                    {
                        RoomId = room.RoomId,
                        Room_Num = room.Room_Num,
                        Room_Status = room.Room_Status,
                        Room_Capacity = room.Room_Capacity,

                    }).ToList();

                    var feedbackDisplayList = feedback.Select(feedback => new FeedbackDisplay
                    {
                        FeedbackId = feedback.FeedbackId,
                        Feedback_Email = feedback.Feedback_Email,
                        Feedback_Content = feedback.Feedback_Content,

                    }).ToList();

                    var appDisplayList = applicants.Select(applicants => new ApplicationDisplay
                    {
                        ApplicationId = applicants.ApplicationId,
                        Applicants_FirstName = applicants.Applicants_FirstName,
                        Applicants_MiddleName = applicants.Applicants_MiddleName,
                        Applicants_LastName = applicants.Applicants_LastName,
                        Applicants_Email = applicants.Applicants_Email,
                        Applicants_PhoneNumber = applicants.Applicants_PhoneNumber,
                        Applicants_Address = applicants.Applicants_Address,
                        Application_RoomNumber = applicants.Application_RoomNumber,
                        Application_UnitNumber = applicants.Application_UnitNumber,
                        Application_Status = applicants.Application_Status,
                        Applicant_CreatedAt = applicants.Applicant_CreatedAt,
                        Applicant_UpdatedAt = applicants.Applicant_UpdatedAt,
                    }).ToList();

                    var monthlyTotals = payment
                    .GroupBy(p => p.Pay_CreatedAt.ToString("yyyy-MM"))
                    .Select(g => new ReportsDisplay
                    {
                        Month = g.Key, 
                        TotalFees = g.Sum(p => p.Pay_RentPrice + p.Pay_UtilityFee + p.Pay_GarbageFee + p.Pay_AirconFee + p.Pay_InternetFee + p.Pay_RefrigeratorFee + p.Pay_WashingFee)
                    })
                    .ToList();

                    var viewModel = new RentalViewModel
                    {
                        Tenant = tenantDisplayList,
                        Requisition = requisitionDisplayList,
                        Room = roomDisplayList,
                        Feedback = feedbackDisplayList,
                        Reports = monthlyTotals,
                        Applicants = appDisplayList
                        
                    };


                    return View(viewModel);
                }
                else
                {
                    return Problem("Error fetching data from the database.");
                }
            }
            catch (Exception ex)
            {
                // Log and handle the exception
                _logger.LogError(ex, "An error occurred while processing the application.");
                return Content("An unexpected error occurred. Please try again later.");
            }
        }


        public async Task<IActionResult> AppDetails(int? id)
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

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("AdminID");
            return RedirectToAction("Index", "Home");
        }
    }
}
