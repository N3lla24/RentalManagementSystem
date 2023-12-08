using System.ComponentModel.DataAnnotations;

namespace RentalManagement.Models
{
    public class Applicants
    {
        [Key]
        public int ApplicationId { get; set; }
        [Required(ErrorMessage = "First Name is required.")]
        public string Applicants_FirstName { get; set; }
        public string? Applicants_MiddleName { get; set; }
        [Required(ErrorMessage = "Last Name is required.")]
        public string Applicants_LastName { get; set; }
        [Required(ErrorMessage = "Email Address is required.")]
        public string Applicants_Email { get; set; }
        [Required(ErrorMessage = "Phone Number is required.")]
        public string Applicants_PhoneNumber { get; set; }
        [Required(ErrorMessage = "Home Address is required.")]
        public string Applicants_Address { get; set; }
        [DataType(DataType.Date)]
        public DateTime Applicant_CreatedAt { get; set; }
        [DataType(DataType.Date)]
        public DateTime? Applicant_UpdatedAt { get; set; }
    }
}
