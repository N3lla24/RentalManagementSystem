using Microsoft.EntityFrameworkCore;
using RentalManagement.Data;
using RentalManagement.Services;

namespace RentalManagement.Models
{
    public static class SeedAdmin
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RentalManagementContext(
                 serviceProvider.GetRequiredService<
                     DbContextOptions<RentalManagementContext>>()))
            {
                if (context.Admin.Any())
                {
                    return;
                }
                context.Admin.AddRange(
                    new Admin
                    {
                        Admin_UserName = "Admin12345",
                        Admin_Password = Hashing.HashPass("admin/Password123"),
                        Admin_Email = "Admin@admin.com",
                        Admin_PhoneNumber = "09903918672"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
