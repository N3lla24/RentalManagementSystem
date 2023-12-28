using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalManagement.Models
{
    public class FAQ
    {
        [Key]
        public int FAQId { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*\.[a-z]{2,}$")]
        [Required(ErrorMessage = "Email Address is required.")]
        public string FAQ_Email { get; set; }


        [StringLength(300, MinimumLength = 10, ErrorMessage = "Query must be more than 10 characters & maximum of 300 characters.")]
        public string FAQ_Content { get; set; }


        public DateTime FAQ_CreatedAt{ get; set; }



        [ForeignKey("Applicants")]
        public int ApplicationId { get; set; }

        public virtual Applicants? Applicants { get; set; }
    }
}
