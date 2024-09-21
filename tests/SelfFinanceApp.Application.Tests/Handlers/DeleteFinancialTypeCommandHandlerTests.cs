using ErrorOr;
using FluentAssertions;
using Moq;
using SelfFinanceApp.Application.FinancialType.Commands.Delete;
using SelfFinanceApp.Domain.Contracts.Services;

namespace SelfFinanceApp.Application.Tests.Handlers
{
    public class DeleteFinancialTypeCommandHandlerTests
    {
        private readonly Mock<IFinancialTypesService> _financialTypesServiceMock;
        private readonly DeleteFinancialTypeCommandHandler _handler;

        public DeleteFinancialTypeCommandHandlerTests()
        {
            _financialTypesServiceMock = new Mock<IFinancialTypesService>();
            _handler = new DeleteFinancialTypeCommandHandler(_financialTypesServiceMock.Object);
        }

        [Fact]
        public async Task Handle_ValidId_ShouldReturnDeleted()
        {
            // Arrange
            var id = Guid.NewGuid();
            var command = new DeleteFinancialTypeCommand(id);

            _financialTypesServiceMock.Setup(x => x.DeleteByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                                      .ReturnsAsync(true);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.Value.Should().Be(Result.Deleted);
        }

        [Fact]
        public async Task Handle_InvalidId_ShouldReturnError()
        {
            // Arrange
            var id = Guid.NewGuid();
            var command = new DeleteFinancialTypeCommand(id);

            _financialTypesServiceMock.Setup(x => x.DeleteByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                                      .ReturnsAsync(false);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsError.Should().BeTrue();
        }
    }
}
