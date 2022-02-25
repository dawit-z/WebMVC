using System.ComponentModel.DataAnnotations;

namespace WebMVC.Models
{
    public class FutureValueModel
    {
        [Required(ErrorMessage = "Please enter a monthly investment amount.")]
        [Range(1, 500, ErrorMessage = "Monthly Amount must be between 1 and 500")]
        public decimal? MonthlyInvestment { get; set; }

        [Required(ErrorMessage = "Please enter a Yearly Interest Rate.")]
        [Range(0.1, 10.0, ErrorMessage = "Yearly Interest Rate must be between .1 and 10")]
        public decimal? YearlyInterestRate { get; set; }

        [Required(ErrorMessage = "Please enter # of year(s).")]
        [Range(1, 50, ErrorMessage = "# of Year(s) must be between 1 and 50")]
        public int? Years { get; set; }

        public decimal? CalculateFutureValue()
        {
            int? months = Years * 12;
            decimal? monthlyInterestRate = YearlyInterestRate / 12 / 100;
            decimal? futureValue = 0;
            for (int i = 0; i < months; i++)
            {
                futureValue = (futureValue + MonthlyInvestment) * (1 + monthlyInterestRate);
            }
            return futureValue;
        }
    }
}