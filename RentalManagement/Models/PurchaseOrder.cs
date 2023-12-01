using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalManagement.Models
{
    public class PurchaseOrder
    {
        [Key]
        public int PurchaseOrderId { get; set; }
        public string PurchaseOrder_Status { get; set; }
        [DataType(DataType.Date)]
        public DateTime PurchaseOrder_Date{ get; set; }



        [ForeignKey("Suppliers")]
        public int SuppliersId { get; set; }

        public virtual Supplier Supplier { get; set; }

        [ForeignKey("Requsition")]
        public int RequistitionId { get; set; }

        public virtual Requisition Requisition { get; set; }
    }
}
