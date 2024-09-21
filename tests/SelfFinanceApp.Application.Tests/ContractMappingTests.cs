using SelfFinanceApp.Application.Extensions;
using SelfFinanceApp.Application.FinancialOperations.Queries.GetManyFinancialFinancialOperations;
using SelfFinanceApp.Domain.Enums;
using SelfFinanceApp.Domain.Requests.FinancialOperations;

namespace SelfFinanceApp.Application.Tests
{
    public class ContractMappingTests
    {
        [Theory]
        [InlineData("+", SortOrder.Ascending)]
        [InlineData("-", SortOrder.Descending)]
        [InlineData(null, SortOrder.Unspecified)]
        [InlineData("", SortOrder.Ascending)]
        public void GetSortOrder_ShouldReturnCorrectSortOrder(string sortOrder, SortOrder expected)
        {
            // Arrange
            var request = new GetManyFinancialOperationsQuery(TransactionType.All, DateOnly.MinValue, DateOnly.MaxValue, null, 1, 10, sortOrder);

            // Act
            var result = request.GetSortOrder();

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(TransactionType.Income, TransactionDirection.Income)]
        [InlineData(TransactionType.Expense, TransactionDirection.Expense)]
        [InlineData(TransactionType.All, null)]
        public void GetTransactionDirection_ShouldReturnCorrectTransactionDirection(TransactionType transactionType, TransactionDirection? expected)
        {
            // Arrange
            var request = new GetManyFinancialOperationsQuery(transactionType, DateOnly.MinValue, DateOnly.MaxValue, null, 1, 10, null);

            // Act
            var result = request.GetTransactionDirection();

            // Assert
            result.Should().Be(expected);
        }
    }
}
