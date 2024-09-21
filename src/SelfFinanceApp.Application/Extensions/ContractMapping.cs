using SelfFinanceApp.Application.FinancialOperations.Queries.GetManyFinancialFinancialOperations;
using SelfFinanceApp.Domain.Enums;
using SelfFinanceApp.Domain.Requests.FinancialOperations;

namespace SelfFinanceApp.Application.Extensions
{
    public static class ContractMapping
    {
        public static SortOrder GetSortOrder(this GetManyFinancialOperationsQuery request)
        {
            SortOrder sortOrder = request.SortOrder is null ? SortOrder.Unspecified :
                request.SortOrder.StartsWith('-') ? SortOrder.Descending : SortOrder.Ascending;

            return sortOrder;
        }

        public static TransactionDirection? GetTransactionDirection(this GetManyFinancialOperationsQuery request)
        {
            if (request.DirectionType == TransactionType.Income)
            {
                return TransactionDirection.Income;
            }

            if (request.DirectionType == TransactionType.Expense)
            {
                return TransactionDirection.Expense;
            }

            return null;
        }
    }
}
