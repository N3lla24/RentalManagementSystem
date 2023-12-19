using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalManagement.Models
{
    public class PaymentDetail
    {
        [Key]
        public int Pay_ID { get; set; }


        [DataType(DataType.Date)]
        public DateTime Pay_DueDate { get; set; }


        [Required(ErrorMessage = "Payment Method is required.")]
        public string Pay_Method { get; set; }


        [Required(ErrorMessage = "Payment Status is required.")]
        public string Pay_Status { get; set; }


        [Required(ErrorMessage = "Complete Payment Details")]
        public decimal Pay_RentPrice { get; set; }



        [Required(ErrorMessage = "Complete Payment Details")]
        public decimal Pay_TapwaterFee { get; set; }



        [Required(ErrorMessage = "Complete Payment Details")]
        public decimal Pay_ElectricityFee { get; set; }



        [Required(ErrorMessage = "Complete Payment Details")]
        public decimal Pay_WaterFee { get; set; }



        [Required(ErrorMessage = "Complete Payment Details")]
        public decimal Pay_GasFee { get; set; }


        [Required(ErrorMessage = "Complete Payment Details")]
        public decimal Pay_GarbageFee { get; set; }


        [Required(ErrorMessage = "Complete Payment Details")]
        public decimal Pay_AirconFee { get; set; }


        [Required(ErrorMessage = "Complete Payment Details")]
        public decimal Pay_InternetFee { get; set; }



        public DateTime Pay_CreatedAt { get; set; } = DateTime.Now;


        [ForeignKey("Tenants")]
        public int TenantId { get; set; }


        public virtual Tenant? Tenant { get; set; }

    }
}
