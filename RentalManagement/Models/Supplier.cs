using System.ComponentModel.DataAnnotations;


namespace RentalManagement.Models
{
    public class Supplier
    {
        [Key]
        public int SuppliersId { get; set; }
        public string Suppliers_Name { get; set; }
        public string Suppliers_Email { get; set; }
        public string Suppliers_PhoneNumber { get; set; }
        public string Suppliers_Address { get; set; }
        [DataType(DataType.Date)]
        public DateTime Supplier_CreatedAt { get; set; }
        [DataType(DataType.Date)]
        public DateTime Supplier_UpdatedAt { get; set; }
    }
}
