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

                if (tenant != null && requisition != null && room != null && feedback != null && payment != null/* && applicants != null*/)
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
                        Reports = monthlyTotals

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


        public IActionResult Logout()
        {
            HttpContext.Session.Remove("AdminID");
            return RedirectToAction("Index", "Home");
        }
    }
}
