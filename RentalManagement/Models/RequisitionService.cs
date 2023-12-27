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


        [StringLength(300, MinimumLength = 10, ErrorMessage = "Requisition Description must be more than 10 characters & maximum of 300 characters.")]
        public string Req_Serv_Remarks { get; set; }


        [DataType(DataType.Date)]
        public DateTime Req_Serv_DueDate { get; set; }



        [ForeignKey("Requisition")]
        public int RequisitionId { get; set; }
        public virtual Requisition? Requisition { get; set; }
        
    }
}
