using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalManagement.Models
{
    public class Feedback
    {
        [Key]
        public int FeedbackId { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*\.[a-z]{2,}$")]
        [Required(ErrorMessage = "Email Address is required.")]
        public string Feedback_Email { get; set; }


        [StringLength(300, MinimumLength = 5, ErrorMessage = "Feedback Comment must be more than 5 characters & maximum of 300 characters.")]
        public string? Feedback_Content { get; set; }


        public DateTime? Feedback_CreatedAt { get; set; }


        public DateTime? Feedback_UpdatedAt { get; set; }



        [ForeignKey("Tenant")]
        public int? TenantId { get; set; }

        public virtual Tenant? Tenant { get; set; }
    }
}
