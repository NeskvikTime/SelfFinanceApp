using SelfFinanceApp.Domain.Requests.FinancialTypes;
using SelfFinanceApp.Domain.Responses.FinancialTypes;

namespace SelfFinanceApp.Domain.Contracts.PageServices
{
    public interface IFinancialTypePageService
    {
        Task<List<GetFinancialTypeResponse>> GetAllAsync(CancellationToken token);

        Task<GetFinancialTypeResponse> GetByIdAsync(Guid id, CancellationToken token);

        Task<GetFinancialTypeResponse> CreateAsync(CreateFinancialTypeRequest request, CancellationToken token);

        Task<GetFinancialTypeResponse> UpdateAsync(Guid id, UpdateFinancialTypeRequest request, CancellationToken token);

        Task DeleteAsync(Guid id, CancellationToken token);
    }
}
