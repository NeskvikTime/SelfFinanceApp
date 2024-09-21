using AutoMapper;
using SelfFinanceApp.Application.FinancialOperations.Queries.GetManyFinancialFinancialOperations;
using SelfFinanceApp.Domain.Requests.FinancialOperations;

namespace SelfFinanceApp.Application.Mappings
{
    public class FinancialOperationProfile : Profile
    {
        public FinancialOperationProfile()
        {
            CreateMap<GetManyFinancialOperationsRequest, GetManyFinancialOperationsQuery>()
                .ForMember(dest => dest.SortField, opt => opt.MapFrom(src => src.SortField))
                .ForMember(dest => dest.Page, opt => opt.MapFrom(src => src.Page))
                .ForMember(dest => dest.PageSize, opt => opt.MapFrom(src => src.PageSize))
                .ForMember(dest => dest.FromDate, opt => opt.MapFrom(src => src.FromDate))
                .ForMember(dest => dest.ToDate, opt => opt.MapFrom(src => src.ToDate))
                .ForMember(dest => dest.SortOrder, opt => opt.MapFrom(src => src.SortOrder))
                .ForMember(dest => dest.DirectionType, opt => opt.MapFrom(src => src.DirectionType));
        }
    }
}
