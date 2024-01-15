using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalManagement.Models
{
    public class RequisitionItem
    {
        [Key]
        public int Req_Item_ID { get; set; }


        [RegularExpression(@"^[a-zA-Z0-9\s&',.-]+$", ErrorMessage = "Name must only contain: Alphabet letters, Numeric Numbers, (& ' , . -) Symbols")]
        [StringLength(300, MinimumLength = 2, ErrorMessage = "Username characters must be more than 2 and maximum of 300 characters.")]
        public string? Req_Item_Name { get; set; }


        public int? Req_Item_Quantity { get; set; }


        [StringLength(100, MinimumLength = 2, ErrorMessage = "Requisition Description must be more than 2 characters")]
        public string? Req_Item_Units { get; set; }


        [ForeignKey("Requisition")]
        public int? RequisitionId { get; set; }

        [ForeignKey("Inventory")]
        public int? InventoryId { get; set; }


        public virtual Requisition? Requisition { get; set; }
        public virtual Inventory? Inventory { get; set; }

    }
    
}
