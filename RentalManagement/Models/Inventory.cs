using System.ComponentModel.DataAnnotations;


namespace RentalManagement.Models
{
    public class Inventory
    {
        [Key]
        public int InventoryId { get; set; }


        [RegularExpression(@"^[a-zA-Z0-9][a-zA-Z0-9_-]*[a-zA-Z0-9]$", ErrorMessage = "Username must only contain: Alphabet letters, Numeric Numbers, _ and - Symbols")]
        [StringLength(300, MinimumLength = 2, ErrorMessage = "Username characters must be more than 2 and maximum of 300 characters.")]
        [Required(ErrorMessage = "Inventory Item Name is required.")]
        public string Inventory_ItemName { get; set; }

        [Required(ErrorMessage = "Inventory Item Quantity is required.")]
        public int Inventory_ItemQuantity { get; set; }


        [Required(ErrorMessage = "Inventory Item Unit is required.")]
        public string Inventory_ItemUnit { get; set; }



        public DateTime Inventory_CreatedAt { get; set; }



        public DateTime? Inventory_UpdatedAt { get; set; }
    }
}
