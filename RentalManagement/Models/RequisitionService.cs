using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalManagement.Models
{
    public class RequisitionService
    {
        [Key]
        public int Req_Serv_ID { get; set; }


        [RegularExpression(@"^[a-zA-Z0-9][a-zA-Z0-9_-]*[a-zA-Z0-9]$", ErrorMessage = "Username must only contain: Alphabet letters, Numeric Numbers, _ and - Symbols")]
        [StringLength(300, MinimumLength = 2, ErrorMessage = "Username characters must be more than 2 and maximum of 300 characters.")]
        public string? Req_Serv_Name { get; set; }


        [ForeignKey("Requisition")]
        public int? RequisitionId { get; set; }
        public virtual Requisition? Requisition { get; set; }
        
    }
}
