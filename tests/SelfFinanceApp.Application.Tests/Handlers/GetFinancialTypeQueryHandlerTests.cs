using FluentAssertions;
using Moq;
using SelfFinanceApp.Application.FinancialType.Queries.GetFinanceType;
using SelfFinanceApp.Domain.Contracts.Repositories;
using DomainEntities = SelfFinanceApp.Domain.Entities;
using SelfFinanceApp.Domain.Enums;

namespace SelfFinanceApp.Application.Tests.Handlers
{
    public class GetFinancialTypeQueryHandlerTests
    {
        private readonly Mock<IFinancialTypesRepository> _financialTypeRepositoryMock;
        private readonly GetFinancialTypeQueryHandler _handler;

        public GetFinancialTypeQueryHandlerTests()
        {
            _financialTypeRepositoryMock = new Mock<IFinancialTypesRepository>();
            _handler = new GetFinancialTypeQueryHandler(_financialTypeRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_GivenValidId_ShouldReturnFinancialType()
        {
            // Arrange
            var financialTypeId = Guid.NewGuid();
            var financialType = new DomainEntities.FinancialType("Rent", TransactionDirection.Expense, financialTypeId);
            _financialTypeRepositoryMock
                .Setup(x => x.GetByIdAsync(financialTypeId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(financialType);

            var query = new GetFinancialTypeQuery(financialTypeId);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            result.Value.Should().BeEquivalentTo(financialType);
        }

        [Fact]
        public async Task Handle_GivenInvalidId_ShouldReturnError()
        {
            // Arrange
            var financialTypeId = Guid.NewGuid();
            _financialTypeRepositoryMock
                .Setup(x => x.GetByIdAsync(financialTypeId, It.IsAny<CancellationToken>()))
                .ReturnsAsync((DomainEntities.FinancialType)null);

            var query = new GetFinancialTypeQuery(financialTypeId);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            result.IsError.Should().BeTrue();
        }
    }
}
