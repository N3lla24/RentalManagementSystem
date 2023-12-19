using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalManagement.Models
{
    public class RequisitionService
    {
        [Key]
        public int Req_Serv_ID { get; set; }


        [Required(ErrorMessage = "Name is Required.")]
        public string Req_Serv_Name { get; set; }



        [ForeignKey("Requisition")]
        public int RequisitionId { get; set; }
        public virtual Requisition? Requisition { get; set; }
        
    }
}
