using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace RentalManagement.Models
{
    public class Invoice
    {
        [Key]
        public int Inv_ID { get; set; }

        public DateTime Inv_CreatedAt { get; set; } = DateTime.Now;

        [StringLength(200, MinimumLength = 2, ErrorMessage = "Username characters must be more than 2 and maximum of 200 characters.")]
        [Required(ErrorMessage = "Payment Method is required.")]
        public string Inv_Method { get; set; }

        [StringLength(200, MinimumLength = 2, ErrorMessage = "Username characters must be more than 2 and maximum of 200 characters.")]
        [Required(ErrorMessage = "Payment Status is required.")]
        public string Inv_Status { get; set; }

        [Required(ErrorMessage = "Payment Status is required.")]
        public byte[] Inv_ProofPayment { get; set; }


        [ForeignKey("Tenants")]
        public int TenantId { get; set; }

        public virtual Tenant? Tenant { get; set; }


        [ForeignKey("PaymentDetail")]
        public int Pay_ID { get; set; }

        public virtual PaymentDetail? PaymentDetail { get; set; }
    }
}
