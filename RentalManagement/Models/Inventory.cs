using System.ComponentModel.DataAnnotations;


namespace RentalManagement.Models
{
    public class Inventory
    {
        [Key]
        public int InventoryId { get; set; }


        [Required(ErrorMessage = "Inventory Item Name is required.")]
        public string Inventory_ItemName { get; set; }

        [Required(ErrorMessage = "Inventory Item Quantity is required.")]
        public int Inventory_ItemQuantity { get; set; }

        [Required(ErrorMessage = "Inventory Item Unit is required.")]
        public string Inventory_ItemUnit { get; set; }



        public DateTime Inventory_CreatedAt { get; set; } = DateTime.Now;



        public DateTime? Inventory_UpdatedAt { get; set; }
    }
}
