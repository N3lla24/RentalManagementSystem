using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace RentalManagement.Models
{
    public class Tenant
    {
        [Key]
        public int TenantId { get; set; }

        [StringLength(50, MinimumLength = 8)]
        public string Tenant_FirstName { get; set; }

        [StringLength(50, MinimumLength = 8)]
        public string? Tenant_MiddleName { get; set; }

        [StringLength(50, MinimumLength = 8)]
        public string Tenant_LastName { get; set; }


        [StringLength(50, MinimumLength = 8, ErrorMessage = "Username characters must be <br/> more than 5 and maximum of 50 characters.")]
        public string Tenant_UserName { get; set; }


        [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*\.[a-z]{2,}$", ErrorMessage = "Please enter a valid email address")]
        [Required(ErrorMessage = "Tenant Email Address is required.")]
        public string Tenant_Email { get; set; }


        [RegularExpression(@"^09\d{9}$", ErrorMessage = "Please enter Philippine phone number format")]
        [Required(ErrorMessage = "Tenant Phone Number is required.")]
        public string Tenant_PhoneNumber { get; set; }


        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&/,.-])[A-Za-z\d@$!%*?&/,.-]{8,30}$", ErrorMessage = "Password must have: <br/> * 8 minimum char long <br/> * Atleast 1 Uppercase Character <br/> * Atleast 1 Special Character <br/> * Atleast 1 Numerical Character")]
        [Required(ErrorMessage = "Password is required.")]
        public string Tenant_Password { get; set; }


        public int Tenant_RoomNumber { get; set; }


        public int Tenant_UnitNumber { get; set; }


         
        public DateTime Tenant_CreatedAt { get; set; }



        public DateTime? Tenant_UpdatedAt { get; set; }

    }
}
