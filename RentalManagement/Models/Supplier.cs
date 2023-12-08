using System.ComponentModel.DataAnnotations;


namespace RentalManagement.Models
{
    public class Supplier
    {
        [Key]
        public int SuppliersId { get; set; }
        [Required(ErrorMessage = "Supplier Name is required.")]
        public string Suppliers_Name { get; set; }
        [Required(ErrorMessage = "Supplier Email Address is required.")]
        public string Suppliers_Email { get; set; }
        [Required(ErrorMessage = "Supplier Phone Number is required.")]
        public string Suppliers_PhoneNumber { get; set; }
        [Required(ErrorMessage = "Supplier Address is required.")]
        public string Suppliers_Address { get; set; }
        [DataType(DataType.Date)]
        public DateTime Supplier_CreatedAt { get; set; }
        [DataType(DataType.Date)]
        public DateTime Supplier_UpdatedAt { get; set; }
    }
}
