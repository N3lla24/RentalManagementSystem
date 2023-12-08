using System.ComponentModel.DataAnnotations;


namespace RentalManagement.Models
{
    public class Inventory
    {
        [Key]
        public int InventoryId { get; set; }
        [Required(ErrorMessage = "Email Address is required.")]
        public string Inventory_ItemName { get; set; }
        public int? Inventory_ItemQuantity { get; set; }
        public string? Inventory_ItemUnit { get; set; }
        [DataType(DataType.Date)]
        public DateTime Inventory_CreatedAt { get; set; }
        [DataType(DataType.Date)]
        public DateTime? Inventory_UpdatedAt { get; set; }
    }
}
