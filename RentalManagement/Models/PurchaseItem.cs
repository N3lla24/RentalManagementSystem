using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalManagement.Models
{
    public class PurchaseItem
    {
        [Key]
        [ForeignKey("PurchaseOrder")]
        public int PurchaseId { get; set; }
        public string Purchase_Item { get; set; }
        public decimal Purchase_Quantity { get; set; }
        public string Purchase_Units { get; set; }


        public virtual PurchaseOrder PurchaseOrder { get; set; }
    }
}
