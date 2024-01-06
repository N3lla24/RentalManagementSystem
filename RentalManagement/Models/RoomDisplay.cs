using System.ComponentModel.DataAnnotations;

namespace RentalManagement.Models
{
    public class RoomDisplay
    {
        [Key]
        public int RoomId { get; set; }
        public int Room_Num { get; set; }
        public string Room_Status { get; set; }
        public int Room_Capacity { get; set; }
    }
}
