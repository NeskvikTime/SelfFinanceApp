using Asp.Versioning;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SelfFinanceApp.Api.Common;
using SelfFinanceApp.Application.FinancialOperations.Commands.Create;
using SelfFinanceApp.Application.FinancialOperations.Commands.Delete;
using SelfFinanceApp.Application.FinancialOperations.Commands.Update;
using SelfFinanceApp.Application.FinancialOperations.Queries.GetFinancialOperation;
using SelfFinanceApp.Application.FinancialOperations.Queries.GetManyFinancialFinancialOperations;
using SelfFinanceApp.Domain.Pages;
using SelfFinanceApp.Domain.Requests.FinancialOperations;
using SelfFinanceApp.Domain.Responses.FinancialOperations;

namespace SelfFinanceApp.Api.Controllers;

[ApiVersion(1.0)]
public class FinancialOperationsController : ApiController
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public FinancialOperationsController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet(ApiEndpoints.FinancialOperations.Get)]
    [ProducesResponseType(typeof(GetFinancialOperationResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAsync([FromRoute] Guid id, CancellationToken token)
    {
        var result = await _sender.Send(new GetFinancialOperationQuery(id), token);

        return result.Match(operation => Ok(new GetFinancialOperationResponse(
                    operation.Id,
                    operation.Name,
                    operation.Money.Amount,
                    operation.Money.Currency,
                    operation.FinanceTypeId,
                    operation.FinanceType.Name,
                    DateOnly.FromDateTime(operation.DateCreated),
                    operation.FinanceType.TransactionType)), Problem);
    }

    [HttpGet(ApiEndpoints.FinancialOperations.GetMany)]
    [ProducesResponseType(typeof(PagedResult<GetFinancialOperationResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetManyAsync([FromQuery] GetManyFinancialOperationsRequest request, CancellationToken token)
    {
        GetManyFinancialOperationsQuery query = _mapper.Map<GetManyFinancialOperationsQuery>(request);

        var response = await _sender.Send(query, token);

        return response.Match(Ok, Problem);
    }

    [HttpPost(ApiEndpoints.FinancialOperations.Create)]
    [ProducesResponseType(typeof(CreateFinancialOperationResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateAsync([FromBody] CreateFinancialOperationRequest request, CancellationToken token)
    {
        var command = new CreateFinancialOperationCommand(
            request.Name,
            request.Amount,
            request.Currency,
            request.FinancialTypeId);

        var result = await _sender.Send(command, token);

        return result.Match(operation => Created(ApiEndpoints.FinancialTypes.Create, new CreateFinancialOperationResponse(
            operation.Id,
            operation.Name,
            operation.Money.Amount.ToString(),
            operation.Money.Currency,
            operation.FinanceType.Id,
            operation.FinanceType.Name,
            operation.DateCreated,
            operation.FinanceType.TransactionType)), Problem);
    }

    [HttpPut(ApiEndpoints.FinancialOperations.Update)]
    [ProducesResponseType(typeof(UpdateFinancialOperationResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateFinancialOperationRequest request, CancellationToken token)
    {
        var result = await _sender.Send(new UpdateFinancialOperationCommand(
            id,
            request.Name,
            request.Amount,
            request.Currency,
            request.FinanceTypeId), token);

        return result.Match(operation => Ok(new UpdateFinancialOperationResponse(
            operation.Id,
            operation.Name,
            operation.Money.Amount,
            operation.Money.Currency,
            operation.FinanceType.Id,
            operation.FinanceType.Name,
            DateOnly.FromDateTime(operation.DateCreated),
            operation.FinanceType.TransactionType)), Problem);
    }

    [HttpDelete(ApiEndpoints.FinancialOperations.Delete)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id, CancellationToken token)
    {
        var result = await _sender.Send(new DeleteFinancialOperationCommand(id), token);

        return result.Match(_ => NoContent(), Problem);
    }
}
