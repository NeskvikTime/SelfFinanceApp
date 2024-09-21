using AutoMapper;
using FluentAssertions;
using SelfFinanceApp.Application.DailyReport.Queries.GetDailyReport;
using SelfFinanceApp.Application.Mappings;
using SelfFinanceApp.Domain.Requests.FinancialReports;

namespace SelfFinanceApp.Application.Tests.MappingTests
{
    public class DailyReportProfileTests
    {
        private readonly MapperConfiguration _config;

        public DailyReportProfileTests()
        {
            _config = new MapperConfiguration(cfg => cfg.AddMaps(typeof(DailyReportProfile).Assembly));
        }

        [Fact]
        public void ConfigurationIsValid()
        {
            // Act & Assert
            _config.AssertConfigurationIsValid();
        }

        [Fact]
        public void ShouldMapGetDailyReportRequestToGetDailyReportQuery()
        {
            // Arrange
            var mapper = _config.CreateMapper();
            var source = new GetDailyReportRequest()
            {
                FromDate = DateOnly.MinValue,
                ToDate = DateOnly.MaxValue,
                Currency = "USD",
                Page = 1,
                PageSize = 10
            };

            // Act
            var destination = mapper.Map<GetDailyReportQuery>(source);

            // Assert
            destination.Should().BeEquivalentTo(source, options =>
                options.ExcludingMissingMembers()
            );
        }
    }
}
