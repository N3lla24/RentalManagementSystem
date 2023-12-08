using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalManagement.Models
{
    public class FAQ
    {
        [Key]
        public int FAQId { get; set; }
        [Required(ErrorMessage = "Email Address is required.")]
        public string FAQ_Email { get; set; }
        [StringLength(300, MinimumLength = 10, ErrorMessage = "Query must be more than 10 characters & maximum of 300 characters.")]
        public string FAQ_Content { get; set; }
        [DataType(DataType.Date)]
        public DateTime FAQ_Date{ get; set; }



        [ForeignKey("Applicants")]
        public int ApplicationId { get; set; }

        public virtual Applicants Applicants { get; set; }
    }
}
