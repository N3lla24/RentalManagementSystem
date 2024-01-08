using System.ComponentModel.DataAnnotations;

namespace RentalManagement.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }


        [Required(ErrorMessage = "User Name is required.")]
        [RegularExpression(@"^[a-zA-Z0-9\s&',.-]+$", ErrorMessage = "Name must only contain: Alphabet letters, Numeric Numbers, (& ' , . -) Symbols")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Username characters must be more than 8 and maximum of 50 characters.")]
        public string Admin_UserName { get; set; }


        [Required(ErrorMessage = "Password is required.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&/,.-])[A-Za-z\d@$!%*?&/,.-]{8,30}$", ErrorMessage = "Password must have: * 8 minimum char long * Atleast 1 Uppercase Character * Atleast 1 Special Character * Atleast 1 Numerical Character")]
        public string Admin_Password { get; set; }


        [Required(ErrorMessage = "Email Address is required.")]
        [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*\.[a-z]{2,}$", ErrorMessage = "Please enter a valid email address")]
        public string Admin_Email { get; set; }



        [Required(ErrorMessage = "Phone Number is required.")]
        [RegularExpression(@"^09\d{9}$", ErrorMessage = "Please enter Philippine phone number format")]
        public string Admin_PhoneNumber { get; set; }

    }
}
