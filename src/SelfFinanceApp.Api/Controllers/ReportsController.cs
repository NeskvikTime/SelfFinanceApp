using Asp.Versioning;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SelfFinanceApp.Api.Common;
using SelfFinanceApp.Application.DailyReport.Queries.GetDailyReport;
using SelfFinanceApp.Domain.Requests.FinancialReports;
using SelfFinanceApp.Domain.Responses.FinancialOperations;

namespace SelfFinanceApp.Api.Controllers
{
    [ApiVersion(1.0)]
    public class ReportsController : ApiController
    {
        private readonly ISender _sender;
        private readonly IMapper _mapper;

        public ReportsController(ISender sender, IMapper mapper)
        {
            _sender = sender;
            _mapper = mapper;
        }

        [HttpGet(ApiEndpoints.Reports.GetMany)]
        [ProducesResponseType(typeof(GetFinancialReportResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDailyReport([FromQuery] GetDailyReportRequest request, CancellationToken token)
        {
            GetDailyReportQuery query = _mapper.Map<GetDailyReportQuery>(request);

            var result = await _sender.Send(query, token);

            GetFinancialReportResponse report = new GetFinancialReportResponse(
                request.FromDate,
                request.ToDate,
                result.Value.TotalIncome,
                result.Value.TotalExpenses,
                result.Value.Operations);

            return result.Match(result => Ok(report), Problem);
        }
    }
}
