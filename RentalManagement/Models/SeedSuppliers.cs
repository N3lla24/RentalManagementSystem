using Microsoft.EntityFrameworkCore;
using RentalManagement.Data;
using System.Security.Policy;

namespace RentalManagement.Models
{
    public static class SeedSuppliers
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RentalManagementContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RentalManagementContext>>()))
            {
                // Look for any Suppliers.
                if (context.Supplier.Any())
                {
                    return;   // DB has been seeded
                }
                context.Supplier.AddRange(
                    new Supplier
                    {
                        Suppliers_Name = "Mandue Foam",
                        Suppliers_Email = "manfoam@gmail.com",
                        Suppliers_PhoneNumber = "09491238501",
                        Suppliers_Address = "Cabancalan, Mandaue City, Cebu",
                        Supplier_CreatedAt = DateTime.Now,
                        Supplier_UpdatedAt = DateTime.Now,
                    },
                    new Supplier
                    {
                        Suppliers_Name = "Coca-Cola Mandaue Distributor",
                        Suppliers_Email = "ccmd@yahoo.com",
                        Suppliers_PhoneNumber = "09568455949",
                        Suppliers_Address = "Banilad, Mandaue City, Cebu",
                        Supplier_CreatedAt = DateTime.Now,
                        Supplier_UpdatedAt = DateTime.Now,
                    },
                    new Supplier
                    {
                        Suppliers_Name = "Hanabishi Motor Electrics",
                        Suppliers_Email = "hana@gmail.com",
                        Suppliers_PhoneNumber = "09570115329",
                        Suppliers_Address = "Labogon, Mandaue City, Cebu",
                        Supplier_CreatedAt = DateTime.Now,
                        Supplier_UpdatedAt = DateTime.Now,
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
