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
                        Tenant_FirstName = "Ronel",
                        Tenant_MiddleName = "Napoles",
                        Tenant_LastName = "Delig",
                        Tenant_Email = "ronel@gmail.com",
                        Tenant_PhoneNumber = "09392719001",
                        Tenant_Password = "Password",
                        Tenant_RoomNumber = 101,
                        Tenant_UnitNumber = 02,
                        Tenant_TotPay = Convert.ToDecimal(121000.00),
                        Tenant_CreatedAt = DateTime.Now,
                        Tenant_UpdatedAt = DateTime.Now,
                    },
                    new Tenant
                    {
                        Tenant_FirstName = "Omar Yusof",
                        Tenant_MiddleName = "",
                        Tenant_LastName = "Pila",
                        Tenant_Email = "omar@gmail.com",
                        Tenant_PhoneNumber = "09724926591",
                        Tenant_Password = "Password",
                        Tenant_RoomNumber = 102,
                        Tenant_UnitNumber = 03,
                        Tenant_TotPay = Convert.ToDecimal(151000.00),
                        Tenant_CreatedAt = DateTime.Now,
                        Tenant_UpdatedAt = DateTime.Now,
                    },
                    new Tenant
                    {
                        Tenant_FirstName = "Jayka",
                        Tenant_MiddleName = "",
                        Tenant_LastName = "Monares",
                        Tenant_Email = "jayla@gmail.com",
                        Tenant_PhoneNumber = "09328502810",
                        Tenant_Password = "Password",
                        Tenant_RoomNumber = 103,
                        Tenant_UnitNumber = 04,
                        Tenant_TotPay = Convert.ToDecimal(101000.00),
                        Tenant_CreatedAt = DateTime.Now,
                        Tenant_UpdatedAt = DateTime.Now,
                    },
                    new Tenant
                    {
                        Tenant_FirstName = "Yancy",
                        Tenant_MiddleName = "",
                        Tenant_LastName = "Salas",
                        Tenant_Email = "yancy@gmail.com",
                        Tenant_PhoneNumber = "09475291721",
                        Tenant_Password = "Password",
                        Tenant_RoomNumber = 104,
                        Tenant_UnitNumber = 06,
                        Tenant_TotPay = Convert.ToDecimal(191000.00),
                        Tenant_CreatedAt = DateTime.Now,
                        Tenant_UpdatedAt = DateTime.Now,
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
