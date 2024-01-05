﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalManagement.Models
{
    public class RequisitionItem
    {
        [Key]
        public int Req_Item_ID { get; set; }


        [RegularExpression(@"^[a-zA-Z0-9][a-zA-Z0-9_-]*[a-zA-Z0-9]$", ErrorMessage = "Username must only contain: Alphabet letters, Numeric Numbers, _ and - Symbols")]
        [StringLength(300, MinimumLength = 2, ErrorMessage = "Username characters must be more than 2 and maximum of 300 characters.")]
        [Required(ErrorMessage = "Name is required.")]
        public string Req_Item_Name { get; set; }


        [Required(ErrorMessage = "Item Quantity is required.")]
        public int Req_Item_Quantity { get; set; }


        [StringLength(100, MinimumLength = 2, ErrorMessage = "Requisition Description must be more than 2 characters")]
        [Required(ErrorMessage = "Measurement Unit is required.")]
        public string Req_Item_Units { get; set; }


        [ForeignKey("Requisition")]
        public int? RequisitionId { get; set; }
        public virtual Requisition? Requisition { get; set; }

    }
}
