using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalManagement.Models
{
    public class Requisition
    {
        [Key]
        public int RequisitionId { get; set; }


        [Required(ErrorMessage = "Requisition Type is required.")]
        public string Requisition_Type { get; set; }


        public DateTime Requistition_CreatedAt { get; set; } = DateTime.Now;


        [StringLength(300, MinimumLength = 10, ErrorMessage = "Requisition Description must be more than 10 characters & maximum of 300 characters.")]
        public string Requisition_Remarks { get; set; }


        [Required(ErrorMessage = "Requisition Status is required.")]
        public string Requisition_Status { get; set; }


        [DataType(DataType.Date)]
        public DateTime Requisition_DueDate { get; set; }


        [ForeignKey("Tenants")]
        public int TenantId { get; set; }

        public virtual Tenant? Tenant { get; set; }

    }
}
