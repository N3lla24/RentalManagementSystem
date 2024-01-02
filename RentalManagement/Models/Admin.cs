using System.ComponentModel.DataAnnotations;

namespace RentalManagement.Models
{
    public class Admin 
    {
        [Key]
        public int AdminId { get; set; }
        public string Admin_FirstName { get; set; }
        public string Admin_MiddleName { get; set; }
        public string Admin_LastName { get; set; }



    }
}
