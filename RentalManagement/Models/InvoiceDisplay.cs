using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalManagement.Models
{
    public class InvoiceDisplay
    {
        [Key]
        public int Inv_ID { get; set; }
        public DateTime Inv_CreatedAt { get; set; }
        public string Inv_Method { get; set; }
        public string Inv_Status { get; set; }
        public byte[] Inv_ProofPayment { get; set; }

        [ForeignKey("Tenant")]
        public int? TenantId { get; set; }

        [ForeignKey("PaymentDetails")]
        public int? Pay_ID { get; set; }
    }
}
