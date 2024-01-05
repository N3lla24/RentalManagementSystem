using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RentalManagement.Data;
using System.Threading.Tasks;

namespace RentalManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequisitionApiController : ControllerBase
    {
        private readonly RentalManagementContext _context;

        public RequisitionApiController(RentalManagementContext context)
        {
            _context = context;
        }

        [HttpGet("getRequisitionDetails/{RequisitionId}")]
        public IActionResult GetRequisitionDetails(int requisitionId) // ERROR!
        {
            /*try
            {
                var requisitionDetails = _context.Requisition
                    .Include(r => r.Tenant) // Include the related Tenant entity
                    .FirstOrDefault(r => r.RequisitionId == requisitionId);

                if (requisitionDetails != null)
                {
                    // DTO
                    var detailsToReturn = new
                    {
                        RequisitionId = requisitionDetails.RequisitionId,
                        Requisition_Type = requisitionDetails.Requisition_Type,
                        Requistition_CreatedAt = requisitionDetails.Requistition_CreatedAt,
                        TenantFirstName = requisitionDetails.Tenant.Tenant_FirstName, 
                        TenantLastName = requisitionDetails.Tenant.Tenant_LastName 
                    };

                    // return Json(detailsToReturn);
                }
                else
                {
                    return NotFound(); 
                }
            }
            catch (Exception ex)
            {
                // Log and handle the exception 
                _logger.LogError(ex, "An error occurred while processing GetRequisitionDetails.");
                return StatusCode(500, "An unexpected error occurred.");
            } ERROR PASAD NI SIYA */
            return NotFound();
        }
    }
}
