using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalManagement.Models
{
    public class Feedback
    {
        [Key]
        public int FeedbackId { get; set; }
        [Required(ErrorMessage = "Email Address is required.")]
        public string Feedback_Email { get; set; }
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Feedback Comment must be more than 10 characters & maximum of 100 characters.")]
        public string? Feedback_Content { get; set; }
        public DateTime? Feedback_CreatedAt { get; set; }
        public DateTime? Feedback_UpdatedAt { get; set; }

        [ForeignKey("Tenants")]
        public int TenantId { get; set; }

        public virtual Tenant Tenant { get; set; }
    }
}
