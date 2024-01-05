using System.ComponentModel.DataAnnotations;

namespace RentalManagement.Models
{
    public class Applicants
    {
        [Key]
        public int ApplicationId { get; set; }


        [RegularExpression(@"^[\w'\-,.][^0-9_!¡?÷?¿/\\+=@#$%ˆ&*(){}|~<>;:[\]]{2,}$", ErrorMessage = "Input Valid Name")]
        [StringLength(100, MinimumLength = 1, ErrorMessage ="Input Valid Name")]
        [Required(ErrorMessage = "First Name is required.")]
        public string Applicants_FirstName { get; set; }


        [RegularExpression(@"^[\w'\-,.][^0-9_!¡?÷?¿/\\+=@#$%ˆ&*(){}|~<>;:[\]]{2,}$", ErrorMessage = "Input Valid Name")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Input Valid Name")]
        public string? Applicants_MiddleName { get; set; }


        [RegularExpression(@"^[\w'\-,.][^0-9_!¡?÷?¿/\\+=@#$%ˆ&*(){}|~<>;:[\]]{2,}$", ErrorMessage = "Input Valid Name")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Input Valid Name")]
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
        
        
        [Required(ErrorMessage = "Room Number is required.")]
        public int Application_RoomNumber { get; set; }

        [Required(ErrorMessage = "Unit Number is required.")]
        public int Application_UnitNumber { get; set; }


        [Required(ErrorMessage = "Application Status is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Username characters must be more than 2 and maximum of 100 characters.")]
        public string Application_Status { get; set; }

        



        public DateTime Applicant_CreatedAt { get; set; }



        public DateTime? Applicant_UpdatedAt { get; set; }
    }
}
