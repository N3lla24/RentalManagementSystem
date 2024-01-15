using RentalManagement.Models;
using System.ComponentModel.DataAnnotations;

namespace RentalManagement.ViewModel
{
    public class CheckInventoryVM
    {
        public IEnumerable<Tenant>? Tenants { get; set; }
        public Tenant? Tenant { get; set; }
        public IEnumerable<Requisition>? Requisitions {get; set;}
        public Requisition? Requisition { get; set; }
        public IEnumerable<RequisitionItem>? RequisitionItems { get; set; }
        public RequisitionItem? RequisitionItem { get; set; }
        public IEnumerable<Inventory>? Inventories { get; set; }
        public Inventory? Inventory { get; set; }
    }
}
