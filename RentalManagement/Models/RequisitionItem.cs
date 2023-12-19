using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalManagement.Models
{
    public class RequisitionItem
    {
        [Key]
        public int Req_Item_ID { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Req_Item_Name { get; set; }


        [Required(ErrorMessage = "Item Quantity is required.")]
        public int Req_Item_Quantity { get; set; }


        [Required(ErrorMessage = "Measurement Unit is required.")]
        public string Req_Item_Units { get; set; }


        [ForeignKey("Requisition")]
        public int RequisitionId { get; set; }
        public virtual Requisition? Requisition { get; set; }

    }
}
