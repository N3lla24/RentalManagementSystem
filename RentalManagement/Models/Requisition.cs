using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalManagement.Models
{
    public class Requisition
    {
        [Key]
        public int RequisitionId { get; set; }


        [StringLength(50, MinimumLength = 2, ErrorMessage = "Requisition Type must be more than 2 and maximum of 50 characters.")]
        [Required(ErrorMessage = "Requisition Type is required.")]
        public string Requisition_Type { get; set; }


        public DateTime Requistition_CreatedAt { get; set; }


        [StringLength(100, MinimumLength = 2, ErrorMessage = "Requisition Status characters must be more than 2 and maximum of 100 characters.")]
        [Required(ErrorMessage = "Requisition Status is required.")]
        public string Requisition_Status { get; set; }

        [StringLength(300, MinimumLength = 2, ErrorMessage = "Requisition Status characters must be more than 2 and maximum of 300 characters.")]
        public string? Requisition_StatusRemarks { get; set; }


        [StringLength(300, MinimumLength = 10, ErrorMessage = "Requisition Description must be more than 10 characters & maximum of 300 characters.")]
        public string Requisition_Status_Remarks { get; set; }


        [DataType(DataType.Date)]
        public DateTime Requisition_DueDate { get; set; }


        [ForeignKey("Tenant")]
        public int? TenantId { get; set; }

        public virtual Tenant? Tenant { get; set; }
        public List<RequisitionItem>? RequisitionItems { get; set; }
        public List<RequisitionService>? RequisitionServices { get; set; }
    }
}
