using System.ComponentModel.DataAnnotations;

namespace RentalManagement.Models
{
    public class ReportsDisplay
    {
        [Key]
        public int PayId { get; set; }

        public string Month { get; set; }
        public decimal TotalFees { get; set; }
        public decimal TotalRentPrice { get; set; }
        public decimal TotalUtilityFee { get; set; }
        public decimal TotalGarbageFee { get; set; }
        public decimal TotalAirconFee { get; set; }
        public decimal TotalInternetFee { get; set; }
        public decimal TotalRefrigeratorFee { get; set; }
        public decimal TotalWashingFee { get; set; }
    }
}
