using System.ComponentModel.DataAnnotations;


namespace RentalManagement.Models
{
    public class Inventory
    {
        [Key]
        public int InventoryId { get; set; }
        public string Inventory_Name { get; set; }
        public decimal Inventory_Quantity { get; set; }
        public string Inventory_Unit { get; set; }
        [DataType(DataType.Date)]
        public DateTime Supplier_CreatedAt { get; set; }
        [DataType(DataType.Date)]
        public DateTime Supplier_UpdatedAt { get; set; }
    }
}
