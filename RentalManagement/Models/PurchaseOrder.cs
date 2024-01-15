using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalManagement.Models
{
    public class PurchaseOrder
    {
        [Key]
        public int PurchaseOrderId { get; set; }

        [StringLength(100, MinimumLength = 2, ErrorMessage = "Purchase Status must be more than 2 characters and maximum of 100 characters.")]
        [Required(ErrorMessage = "Purchase Status is required.")]
        public string PurchaseOrder_Status { get; set; }


        [StringLength(300, MinimumLength = 2, ErrorMessage = "Purchase Status Remarks must be more than 2 characters and maximum of 300 characters.")]
        public string? PurchaseOrder_StatusRemarks { get; set; }


        [StringLength(50, MinimumLength = 2, ErrorMessage = "Purchase Type must be more than 2 characters and maximum of 50 characters.")]
        [Required(ErrorMessage = "Purchase Type is required.")]
        public string PurchaseOrder_Type { get; set; }


        public DateTime PurchaseOrder_CreatedAt { get; set; }



        [ForeignKey("Supplier")]
        public int? SuppliersId { get; set; }

        [ForeignKey("Requisition")]
        public int? RequisitionId { get; set; }

        public virtual Supplier? Supplier { get; set; }

        public virtual Requisition? Requisition { get; set; }
        public virtual ICollection<PurchaseItem>? PurchaseItems { get; set; }
        public virtual ICollection<PurchaseService>? PurchaseServices { get; set; }
        
    }
}
