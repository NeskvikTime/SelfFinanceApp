using System.ComponentModel.DataAnnotations;

namespace SelfFinanceApp.Domain.Requests.FinancialOperations
{
    public class GetManyFinancialOperationsRequest 
    {
        [Required]
        public TransactionType DirectionType { get; set; }

        [Required]
        public DateOnly FromDate { get; set; }

        [Required]
        public DateOnly ToDate { get; set; }

        public string SortField { get; set; }
        
        public string SortOrder { get; set; }

        public required int Page { get; set; } = 1;

        public required int PageSize { get; set; } = 10;
    }

    public enum TransactionType
    {
        All = 0,
        Income = 1,
        Expense = 2
    }
}
