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

        [Required(ErrorMessage = "Room Status is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Room Status must be more than 2 characters and maximum of 100 characters.")]
        public string? Room_Status { get; set; }

        public int Room_Capacity { get; set; }

        public decimal Room_Price { get; set; }

        public DateTime Room_CreatedAt { get; set; }

        public DateTime? Room_UpdatedAt { get; set; }


        [ForeignKey("Tenant")]
        public int? TenantId { get; set; }

        public virtual Tenant? Tenant { get; set; }

        [ForeignKey("PaymentDetail")]
        public int? Pay_ID { get; set; }

        public virtual PaymentDetail? PaymentDetail { get; set; }

        [ForeignKey("Unit")]
        public int? UnitId { get; set; }

        public virtual Unit? Unit { get; set; }

    }
}
