using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalManagement.Models
{
    public class PurchaseOrder
    {
        [Key]
        public int PurchaseOrderId { get; set; }

        [Required(ErrorMessage = "Purchase Status is required.")]
        public string PurchaseOrder_Status { get; set; }

        [Required(ErrorMessage = "Purchase Type is required.")]
        public string PurchaseOrder_Type { get; set; }


        public DateTime PurchaseOrder_CreatedAt { get; set; }



        [ForeignKey("Suppliers")]
        public int SuppliersId { get; set; }


        public virtual Supplier? Supplier { get; set; }


        [ForeignKey("Requsition")]
        public int RequistitionId { get; set; }


        public virtual Requisition? Requisition { get; set; }
    }
}
