using SelfFinanceApp.Domain.Entities;
using SelfFinanceApp.Domain.Enums;
using SelfFinanceApp.Domain.ValueObjects;

namespace SelfFinanceApp.Tests.Shared.Builders
{
    public class FinancialTypeBuilder
    {
        private string _name = "DefaultName";
        private TransactionDirection _transactionDirection = TransactionDirection.Income;
        private Guid? _id = null;

        public FinancialTypeBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public FinancialTypeBuilder WithTransactionDirection(TransactionDirection transactionDirection)
        {
            _transactionDirection = transactionDirection;
            return this;
        }

        public FinancialTypeBuilder WithId(Guid id)
        {
            _id = id;
            return this;
        }

        public FinancialType Build()
        {
            return new FinancialType(_name, _transactionDirection, _id);
        }

    }
}
