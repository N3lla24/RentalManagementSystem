using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalManagement.Models
{
    public class ApplicantForm
    {
        [Key]
        public int ApplicationFormId { get; set; }
        public DateTime Application_Date { get; set; }
        public string Application_Status { get; set; }

        [ForeignKey("Applicants")]
        public int ApplicationId { get; set; }

        public virtual Applicants Applicants { get; set; }
    }
}
