using ErrorOr;
using FluentAssertions;
using Moq;
using SelfFinanceApp.Application.FinancialOperations.Commands.Create;
using SelfFinanceApp.Domain.Contracts.Services;
using SelfFinanceApp.Domain.ValueObjects;
using SelfFinanceApp.Tests.Shared.Builders;

namespace SelfFinanceApp.Application.Tests.Handlers
{
    public class CreateFinancialOperationCommandHandlerTests
    {
        private readonly Mock<IFinancialOperationsService> _financialOperationsServiceMock;
        private readonly CreateFinancialOperationCommandHandler _handler;

        public CreateFinancialOperationCommandHandlerTests()
        {
            _financialOperationsServiceMock = new Mock<IFinancialOperationsService>();
            _handler = new CreateFinancialOperationCommandHandler(_financialOperationsServiceMock.Object);
        }

        [Fact]
        public async Task Should_ReturnError_When_AddingFinancialOperationFails()
        {
            // Arrange
            var command = new CreateFinancialOperationCommand("Name", 200, "USD", Guid.NewGuid());
            var cancellationToken = new CancellationToken();

            _financialOperationsServiceMock.Setup(x => x.AddFinancialOperationAsync(It.IsAny<string>(), It.IsAny<decimal>(), It.IsAny<string>(), It.IsAny<Guid>(), cancellationToken))
                .ReturnsAsync(Error.Conflict("Some conflict"));

            // Act
            var result = await _handler.Handle(command, cancellationToken);

            // Assert
            result.IsError.Should().BeTrue();
        }

        [Fact]
        public async Task Should_ReturnFinancialOperation_When_AddingSucceeds()
        {
            // Arrange
            var financialOperation = new FinancialOperationBuilder()
                .WithName("Name")
                .WithMoney(new MonetaryValue(200, "USD"))
                .WithId(Guid.NewGuid())
                .Build();

            var command = new CreateFinancialOperationCommand(financialOperation.Name, financialOperation.Money.Amount, financialOperation.Money.Currency, financialOperation.FinanceTypeId);
            var cancellationToken = new CancellationToken();

            _financialOperationsServiceMock.Setup(x => x.AddFinancialOperationAsync(It.IsAny<string>(), It.IsAny<decimal>(), It.IsAny<string>(), It.IsAny<Guid>(), cancellationToken))
                .ReturnsAsync(financialOperation);

            _financialOperationsServiceMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>(), cancellationToken))
                .ReturnsAsync(financialOperation);

            // Act
            var result = await _handler.Handle(command, cancellationToken);

            // Assert
            result.IsError.Should().BeFalse();
            result.Value.Should().BeEquivalentTo(financialOperation);
        }
    }
}
