using System.ComponentModel.DataAnnotations;


namespace RentalManagement.Models
{
    public class Tenant
    {
        [Key]
        public int TenantId { get; set; }


        [Required(ErrorMessage = "First Name is required.")]
        public string Tenant_FirstName { get; set; }


        public string? Tenant_MiddleName { get; set; }


        [Required(ErrorMessage = "Last Name is required.")]
        public string Tenant_LastName { get; set; }


        [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*\.[a-z]{2,}$")]
        [Required(ErrorMessage = "Tenant Email Address is required.")]
        public string Tenant_Email { get; set; }


        [RegularExpression(@"^09\d{9}$")]
        [Required(ErrorMessage = "Tenant Phone Number is required.")]
        public string Tenant_PhoneNumber { get; set; }


        [Required(ErrorMessage = "Tenant Room Number is required.")]
        public int Tenant_RoomNumber { get; set; }


        [Required(ErrorMessage = "Tenant Unit Number is required.")]
        public int Tenant_UnitNumber { get; set; }


        public decimal? Tenant_TotPay { get; set; }



        public DateTime Tenant_CreatedAt { get; set; } = DateTime.Now;


        [DataType(DataType.Date)]
        public DateTime? Tenant_UpdatedAt { get; set; }
    }
}
