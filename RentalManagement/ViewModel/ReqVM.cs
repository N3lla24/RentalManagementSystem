using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using RentalManagement.Models;

namespace RentalManagement.ViewModel
{
    public class ReqVM
    {
        public int RequisitionId { get; set; }

        public string Requisition_Type { get; set; }

        public string Requisition_Status_Remarks { get; set; }

        public DateTime Requistition_CreatedAt { get; set; } = DateTime.Now;

        public DateTime Requisition_DueDate { get; set; }

        public string Requisition_Status { get; set; } = "Pending";

        public int TenantId { get; set; }

        public List<RequisitionItem>? ReqItem { get; set; }
        public List<RequisitionService>? ReqServ { get; set; }
    }
}
