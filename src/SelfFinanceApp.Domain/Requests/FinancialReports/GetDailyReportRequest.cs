
using System.ComponentModel.DataAnnotations;

namespace SelfFinanceApp.Domain.Requests.FinancialReports
{
    public class GetDailyReportRequest
    {
        [Required]
        public DateOnly FromDate { get; set; }

        [Required]
        public DateOnly ToDate { get; set; }

        [Required]
        public string Currency { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
