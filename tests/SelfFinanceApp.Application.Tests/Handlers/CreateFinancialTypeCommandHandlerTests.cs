using AutoMapper;
using ErrorOr;
using FluentAssertions;
using Moq;
using SelfFinanceApp.Application.FinancialType.Commands.Create;
using SelfFinanceApp.Domain.Contracts.Services;
using DomainEntities = SelfFinanceApp.Domain.Entities;
using SelfFinanceApp.Domain.Enums;
using SelfFinanceApp.Tests.Shared.Builders;

namespace SelfFinanceApp.Application.Tests.Handlers;

public class CreateFinancialTypeCommandHandlerTests
{

    private readonly Mock<IFinancialTypesService> _financialTypesServiceMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly CreateFinancialTypeCommandHandler _handler;

    public CreateFinancialTypeCommandHandlerTests()
    {
        _financialTypesServiceMock = new Mock<IFinancialTypesService>();
        _mapperMock = new Mock<IMapper>();
        _handler = new CreateFinancialTypeCommandHandler(_financialTypesServiceMock.Object);
    }

    [Fact]
    public async Task Handle_ValidRequest_ShouldReturnFinancialType()
    {
        // Arrange
        var financeTypeBuilder = new FinancialTypeBuilder().WithName("Rent").WithTransactionDirection(TransactionDirection.Expense);
        var financialType = financeTypeBuilder.Build();
        var command = new CreateFinancialTypeCommand(financialType.Name, financialType.TransactionType);

        _financialTypesServiceMock.Setup(x => x.AddAsync(It.IsAny<DomainEntities.FinancialType>(), It.IsAny<CancellationToken>()))
                                  .ReturnsAsync(financialType);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        result.Value.Should().BeEquivalentTo(financialType);
    }

    [Fact]
    public async Task Handle_WhenServiceReturnsError_ShouldReturnError()
    {
        // Arrange
        var financeTypeBuilder = new FinancialTypeBuilder().WithName("Rent").WithTransactionDirection(TransactionDirection.Expense);
        var financialType = financeTypeBuilder.Build();
        var command = new CreateFinancialTypeCommand(financialType.Name, financialType.TransactionType);

        _financialTypesServiceMock.Setup(x => x.AddAsync(It.IsAny<DomainEntities.FinancialType>(), It.IsAny<CancellationToken>()))
                                  .ReturnsAsync(Error.Conflict("Error Adding finance type!"));

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        result.IsError.Should().BeTrue();
    }
}
