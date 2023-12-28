﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalManagement.Models
{
    public class PurchaseItem
    {
        [Key]
        public int PurchaseItem_Id { get; set; }


        [Required(ErrorMessage = "Purchase Item Name is required.")]
        public string PurchaseItem_Name { get; set; }


        [Required(ErrorMessage = "Purchase Item Quantity is required.")]
        public int PurchaseItem_Quantity { get; set; }


        [Required(ErrorMessage = "Purchase Item Unit is required.")]
        public string PurchaseItem_Unit { get; set; }



        [ForeignKey("PurchaseOrder")]
        public int PurchaseOrderId { get; set; }


        public virtual PurchaseOrder PurchaseOrder { get; set; }
    }
}
