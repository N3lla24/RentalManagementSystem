using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalManagement.Models
{
    public class PurchaseService
    {
        [Key]
        public int PurchaseServ_Id { get; set; }


        [RegularExpression(@"^[a-zA-Z0-9][a-zA-Z0-9_-]*[a-zA-Z0-9]$", ErrorMessage = "Username must only contain: Alphabet letters, Numeric Numbers, _ and - Symbols")]
        [StringLength(300, MinimumLength = 2, ErrorMessage = "Username characters must be more than 2 and maximum of 300 characters.")]
        [Required(ErrorMessage = "Purchase Item Name is required.")]
        public string PurchaseServ_Name { get; set; }



        [ForeignKey("PurchaseOrder")]
        public int PurchaseOrderId { get; set; }


        public virtual PurchaseOrder PurchaseOrder { get; set; }
    }
}
