using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalManagement.Models
{
    public class ApplicantForm
    {
        [Key]
        [ForeignKey("Applicants")]
        public int ApplicationId { get; set; }


        public DateTime Application_CreatedAt { get; set; } = DateTime.Now;


        public string Application_Status { get; set; }


        public int Application_RoomNumber { get; set; }


        public int Application_UnitNumber { get; set; }



        public virtual Applicants Applicants { get; set; }
    }
}
