using AutoMapper;
using FluentAssertions;
using SelfFinanceApp.Application.FinancialOperations.Queries.GetManyFinancialFinancialOperations;
using SelfFinanceApp.Application.Mappings;
using SelfFinanceApp.Domain.Requests.FinancialOperations;

namespace SelfFinanceApp.Application.Tests.MappingTests
{
    public class FinancialOperationProfileTests
    {
        private readonly MapperConfiguration _config;

        public FinancialOperationProfileTests()
        {
            _config = new MapperConfiguration(cfg => cfg.AddMaps(typeof(FinancialOperationProfile).Assembly));
        }

        [Fact]
        public void ConfigurationIsValid()
        {
            // Act & Assert
            _config.AssertConfigurationIsValid();
        }

        [Fact]
        public void ShouldMapGetManyFinancialOperationsRequestToGetManyFinancialOperationsQuery()
        {
            // Arrange
            var mapper = _config.CreateMapper();
            var source = new GetManyFinancialOperationsRequest
            {
                DirectionType = TransactionType.Expense,
                FromDate = DateOnly.MinValue,
                ToDate = DateOnly.MaxValue,
                SortField = "Amount",
                SortOrder = "Desc",
                Page = 2,
                PageSize = 20
            };

            // Act
            var destination = mapper.Map<GetManyFinancialOperationsQuery>(source);

            // Assert
            destination.Should().BeEquivalentTo(source, options =>
                options.ExcludingMissingMembers()
            );
        }
    }
}
