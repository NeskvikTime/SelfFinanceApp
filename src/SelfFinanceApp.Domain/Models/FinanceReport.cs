using SelfFinanceApp.Domain.Pages;
using SelfFinanceApp.Domain.Responses.FinancialOperations;

namespace SelfFinanceApp.Domain.Models
{
    public class FinancialReport
    {
        public decimal TotalIncome { get; set; }
        public decimal TotalExpenses { get; set; }

        public string Currency { get; set; }

        public PagedResult<GetFinancialOperationResponse> Operations { get; set; }
        public int TotalCount { get; set; }

        public FinancialReport(PagedResult<GetFinancialOperationResponse> operations, decimal totalIncome, decimal totalExpense, string currency, int totalCount)
        {
            Operations = operations;
            TotalIncome = totalIncome;
            TotalExpenses = totalExpense;
            Currency = currency;
            TotalCount = totalCount;
        }
    }
}
