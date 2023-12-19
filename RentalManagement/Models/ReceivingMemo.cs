using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalManagement.Models
{
    public class ReceivingMemo
    {
        [Key]
        public int RMId { get; set; }


        public DateTime RM_Date { get; set; }


        [StringLength(300, MinimumLength = 10, ErrorMessage = "Review Remarks must be more than 10 characters & maximum of 300 characters.")]
        public string RM_Remarks { get; set; }

        [Required(ErrorMessage = "Receiving Memo Status is required.")]
        public string RM_Status { get; set; }



        [ForeignKey("PurchaseOrder")]
        public int PurchaseId { get; set; }


        public virtual PurchaseOrder? PurchaseOrder { get; set; }
    }
}
