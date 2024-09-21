using AutoMapper;
using SelfFinanceApp.Domain.Responses.FinancialTypes;
using DomainEntities = SelfFinanceApp.Domain.Entities;

namespace SelfFinanceApp.Application.Mappings;

public class FinanceTypeProfile : Profile
{
    public FinanceTypeProfile()
    {
        CreateMap<DomainEntities.FinancialType, CreateFinancialTypeResponse>();

        CreateMap<DomainEntities.FinancialType, GetFinancialTypeResponse>();

        CreateMap<DomainEntities.FinancialType, UpdateFinancialTypeResponse>();
    }
}
