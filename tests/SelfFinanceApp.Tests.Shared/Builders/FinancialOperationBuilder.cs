using SelfFinanceApp.Domain.Entities;
using SelfFinanceApp.Domain.Enums;
using SelfFinanceApp.Domain.Aggregates;
using SelfFinanceApp.Domain.ValueObjects;

namespace SelfFinanceApp.Tests.Shared.Builders
{
    public class FinancialOperationBuilder
    {
        private string _name = "DefaultOperation";
        private MonetaryValue _money = new MonetaryValue(100, "USD");
        private FinancialType? _financeType = null;
        private Guid _financeTypeId;
        private Guid? _id = null;
        private TransactionDirection _transactionDirection = TransactionDirection.Income; 

        public FinancialOperationBuilder WithMoney(MonetaryValue money)
        {
            _money = money;
            return this;
        }

        public FinancialOperationBuilder WithTransactionDirection(TransactionDirection direction)
        {
            _transactionDirection = direction;
            return this;
        }

        public FinancialOperationBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public FinancialOperationBuilder WithMonetaryValue(MonetaryValue money)
        {
            _money = money;
            return this;
        }

        public FinancialOperationBuilder WithFinancialType(FinancialType financialType)
        {
            _financeType = financialType;
            _financeTypeId = financialType.Id;
            return this;
        }

        public FinancialOperationBuilder WithId(Guid id)
        {
            _id = id;
            return this;
        }

        public FinancialOperation Build()
        {
            var operation = new FinancialOperation(_name, _money, _financeTypeId, _id);

            if (_financeType is not null)
            {
                operation.FinanceType = _financeType;
                _financeTypeId = _financeType.Id;
            }

            return operation;
        }
    }
}
