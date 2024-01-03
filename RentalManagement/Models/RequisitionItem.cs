using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalManagement.Models
{
    public class RequisitionItem
    {
        [Key]
        public int Req_Item_ID { get; set; }


        [StringLength(300, MinimumLength = 2, ErrorMessage = "Username characters must be more than 2 and maximum of 300 characters.")]
        [Required(ErrorMessage = "Name is required.")]
        public string Req_Item_Name { get; set; }


        [Required(ErrorMessage = "Item Quantity is required.")]
        public int Req_Item_Quantity { get; set; }


        [StringLength(100, MinimumLength = 2, ErrorMessage = "Requisition Description must be more than 2 characters")]
        [Required(ErrorMessage = "Measurement Unit is required.")]
        public string Req_Item_Units { get; set; }


        [StringLength(300, MinimumLength = 10, ErrorMessage = "Requisition Description must be more than 10 characters & maximum of 300 characters.")]
        public string Req_Item_Remarks { get; set; }


        [DataType(DataType.Date)]
        public DateTime Req_Item_DueDate { get; set; }


        [ForeignKey("Requisition")]
        public int RequisitionId { get; set; }
        public virtual Requisition? Requisition { get; set; }

    }
}
