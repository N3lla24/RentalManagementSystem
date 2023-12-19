using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalManagement.Models
{
    public class RequisitionService
    {
        [Key]
        [ForeignKey("Requisition")]
        public int Req_Serv_ID { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Req_Serv_Name { get; set; }


        public virtual Requisition? Requisition { get; set; }
    }
}
