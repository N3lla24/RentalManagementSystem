using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalManagement.Models
{
    public class Feedback
    {
        [Key]
        public int FeedbackId { get; set; }
        public string Feedback_Email { get; set; }
        public string Feedback_Content { get; set; }
        [DataType(DataType.Date)]
        public DateTime Feedback_CreatedAt { get; set; }
        [DataType(DataType.Date)]
        public DateTime Feedback_UpdatedAt { get; set; }

        [ForeignKey("Tenants")]
        public int TenantId { get; set; }

        public virtual Tenant Tenant { get; set; }
    }
}
