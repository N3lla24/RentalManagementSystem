using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace RentalManagement.Models
{
    public class Tenant
    {
        [Key]
        public int TenantId { get; set; }


        [RegularExpression(@"^[\w'\-,.][^0-9_!¡?÷?¿/\\+=@#$%ˆ&*(){}|~<>;:[\]]{2,}$", ErrorMessage = "Input Valid Name")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Input Valid Name")]
        [Required(ErrorMessage = "First Name is required.")]
        public string Tenant_FirstName { get; set; }


        [RegularExpression(@"^[\w'\-,.][^0-9_!¡?÷?¿/\\+=@#$%ˆ&*(){}|~<>;:[\]]{2,}$", ErrorMessage = "Input Valid Name")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Input Valid Name")]
        public string? Tenant_MiddleName { get; set; }


        [RegularExpression(@"^[\w'\-,.][^0-9_!¡?÷?¿/\\+=@#$%ˆ&*(){}|~<>;:[\]]{2,}$", ErrorMessage = "Input Valid Name")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Input Valid Name")]
        [Required(ErrorMessage = "Last Name is required.")]
        public string Tenant_LastName { get; set; }

        [Required(ErrorMessage = "User Name is required.")]
        [RegularExpression(@"^[a-zA-Z0-9\s&',.-]+$", ErrorMessage = "Username must only contain: Alphabet letters, Numeric Numbers, (& ' , . - ) Symbols")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Username characters must be more than 5 and maximum of 50 characters.")]
        public string Tenant_UserName { get; set; }


        
        [Required(ErrorMessage = "Tenant Email Address is required.")]
        [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*\.[a-z]{2,}$", ErrorMessage = "Please enter a valid email address")]
        public string Tenant_Email { get; set; }


        
        [Required(ErrorMessage = "Tenant Phone Number is required.")]
        [RegularExpression(@"^09\d{9}$", ErrorMessage = "Please enter Philippine phone number format")]
        public string Tenant_PhoneNumber { get; set; }



        [Required(ErrorMessage = "Password is required.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&/,.-])[A-Za-z\d@$!%*?&/,.-]{8,30}$", ErrorMessage = "Password must have: * 8 minimum char long * Atleast 1 Uppercase Character * Atleast 1 Special Character * Atleast 1 Numerical Character")]
        public string Tenant_Password { get; set; }

        public int Tenant_RoomNumber { get; set; }


        public int Tenant_UnitNumber { get; set; }


         
        public DateTime Tenant_CreatedAt { get; set; }



        public DateTime? Tenant_UpdatedAt { get; set; }

    }
}
