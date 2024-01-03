using System.ComponentModel.DataAnnotations;

namespace RentalManagement.Models
{
    public class Applicants
    {
        [Key]
        public int ApplicationId { get; set; }

        [StringLength(100, MinimumLength = 8)]
        [Required(ErrorMessage = "First Name is required.")]
        public string Applicants_FirstName { get; set; }

        [StringLength(100, MinimumLength = 8)]
        public string? Applicants_MiddleName { get; set; }

        [StringLength(100, MinimumLength = 8)]
        [Required(ErrorMessage = "Last Name is required.")]
        public string Applicants_LastName { get; set; }


        [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*\.[a-z]{2,}$", ErrorMessage = "Please enter a valid email address")]
        [Required(ErrorMessage = "Email Address is required.")]
        public string Applicants_Email { get; set; }


        [RegularExpression(@"^09\d{9}$", ErrorMessage = "Password must have: * 8 minimum char long * Atleast 1 Uppercase Character * Atleast 1 Special Character * Atleast 1 Numerical Character")]
        [Required(ErrorMessage = "Phone Number is required.")]
        public string Applicants_PhoneNumber { get; set; }


        [Required(ErrorMessage = "Home Address is required.")]
        public string Applicants_Address { get; set; }



        public DateTime Applicant_CreatedAt { get; set; }



        public DateTime? Applicant_UpdatedAt { get; set; }
    }
}
