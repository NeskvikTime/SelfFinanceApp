using SelfFinanceApp.Domain.Enums;

namespace SelfFinanceApp.Domain.Requests.FinancialTypes;

public record PatchFinancialTypeRequest(string Name, TransactionDirection DirectionType);
