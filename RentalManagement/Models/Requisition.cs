using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalManagement.Models
{
    public class Requisition
    {
        [Key]
        public int RequistitionId { get; set; }
        public string Requistition_Remarks { get; set; }
        [DataType(DataType.Date)]
        public DateTime Requistition_Date { get; set; }
        public string Requistition_Status { get; set; }


        [ForeignKey("Tenants")]
        public int TenantId { get; set; }

        public virtual Tenant Tenant { get; set; }

    }
}
