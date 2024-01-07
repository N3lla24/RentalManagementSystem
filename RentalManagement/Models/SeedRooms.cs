using Microsoft.EntityFrameworkCore;
using RentalManagement.Data;

namespace RentalManagement.Models
{
    public static class SeedRooms
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RentalManagementContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RentalManagementContext>>()))
            {
                // Look for any Tenants.
                if (context.Room.Any())
                {
                    return;   // DB has been seeded
                }
                context.Room.AddRange(
                    new Room
                    {
                        Room_Num = 101,
                        Room_Status = "Occupied",
                        Room_Capacity = 5,
                        Room_Price = 12000,
                        UnitId = 1,
                    },
                    new Room
                    {
                        Room_Num = 102,
                        Room_Status = "Occupied",
                        Room_Capacity = 5,
                        Room_Price = 12000,
                        UnitId = 1,
                    },
                    new Room
                    {
                        Room_Num = 103,
                        Room_Status = "Occupied",
                        Room_Capacity = 5,
                        Room_Price = 12000,
                        UnitId = 1,
                    },
                    new Room
                    {
                        Room_Num = 104,
                        Room_Status = "Occupied",
                        Room_Capacity = 5,
                        Room_Price = 12000,
                        UnitId = 1,
                    },
                    new Room
                    {
                        Room_Num = 105,
                        Room_Status = "Unoccupied",
                        Room_Capacity = 5,
                        Room_Price = 12000,
                        UnitId = 1,
                    },
                    new Room
                    {
                        Room_Num = 201,
                        Room_Status = "Unoccupied",
                        Room_Capacity = 5,
                        Room_Price = 12000,
                        UnitId = 2,
                    },
                    new Room
                    {
                        Room_Num = 202,
                        Room_Status = "Unoccupied",
                        Room_Capacity = 5,
                        Room_Price = 12000,
                        UnitId = 2,
                    },
                    new Room
                    {
                        Room_Num = 203,
                        Room_Status = "Unoccupied",
                        Room_Capacity = 5,
                        Room_Price = 12000,
                        UnitId = 2,
                    },
                    new Room
                    {
                        Room_Num = 301,
                        Room_Status = "Unoccupied",
                        Room_Capacity = 5,
                        Room_Price = 12000,
                        UnitId = 3,
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
