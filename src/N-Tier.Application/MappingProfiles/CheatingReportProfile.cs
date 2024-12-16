using AutoMapper;
using N_Tier.Application.Models.CheatingReport;
using N_Tier.Core.Entities;

namespace N_Tier.Application.MappingProfiles;

public class CheatingReportProfile : Profile
{
    public CheatingReportProfile()
    {
        CreateMap<CreateCheatingReportModel, CheatingReport>().ReverseMap();
        CreateMap<UpdateCheatingReportModel, CheatingReport>().ReverseMap();
        CreateMap<CheatingReport,CheatingReportResponseModel>().ReverseMap();
    }
}
