using System.ComponentModel.DataAnnotations;

namespace RentalManagement.Models
{
    public class TenantDisplay
    {
        [Key]
        public int TenantId { get; set; }
        public string Tenant_FirstName { get; set; }
        public string Tenant_LastName { get; set; } 
    }
}
