using System.ComponentModel.DataAnnotations;


namespace RentalManagement.Models
{
    public class Supplier
    {
        [Key]
        public int SuppliersId { get; set; }


        [Required(ErrorMessage = "Supplier Name is required.")]
        public string Suppliers_Name { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*\.[a-z]{2,}$")]
        [Required(ErrorMessage = "Supplier Email Address is required.")]
        public string Suppliers_Email { get; set; }

        [RegularExpression(@"^09\d{9}$")]
        [Required(ErrorMessage = "Supplier Phone Number is required.")]
        public string Suppliers_PhoneNumber { get; set; }


        [Required(ErrorMessage = "Supplier Address is required.")]
        public string Suppliers_Address { get; set; }



        public DateTime Supplier_CreatedAt { get; set; } = DateTime.Now;



        public DateTime? Supplier_UpdatedAt { get; set; }
    }
}
