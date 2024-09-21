using MediatR;

namespace SelfFinanceApp.Domain.Contracts.Requests
{
    public interface IValidatableRequest<out TResponse> : IRequest<TResponse>, IValidatableRequest
    { }

    public interface IValidatableRequest
    { }
}
