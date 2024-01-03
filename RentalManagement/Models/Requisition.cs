using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalManagement.Models
{
    public class Requisition
    {
        [Key]
        public int RequisitionId { get; set; }


        [StringLength(50, MinimumLength = 2, ErrorMessage = "Username characters must be more than 2 and maximum of 50 characters.")]
        [Required(ErrorMessage = "Requisition Type is required.")]
        public string Requisition_Type { get; set; }


        public DateTime Requistition_CreatedAt { get; set; }


        [StringLength(100, MinimumLength = 2, ErrorMessage = "Username characters must be more than 2 and maximum of 100 characters.")]
        [Required(ErrorMessage = "Requisition Status is required.")]
        public string Requisition_Status { get; set; }



        [ForeignKey("Tenants")]
        public int TenantId { get; set; }

        public virtual Tenant? Tenant { get; set; }

    }
}
