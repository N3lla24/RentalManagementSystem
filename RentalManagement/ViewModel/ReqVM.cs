using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using RentalManagement.Models;

namespace RentalManagement.ViewModel
{
    public class ReqVM
    {
        
        public Requisition? Requisition { get; set; }
        public List<RequisitionItem>? RequisitionItem { get; set; }
        public List<RequisitionService>? RequisitionService { get; set; }
        public List<Inventory>? Inventories { get; set; }

    }
}
