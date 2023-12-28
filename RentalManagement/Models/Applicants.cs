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


        [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*\.[a-z]{2,}$")]
        [Required(ErrorMessage = "Email Address is required.")]
        public string Applicants_Email { get; set; }


        [RegularExpression(@"^09\d{9}$")]
        [Required(ErrorMessage = "Phone Number is required.")]
        public string Applicants_PhoneNumber { get; set; }


        [Required(ErrorMessage = "Home Address is required.")]
        public string Applicants_Address { get; set; }



        public DateTime Applicant_CreatedAt { get; set; }



        public DateTime? Applicant_UpdatedAt { get; set; }
    }
}
