using FluentAssertions;
using Moq;
using SelfFinanceApp.Application.FinancialType.Queries.GetAllFinancialTypes;
using SelfFinanceApp.Domain.Contracts.Services;
using DomainEntities = SelfFinanceApp.Domain.Entities;
using SelfFinanceApp.Domain.Enums;

namespace SelfFinanceApp.Application.Tests.Handlers
{
    public class GetAllFinancialTypesQueryHandlerTests
    {
        private readonly Mock<IFinancialTypesService> _financialTypesServiceMock;
        private readonly GetAllFinancialTypesQueryHandler _handler;

        public GetAllFinancialTypesQueryHandlerTests()
        {
            _financialTypesServiceMock = new Mock<IFinancialTypesService>();
            _handler = new GetAllFinancialTypesQueryHandler(_financialTypesServiceMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnAllFinancialTypes()
        {
            // Arrange
            var financialTypes = new List<DomainEntities.FinancialType>
            {
                new DomainEntities.FinancialType("Rent", TransactionDirection.Expense),
                new DomainEntities.FinancialType("Salary", TransactionDirection.Income)
            };
            _financialTypesServiceMock
                .Setup(x => x.GetAllAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(financialTypes);

            var query = new GetAllFinancialTypesQuery();

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            result.Value.Should().BeEquivalentTo(financialTypes);
        }
    }
}
