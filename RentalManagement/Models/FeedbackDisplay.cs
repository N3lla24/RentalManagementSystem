using System.ComponentModel.DataAnnotations;

namespace RentalManagement.Models
{
    public class FeedbackDisplay
    {
        [Key]
        public int FeedbackId { get; set; }
        public string Feedback_Email { get; set; }
        public string Feedback_Content { get; set; }
    }
}
