using Microsoft.EntityFrameworkCore;
using RentalManagement.Data;

namespace RentalManagement.Models
{
    public static class SeedTenant
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RentalManagementContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RentalManagementContext>>()))
            {
                // Look for any Tenants.
                if (context.Tenant.Any())
                {
                    return;   // DB has been seeded
                }
                context.Tenant.AddRange(
                    new Tenant
                    {
                        Tenant_Name = "Ronel N. Delig",
                        Tenant_Email = "ronel@gmail.com",
                        Tenant_PhoneNumber = "09392719001",
                        Tenant_RoomNumber = 101,
                        Tenant_UnitNumber = 02,
                        Tenant_RentTot = Convert.ToDecimal(121000.00),
                        Tenant_RentPaid = Convert.ToDecimal(0.00),
                        Tenant_CreatedAt = DateTime.Today,
                        Tenant_UpdatedAt = DateTime.Today,
                    },
                    new Tenant
                    {
                        Tenant_Name = "Omar Yusof Pila",
                        Tenant_Email = "omar@gmail.com",
                        Tenant_PhoneNumber = "09724926591",
                        Tenant_RoomNumber = 102,
                        Tenant_UnitNumber = 03,
                        Tenant_RentTot = Convert.ToDecimal(151000.00),
                        Tenant_RentPaid = Convert.ToDecimal(1000.00),
                        Tenant_CreatedAt = DateTime.Today,
                        Tenant_UpdatedAt = DateTime.Today,
                    },
                    new Tenant
                    {
                        Tenant_Name = "Jayla Monares",
                        Tenant_Email = "jayla@gmail.com",
                        Tenant_PhoneNumber = "09328502810",
                        Tenant_RoomNumber = 103,
                        Tenant_UnitNumber = 04,
                        Tenant_RentTot = Convert.ToDecimal(101000.00),
                        Tenant_RentPaid = Convert.ToDecimal(2000.00),
                        Tenant_CreatedAt = DateTime.Today,
                        Tenant_UpdatedAt = DateTime.Today,
                    },
                    new Tenant
                    {
                        Tenant_Name = "Yancy Salas",
                        Tenant_Email = "yancy@gmail.com",
                        Tenant_PhoneNumber = "09475291721",
                        Tenant_RoomNumber = 104,
                        Tenant_UnitNumber = 06,
                        Tenant_RentTot = Convert.ToDecimal(191000.00),
                        Tenant_RentPaid = Convert.ToDecimal(1500.00),
                        Tenant_CreatedAt = DateTime.Today,
                        Tenant_UpdatedAt = DateTime.Today,
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
