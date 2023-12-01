using System.ComponentModel.DataAnnotations;

namespace RentalManagement.Models
{
    public class Applicants
    {
        [Key]
        public int ApplicationId { get; set; }
        public string Applicants_Name { get; set; }
        public string Applicants_Email { get; set; }
        public string Applicants_PhoneNumber { get; set; }
        public string Applicants_Address { get; set; }
        [DataType(DataType.Date)]
        public DateTime Applicant_CreatedAt { get; set; }
        [DataType(DataType.Date)]
        public DateTime Applicant_UpdatedAt { get; set; }
    }
}
