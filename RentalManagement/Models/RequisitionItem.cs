using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalManagement.Models
{
    public class RequisitionItem
    {
        [Key]
        [ForeignKey("Requisition")]
        public int RequistitionId { get; set; }
        public string Requistition_Type{ get; set; }
        public string Requistition_Item { get; set; }
        public int Requistition_Quantity { get; set; }
        public string Requistition_Units { get; set; }


        public virtual Requisition Requisition { get; set; }
    }
}
