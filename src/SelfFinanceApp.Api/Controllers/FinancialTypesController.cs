using Asp.Versioning;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SelfFinanceApp.Api.Common;
using SelfFinanceApp.Application.FinancialType.Commands.Create;
using SelfFinanceApp.Application.FinancialType.Commands.Delete;
using SelfFinanceApp.Application.FinancialType.Commands.Patch;
using SelfFinanceApp.Application.FinancialType.Commands.Update;
using SelfFinanceApp.Application.FinancialType.Queries.GetAllFinancialTypes;
using SelfFinanceApp.Application.FinancialType.Queries.GetFinanceType;
using SelfFinanceApp.Domain.Requests.FinancialTypes;
using SelfFinanceApp.Domain.Responses.FinancialTypes;

namespace SelfFinanceApp.Api.Controllers;

[ApiVersion(1.0)]
public class FinancialTypesController : ApiController
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public FinancialTypesController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet(ApiEndpoints.FinancialTypes.Get)]
    [ProducesResponseType(typeof(GetFinancialTypeResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAsync([FromRoute] Guid id, CancellationToken token)
    {
        var result = await _sender.Send(new GetFinancialTypeQuery(id), token);

        return result.Match(type => Ok(_mapper.Map<GetFinancialTypeResponse>(type)), Problem);
    }

    [HttpGet(ApiEndpoints.FinancialTypes.GetAll)]
    [ProducesResponseType(typeof(List<GetFinancialTypeResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllAsync(CancellationToken token)
    {
        var result = await _sender.Send(new GetAllFinancialTypesQuery(), token);

        return result.Match(financialTypes => Ok(financialTypes.ConvertAll(financialType
            => new GetFinancialTypeResponse(financialType.Id, financialType.Name, financialType.TransactionType))),
            Problem);
    }

    [HttpPost(ApiEndpoints.FinancialTypes.Create)]
    [ProducesResponseType(typeof(CreateFinancialTypeResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateAsync([FromBody] CreateFinancialTypeRequest request, CancellationToken token)
    {
        var command = new CreateFinancialTypeCommand(request.Name, request.TransactionType);
        var result = await _sender.Send(command, token);

        return result.Match(type => Created(ApiEndpoints.FinancialTypes.Create, _mapper.Map<CreateFinancialTypeResponse>(type)), Problem);
    }

    [HttpPut(ApiEndpoints.FinancialTypes.Update)]
    [ProducesResponseType(typeof(UpdateFinancialTypeResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateFinancialTypeRequest request, CancellationToken token)
    {
        var result = await _sender.Send(new UpdateFinancialTypeCommand(id, request.Name, request.TransactionType), token);

        return result.Match(type => Ok(_mapper.Map<UpdateFinancialTypeResponse>(type)), Problem);
    }

    [HttpDelete(ApiEndpoints.FinancialTypes.Delete)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id, CancellationToken token)
    {
        var result = await _sender.Send(new DeleteFinancialTypeCommand(id), token);

        return result.Match(_ => NoContent(), Problem);
    }

    [HttpPatch(ApiEndpoints.FinancialTypes.Patch)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> PatchAsync(
        [FromRoute] Guid id,
        [FromBody] JsonPatchDocument<PatchFinancialTypeRequest> request,
        CancellationToken token)
    {
        var result = await _sender.Send(new PatchFinancialTypeCommand(id, request), token);

        return result.Match(type => Ok(_mapper.Map<UpdateFinancialTypeResponse>(type)), Problem);
    }
}
