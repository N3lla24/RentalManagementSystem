using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalManagement.Models
{
    public class RentPayment
    {
        [Key]
        public int RentPaymentId { get; set; }
        [Required(ErrorMessage = "Payment Method is required.")]
        public string RentPayment_Method { get; set; }
        [Required(ErrorMessage = "Payment Amount is required.")]
        public decimal RentPayment_Amount { get; set; }
        [DataType(DataType.Date)]
        public DateTime RentPayment_Date { get; set; }
        public string RentPayment_Status { get; set; }


        [ForeignKey("Tenants")]
        public int TenantId { get; set; }

        public virtual Tenant Tenant { get; set; }

    }
}
