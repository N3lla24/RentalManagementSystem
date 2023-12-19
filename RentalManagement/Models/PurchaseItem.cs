using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalManagement.Models
{
    public class PurchaseItem
    {
        [Key]
        [ForeignKey("PurchaseOrder")]
        public int PurchaseId { get; set; }

        [Required(ErrorMessage = "Purchase Type is required.")]
        public string Purchase_Type { get; set; }


        [Required(ErrorMessage = "Purchase Item Name is required.")]
        public string Purchase_ItemName { get; set; }


        [Required(ErrorMessage = "Purchase Item Quantity is required.")]
        public int Purchase_Quantity { get; set; }


        [Required(ErrorMessage = "Purchase Item Units is required.")]
        public string Purchase_Units { get; set; }



        public virtual PurchaseOrder PurchaseOrder { get; set; }
    }
}
