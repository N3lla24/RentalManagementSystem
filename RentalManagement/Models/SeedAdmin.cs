using Microsoft.EntityFrameworkCore;
using RentalManagement.Data;

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
                        Admin_Password = "admin/Password123",
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
