using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalManagement.Models
{
    public class PurchaseService
    {
        [Key]
        public int PurchaseServ_Id { get; set; }


        [Required(ErrorMessage = "Purchase Item Name is required.")]
        public string PurchaseServ_Name { get; set; }



        [ForeignKey("PurchaseOrder")]
        public int PurchaseOrderId { get; set; }


        public virtual PurchaseOrder PurchaseOrder { get; set; }
    }
}
