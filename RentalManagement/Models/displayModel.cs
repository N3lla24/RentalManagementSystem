using System.ComponentModel.DataAnnotations;

namespace RentalManagement.Models
{
    public class RentalViewModel
    {
        public List<TenantDisplay> Tenant { get; set; } 
        public List<RequisitionDisplay> Requisition { get; set; }
        public List<RoomDisplay> Room { get; set; }
        public List<ReportsDisplay> Reports { get; set; }
        public List<InvoiceDisplay> Invoice { get; set; }
        public List<ApplicationDisplay> Applicants { get; set; }

        public List<PaymentDetail> PaymentHistory { get; set; }
        public List<Requisition> RequisitionHistory { get; set; }

        public Dictionary<string, int> InvoiceStatusCounts { get; set; }

        public Dictionary<int, int> RoomSizeCounts { get; set; }




    }

}
