using Microsoft.EntityFrameworkCore;
using RentalManagement.Data;

namespace RentalManagement.Models
{
    public static class SeedApplicantForms
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RentalManagementContext(
                 serviceProvider.GetRequiredService<
                     DbContextOptions<RentalManagementContext>>()))
            {
                if (context.ApplicantForm.Any())
                {
                    return;
                }
                context.ApplicantForm.AddRange(
                    new ApplicantForm
                    {
                        ApplicationId = 1,
                        Application_CreatedAt = DateTime.Now,
                        Application_RoomNumber = 921,
                        Application_UnitNumber = 567,
                        Application_Status = "Pending"
                    },
                    new ApplicantForm
                    {
                        ApplicationId = 2,
                        Application_CreatedAt = DateTime.Now,
                        Application_RoomNumber = 945,
                        Application_UnitNumber = 589,
                        Application_Status = "Pending"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
