using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalManagement.Models
{
    public class Requisition
    {
        [Key]
        public int RequisitionId { get; set; }


        public string? Requisition_Type { get; set; }

        public string? Requisition_Remarks { get; set; }
        [DataType(DataType.Date)]
        public DateTime Requisition_CreatedAt { get; set; }


        [DataType(DataType.Date)]
        public DateTime Requisition_DueDate { get; set; }


        public string? Requisition_Status { get; set; }

        public string? Requisition_Status_Remarks { get; set; }



        [ForeignKey("Tenant")]
        public int TenantId { get; set; }

        public virtual Tenant? Tenant { get; set; }
        public virtual IEnumerable<RequisitionItem>? RequisitionItems { get; set; }

        public virtual ICollection<RequisitionService>? RequisitionServices { get; set; }

    }
}
