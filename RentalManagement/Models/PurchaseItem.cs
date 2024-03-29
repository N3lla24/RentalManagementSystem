using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalManagement.Models
{
    public class PurchaseItem
    {
        [Key]
        public int PurchaseItem_Id { get; set; }


        [RegularExpression(@"^[a-zA-Z0-9\s&',.-]+$", ErrorMessage = "Name must only contain: Alphabet letters, Numeric Numbers, (& ' , . -) Symbols")]
        [StringLength(300, MinimumLength = 2, ErrorMessage = "Username characters must be more than 2 and maximum of 300 characters.")]
        public string? PurchaseItem_Name { get; set; }


        public int? PurchaseItem_Quantity { get; set; }


        [StringLength(100, MinimumLength = 2, ErrorMessage = "Requisition Description must be more than 2 characters")]
        public string? PurchaseItem_Unit { get; set; }



        [ForeignKey("PurchaseOrder")]
        public int? PurchaseOrderId { get; set; }


        public virtual PurchaseOrder? PurchaseOrder { get; set; }
        
    }
}
