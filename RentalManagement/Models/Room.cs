using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;


namespace RentalManagement.Models
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }

        public int Room_Num { get; set; }


        [StringLength(100, MinimumLength = 2, ErrorMessage = "Username characters must be more than 2 and maximum of 100 characters.")]
        public string? Room_Status { get; set; }

        public int Room_Capacity { get; set; }

        public decimal Room_Price { get; set; }




        [ForeignKey("Tenants")]
        public int TenantId { get; set; }

        public virtual Tenant? Tenant { get; set; }

        [ForeignKey("PaymentDetail")]
        public int Pay_ID { get; set; }

        public virtual PaymentDetail? PaymentDetail { get; set; }
    }
}
