using System.ComponentModel.DataAnnotations;

namespace RentalManagement.Models
{
    public class ApplicationDisplay
    {
        [Key]
        public int ApplicationId { get; set; }
        public string Applicants_FirstName { get; set; }
        public string? Applicants_MiddleName { get; set; }
        public string Applicants_LastName { get; set; }
        public string Applicants_Email { get; set; }
        public string Applicants_PhoneNumber { get; set; }
        public string Applicants_Address { get; set; }
        public int Application_RoomNumber { get; set; }
        public int Application_UnitNumber { get; set; }
        public string Application_Status { get; set; }
        public string Application_StatusRemarks { get; set; }
        public DateTime Applicant_CreatedAt { get; set; }
        public DateTime? Applicant_UpdatedAt { get; set; }
    }
}
