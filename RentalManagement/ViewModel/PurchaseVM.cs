using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using RentalManagement.Models;

namespace RentalManagement.ViewModel
{
    public class PurchaseVM
    {

        public Requisition? Requisitions { get; set; }
        public PurchaseOrder? PurchaseOrder { get; set; }
        public IEnumerable<PurchaseItem>? PurchaseItems { get; set; }
        public IEnumerable<PurchaseService>? PurchaseServices { get; set; }
        public IEnumerable<Supplier>? Suppliers { get; set; }
        public int supplierId { get; set; }


    }
}
