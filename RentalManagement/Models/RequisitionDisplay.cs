using System.ComponentModel.DataAnnotations;

namespace RentalManagement.Models
{
    public class RequisitionDisplay
    {
        [Key]
        public int RequisitionId { get; set; }

        public string Requisition_Type { get; set; }

        public DateTime Requistition_CreatedAt { get; set; }
        
        [ForeignKey("Tenant")]
        public int? TenantId { get; set; }
    }
}
