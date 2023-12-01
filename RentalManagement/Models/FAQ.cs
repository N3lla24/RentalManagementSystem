using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalManagement.Models
{
    public class FAQ
    {
        [Key]
        public int FAQId { get; set; }
        public string FAQ_Email { get; set; }
        public string FAQ_Content { get; set; }
        [DataType(DataType.Date)]
        public DateTime FAQ_Date{ get; set; }



        [ForeignKey("Applicants")]
        public int ApplicationId { get; set; }

        public virtual Applicants Applicants { get; set; }
    }
}
