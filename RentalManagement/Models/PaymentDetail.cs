﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalManagement.Models
{
    public class PaymentDetail
    {
        [Key]
        public int Pay_ID { get; set; }


        [DataType(DataType.Date)]
        public DateTime Pay_DueDate { get; set; }



        [Required(ErrorMessage = "Complete Payment Details")]
        public decimal Pay_RentPrice { get; set; }


        [Required(ErrorMessage = "Complete Payment Details")]
        public decimal Pay_UtilityFee { get; set; }


        [Required(ErrorMessage = "Complete Payment Details")]
        public decimal Pay_GarbageFee { get; set; }


        [Required(ErrorMessage = "Complete Payment Details")]
        public decimal Pay_AirconFee { get; set; }


        [Required(ErrorMessage = "Complete Payment Details")]
        public decimal Pay_InternetFee { get; set; }


        [Required(ErrorMessage = "Complete Payment Details")]
        public decimal Pay_RefrigeratorFee { get; set; }


        [Required(ErrorMessage = "Complete Payment Details")]
        public decimal Pay_WashingFee { get; set; }



        public DateTime Pay_CreatedAt { get; set; }

        public DateTime Pay_UpdatedAt { get; set; }


        [ForeignKey("Tenant")]
        public int? TenantId { get; set; }

        public virtual Tenant? Tenant { get; set; }
    }
}
