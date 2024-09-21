using SelfFinanceApp.Domain.Enums;
using SelfFinanceApp.Domain.ValueObjects;
using SelfFinanceApp.Tests.Shared.Builders;

namespace SelfFinanceApp.Domain.Tests;

public class FinancialOperationTests
{
    [Fact]
    public void Constructor_ShouldCreateObjectWithExpectedValues()
    {
        // Arrange
        var expectedName = "Operation";
        var expectedMoney = new MonetaryValue(100, "USD");
        var expectedFinanceTypeId = Guid.NewGuid();
        var expectedId = Guid.NewGuid();

        var financeType = new FinancialTypeBuilder()
                            .WithName("Test")
                            .WithTransactionDirection(TransactionDirection.Income)
                            .WithId(expectedFinanceTypeId)
                            .Build();

        var financialOperation = new FinancialOperationBuilder()
            .WithName(expectedName)
            .WithMonetaryValue(expectedMoney)
            .WithFinancialType(financeType)
            .WithId(expectedId)
            .Build();

        // Assert
        financialOperation.Id.Should().Be(expectedId);
        financialOperation.Name.Should().Be(expectedName);
        financialOperation.Money.Should().Be(expectedMoney);
        financialOperation.FinanceTypeId.Should().Be(expectedFinanceTypeId);
    }

    [Fact]
    public void WithMonetaryValue_ShouldChangeMonetaryValue()
    {
        // Arrange
        var expectedNewMoney = new MonetaryValue(200, "USD");
        var financialOperation = new FinancialOperationBuilder().Build();

        // Act
        financialOperation.WithMonetaryValue(expectedNewMoney);

        // Assert
        financialOperation.Money.Should().Be(expectedNewMoney);
    }

    [Fact]
    public void ChangeName_ShouldChangeNameOfObject()
    {
        // Arrange
        var expectedNewName = "NewName";
        var financialOperation = new FinancialOperationBuilder().Build();

        // Act
        financialOperation.ChangeName(expectedNewName);

        // Assert
        financialOperation.Name.Should().Be(expectedNewName);
    }

    [Fact]
    public void ChangeFinanceTypeId_ShouldChangeFinanceTypeId()
    {
        // Arrange
        var financeType = new FinancialTypeBuilder().Build();

        var expectedNewFinanceTypeId = Guid.NewGuid();
        var financialOperation = new FinancialOperationBuilder().WithFinancialType(financeType).Build();

        // Act
        financialOperation.ChangeFinanceTypeId(expectedNewFinanceTypeId);

        // Assert
        financialOperation.FinanceTypeId.Should().Be(expectedNewFinanceTypeId);
        financialOperation.FinanceType.Should().BeNull();
    }
}
