using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace RentalManagement.Models
{
    public class RequisitionDisplay
    {
        [Key]
        public int RequisitionId { get; set; }

        public string Requisition_Type { get; set; }

        public DateTime Requistition_CreatedAt { get; set; }

        public string Requisition_Status { get; set; }

        public string Requisition_Status_Remarks { get; set; }

        [ForeignKey("Tenant")]
        public int? TenantId { get; set; }
    }
}
