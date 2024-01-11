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
                        Room_Size = 500,
                        Room_Color = "White",
                        Room_Flooring = "Tiles",
                        Room_Appliance = "Mini-Fridge",
                        Room_Furnish = "Yes",
                        Room_WiFi = "Yes",
                        UnitId = 1,
                    },
                    new Room
                    {
                        Room_Num = 102,
                        Room_Status = "Occupied",
                        Room_Capacity = 5,
                        Room_Price = 12000,
                        Room_Size = 450,
                        Room_Color = "Black",
                        Room_Flooring = "Wooden Tiles",
                        Room_Appliance = "TV",
                        Room_Furnish = "Yes",
                        Room_WiFi = "Yes",
                        UnitId = 1,
                    },
                    new Room
                    {
                        Room_Num = 103,
                        Room_Status = "Occupied",
                        Room_Capacity = 3,
                        Room_Size = 400,
                        Room_Color = "Orange",
                        Room_Flooring = "Wooden Tiles",
                        Room_Appliance = "Mini-Fridge",
                        Room_Furnish = "Yes",
                        Room_WiFi = "Yes",
                        Room_Price = 10000,
                        UnitId = 1,
                    },
                    new Room
                    {
                        Room_Num = 104,
                        Room_Status = "Occupied",
                        Room_Size = 400,
                        Room_Color = "Beige",
                        Room_Flooring = "Wood",
                        Room_Appliance = "Oven",
                        Room_Furnish = "Yes",
                        Room_WiFi = "Yes",
                        Room_Capacity = 3,
                        Room_Price = 10000,
                        UnitId = 1,
                    },
                    new Room
                    {
                        Room_Num = 105,
                        Room_Status = "Unoccupied",
                        Room_Capacity = 3,
                        Room_Size = 400,
                        Room_Color = "White",
                        Room_Flooring = "Tiles",
                        Room_Appliance = "Mini-Fridge",
                        Room_Furnish = "No",
                        Room_WiFi = "Yes",
                        Room_Price = 10000,
                        UnitId = 1,
                    },
                    new Room
                    {
                        Room_Num = 201,
                        Room_Status = "Unoccupied",
                        Room_Capacity = 4,
                        Room_Size = 500,
                        Room_Color = "White",
                        Room_Flooring = "Tiles",
                        Room_Appliance = "Microwave",
                        Room_Furnish = "Yes",
                        Room_WiFi = "Yes",
                        Room_Price = 12000,
                        UnitId = 2,
                    },
                    new Room
                    {
                        Room_Num = 202,
                        Room_Status = "Unoccupied",
                        Room_Capacity = 2,
                        Room_Size = 300,
                        Room_Color = "Black",
                        Room_Flooring = "Wood",
                        Room_Appliance = "None",
                        Room_Furnish = "No",
                        Room_WiFi = "Yes",
                        Room_Price = 8000,
                        UnitId = 2,
                    },
                    new Room
                    {
                        Room_Num = 203,
                        Room_Status = "Unoccupied",
                        Room_Capacity = 1,
                        Room_Size = 200,
                        Room_Color = "Red",
                        Room_Flooring = "Cement",
                        Room_Appliance = "Mini-Fridge",
                        Room_Furnish = "No",
                        Room_WiFi = "No",
                        Room_Price = 5000,
                        UnitId = 2,
                    },
                    new Room
                    {
                        Room_Num = 301,
                        Room_Status = "Unoccupied",
                        Room_Capacity = 4,
                        Room_Size = 500,
                        Room_Color = "White",
                        Room_Flooring = "Tiles",
                        Room_Appliance = "Oven",
                        Room_Furnish = "Yes",
                        Room_WiFi = "Yes",
                        Room_Price = 10000,
                        UnitId = 3,
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
