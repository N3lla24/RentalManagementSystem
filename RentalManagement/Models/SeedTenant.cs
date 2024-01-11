using Microsoft.EntityFrameworkCore;
using RentalManagement.Data;
using RentalManagement.Services;

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
                        Tenant_FirstName = "Ronel",
                        Tenant_MiddleName = "Napoles",
                        Tenant_LastName = "Delig",
                        Tenant_UserName = "nella",
                        Tenant_Email = "ronel@gmail.com",
                        Tenant_PhoneNumber = "09876543210",
                        Tenant_Password = Hashing.HashPass("123/Pass"),
                        Tenant_RoomNumber = 101,
                        Tenant_UnitNumber = 01,
                        Tenant_CreatedAt = DateTime.Now,
                        Tenant_UpdatedAt = DateTime.Now,
                    },
                    new Tenant
                    {
                        Tenant_FirstName = "Omar Yusof",
                        Tenant_MiddleName = "",
                        Tenant_LastName = "Pila",
                        Tenant_UserName = "N/A",
                        Tenant_Email = "omar@gmail.com",
                        Tenant_PhoneNumber = "09724926591",
                        Tenant_Password = "N/A",
                        Tenant_RoomNumber = 102,
                        Tenant_UnitNumber = 01,
                        Tenant_CreatedAt = DateTime.Now,
                        Tenant_UpdatedAt = DateTime.Now,
                    },
                    new Tenant
                    {
                        Tenant_FirstName = "Jayla",
                        Tenant_MiddleName = "",
                        Tenant_LastName = "Monares",
                        Tenant_UserName = "N/A",
                        Tenant_Email = "jayla@gmail.com",
                        Tenant_PhoneNumber = "09328502810",
                        Tenant_Password = "N/A",
                        Tenant_RoomNumber = 103,
                        Tenant_UnitNumber = 01,
                        Tenant_CreatedAt = DateTime.Now,
                        Tenant_UpdatedAt = DateTime.Now,
                    },
                    new Tenant
                    {
                        Tenant_FirstName = "Yancy",
                        Tenant_MiddleName = "",
                        Tenant_LastName = "Salas",
                        Tenant_UserName = "N/A",
                        Tenant_Email = "yancy@gmail.com",
                        Tenant_PhoneNumber = "09475291721",
                        Tenant_Password = "N/A",
                        Tenant_RoomNumber = 104,
                        Tenant_UnitNumber = 01,
                        Tenant_CreatedAt = DateTime.Now,
                        Tenant_UpdatedAt = DateTime.Now,
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
