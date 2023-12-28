using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using RentalManagement.Data;

namespace RentalManagement.Models
{
    public static class SeedInventory
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RentalManagementContext(
                 serviceProvider.GetRequiredService<
                     DbContextOptions<RentalManagementContext>>()))
            {
                // Look for any Inventory
                if (context.Inventory.Any())
                {
                    return;   // DB has been seeded
                }

                context.Inventory.AddRange(
                   new Inventory
                   {
                       Inventory_ItemName = "Silka Whitening Soap",
                       Inventory_ItemQuantity = 100,
                       Inventory_ItemUnit = "pcs",
                       Inventory_CreatedAt = DateTime.Now,
                       Inventory_UpdatedAt = DateTime.Now,
                   },
                   new Inventory
                   {
                       Inventory_ItemName = "Super Sized Mattress",
                       Inventory_ItemQuantity = 5,
                       Inventory_ItemUnit = "pcs",
                       Inventory_CreatedAt = DateTime.Now,
                       Inventory_UpdatedAt = DateTime.Now,
                   },
                   new Inventory
                   {
                       Inventory_ItemName = "Nordic Chairs",
                       Inventory_ItemQuantity = 10,
                       Inventory_ItemUnit = "pcs",
                       Inventory_CreatedAt = DateTime.Now,
                       Inventory_UpdatedAt = DateTime.Now,
                   },
                   new Inventory
                   {
                       Inventory_ItemName = "Mineral Gallons",
                       Inventory_ItemQuantity = 5,
                       Inventory_ItemUnit = "pcs",
                       Inventory_CreatedAt = DateTime.Now,
                       Inventory_UpdatedAt = DateTime.Now,
                   },
                   new Inventory
                   {
                       Inventory_ItemName = "Hanabishi Wall Fans",
                       Inventory_ItemQuantity = 1,
                       Inventory_ItemUnit = "pcs",
                       Inventory_CreatedAt = DateTime.Now,
                       Inventory_UpdatedAt = DateTime.Now,
                   }
                );
                context.SaveChanges();
            }
        }
    }
}
