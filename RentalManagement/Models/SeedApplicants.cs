using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using RentalManagement.Data;

namespace RentalManagement.Models
{
    public static class SeedApplicants
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RentalManagementContext(
                 serviceProvider.GetRequiredService<
                     DbContextOptions<RentalManagementContext>>()))
            {
                // Look for any Applicants.
                if (context.Applicants.Any())
                {
                    return;   // DB has been seeded
                }

                context.Applicants.AddRange(
                   new Applicants
                   {
                       Applicants_FirstName = "Ricards",
                       Applicants_MiddleName = "Lopez",
                       Applicants_LastName = "Gunguna",
                       Applicants_Email = "rechards@gmail.com",
                       Applicants_PhoneNumber = "09987431022",
                       Applicants_Address = "Looc, Mandaue City, Cebu",
                       Applicant_CreatedAt = DateTime.Now,
                       Applicant_UpdatedAt = DateTime.Now,
                       Application_RoomNumber = 921,
                       Application_UnitNumber = 567,
                       Application_Status = "Pending"
                   },
                   new Applicants
                   {
                       Applicants_FirstName = "Nella",
                       Applicants_MiddleName = "Paloma",
                       Applicants_LastName = "Dela_Cruz",
                       Applicants_Email = "nellaaa@gmail.com",
                       Applicants_PhoneNumber = "09432098765",
                       Applicants_Address = "Guizo, Mandaue City, Cebu",
                       Applicant_CreatedAt = DateTime.Now,
                       Applicant_UpdatedAt = DateTime.Now,
                       Application_RoomNumber = 202,
                       Application_UnitNumber = 2,
                       Application_Status = "Pending"
                   }
                );
                context.SaveChanges();
            }
        }
    }
}
