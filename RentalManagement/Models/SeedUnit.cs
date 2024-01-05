using Microsoft.EntityFrameworkCore;
using RentalManagement.Data;

namespace RentalManagement.Models
{
    public static class SeedUnit
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RentalManagementContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RentalManagementContext>>()))
            {
                // Look for any Tenants.
                if (context.Unit.Any())
                {
                    return;   // DB has been seeded
                }
                context.Unit.AddRange(
                    new Unit
                    {
                        Unit_Num = 1,
                        Unit_Status = "Unoccupied",
                        Unit_CreatedAt = DateTime.Now,
                        Unit_UpdatedAt = DateTime.Now,
                    },
                    new Unit
                    {
                        Unit_Num = 2,
                        Unit_Status = "Unoccupied",
                        Unit_CreatedAt = DateTime.Now,
                        Unit_UpdatedAt = DateTime.Now,
                    },
                    new Unit
                    {
                        Unit_Num = 3,
                        Unit_Status = "Unoccupied",
                        Unit_CreatedAt = DateTime.Now,
                        Unit_UpdatedAt = DateTime.Now,
                    },
                    new Unit
                    {
                        Unit_Num = 4,
                        Unit_Status = "Unoccupied",
                        Unit_CreatedAt = DateTime.Now,
                        Unit_UpdatedAt = DateTime.Now,
                    }
                ); 
                context.SaveChanges();
            }
        }
    }
}
