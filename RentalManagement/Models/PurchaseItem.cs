using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalManagement.Models
{
    public class PurchaseItem
    {
        [Key]
        public int PurchaseItem_Id { get; set; }

        [StringLength(300, MinimumLength = 2, ErrorMessage = "Username characters must be more than 2 and maximum of 300 characters.")]
        [Required(ErrorMessage = "Purchase Item Name is required.")]
        public string PurchaseItem_Name { get; set; }


        [Required(ErrorMessage = "Purchase Item Quantity is required.")]
        public int PurchaseItem_Quantity { get; set; }

        [StringLength(100, MinimumLength = 2, ErrorMessage = "Requisition Description must be more than 2 characters")]
        [Required(ErrorMessage = "Purchase Item Unit is required.")]
        public string PurchaseItem_Unit { get; set; }



        [ForeignKey("PurchaseOrder")]
        public int PurchaseOrderId { get; set; }


        public virtual PurchaseOrder PurchaseOrder { get; set; }
    }
}
