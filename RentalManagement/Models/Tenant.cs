using System.ComponentModel.DataAnnotations;


namespace RentalManagement.Models
{
    public class Tenant
    {
        [Key]
        public int TenantId { get; set; }
        public string Tenant_Name { get; set; }
        public string Tenant_Email { get; set; }
        public string Tenant_PhoneNumber { get; set; }
        public int Tenant_RoomNumber { get; set; }
        public int Tenant_UnitNumber { get; set; }
        public decimal Tenant_RentTot { get; set; }
        public decimal Tenant_RentPaid { get; set; }

        [DataType(DataType.Date)]
        public DateTime Tenant_CreatedAt { get; set; }
        [DataType(DataType.Date)]
        public DateTime Tenant_UpdatedAt { get; set; }
    }
}
