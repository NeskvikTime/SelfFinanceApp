using AutoMapper;
using SelfFinanceApp.Application.DailyReport.Queries.GetDailyReport;
using SelfFinanceApp.Domain.Requests.FinancialReports;

namespace SelfFinanceApp.Application.Mappings
{
    public class DailyReportProfile : Profile
    {
        public DailyReportProfile()
        {
            CreateMap<GetDailyReportRequest, GetDailyReportQuery>();
        }
    }
}
