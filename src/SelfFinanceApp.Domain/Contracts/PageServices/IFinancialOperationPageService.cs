using SelfFinanceApp.Domain.Pages;
using SelfFinanceApp.Domain.Requests.FinancialOperations;
using SelfFinanceApp.Domain.Responses.FinancialOperations;

namespace SelfFinanceApp.Domain.Contracts.PageServices
{
    public interface IFinancialOperationPageService
    {
        Task<PagedResult<GetFinancialOperationResponse>> GetManyAsync(int currentPage, CancellationToken token);

        Task<GetFinancialOperationResponse> GetByIdAsync(Guid id, CancellationToken token);

        Task<GetFinancialOperationResponse> CreateAsync(CreateFinancialOperationRequest request, CancellationToken token);

        Task<UpdateFinancialOperationResponse> UpdateAsync(Guid id, UpdateFinancialOperationRequest request, CancellationToken token);

        Task DeleteAsync(Guid id, CancellationToken token);
    }
}
