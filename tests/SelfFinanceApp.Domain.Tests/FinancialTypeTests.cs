using SelfFinanceApp.Domain.Entities;
using SelfFinanceApp.Domain.Enums;
using SelfFinanceApp.Tests.Shared.Builders;

namespace SelfFinanceApp.Domain.Tests
{
    public class FinancialTypeTests
    {
        [Fact]
        public void Constructor_ShouldCreateObjectWithExpectedValues()
        {
            // Arrange
            var expectedName = "Test";
            var expectedTransactionType = TransactionDirection.Income;
            var expectedId = Guid.NewGuid();
            var builder = new FinancialTypeBuilder()
                            .WithName(expectedName)
                            .WithTransactionDirection(expectedTransactionType)
                            .WithId(expectedId);

            // Act
            var financialType = builder.Build();

            // Assert
            financialType.Id.Should().Be(expectedId);
            financialType.Name.Should().Be(expectedName);
            financialType.TransactionType.Should().Be(expectedTransactionType);
        }

        [Fact]
        public void ChangeName_ShouldChangeNameOfObject()
        {
            // Arrange
            var builder = new FinancialTypeBuilder().WithName("OldName");
            var financialType = builder.Build();
            var expectedNewName = "NewName";

            // Act
            financialType.ChangeName(expectedNewName);

            // Assert
            financialType.Name.Should().Be(expectedNewName);
        }

        [Fact]
        public void ChangeName_ShouldThrowException_WhenNameIsEmpty()
        {
            // Arrange
            var builder = new FinancialTypeBuilder().WithName("OldName");
            var financialType = builder.Build();

            // Act
            Action act = () => financialType.ChangeName("");

            // Assert
            act.Should().Throw<ArgumentException>()
               .WithMessage("Name cannot be empty*");
        }

        [Fact]
        public void ChangeDirectionType_ShouldChangeTransactionType()
        {
            // Arrange
            var initialTransactionDirection = TransactionDirection.Income;
            var builder = new FinancialTypeBuilder().WithTransactionDirection(initialTransactionDirection);
            var financialType = builder.Build();
            var expectedNewDirection = TransactionDirection.Expense;

            // Act
            financialType.ChangeDirectionType(expectedNewDirection);

            // Assert
            financialType.TransactionType.Should().Be(expectedNewDirection);
        }
    }
}