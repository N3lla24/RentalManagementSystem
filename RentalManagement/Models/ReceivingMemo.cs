using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalManagement.Models
{
    public class ReceivingMemo
    {
        [Key]
        public int RMId { get; set; }
        [DataType(DataType.Date)]
        public DateTime RM_Date { get; set; }
        public string RM_Remarks { get; set; }
        public string RM_Status { get; set; }


        [ForeignKey("PurchaseOrder")]
        public int PurchaseId { get; set; }

        public virtual PurchaseOrder PurchaseOrder { get; set; }
    }
}
