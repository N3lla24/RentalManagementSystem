using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;


namespace RentalManagement.Models
{
    public class Unit
    {
        [Key]
        public int UnitId { get; set; }

        public int Unit_Num { get; set; }

        [Required(ErrorMessage = "Unit Status is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Unit Status characters must be more than 2 and maximum of 100 characters.")]
        public string? Unit_Status { get; set; }

        public DateTime Unit_CreatedAt { get; set; }

        public DateTime? Unit_UpdatedAt { get; set; }
    }
}
