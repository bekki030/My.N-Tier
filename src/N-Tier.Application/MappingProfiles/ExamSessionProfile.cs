using AutoMapper;
using N_Tier.Application.Models.ExamSession;
using N_Tier.Core.Entities;

namespace N_Tier.Application.MappingProfiles;

public class ExamSessionProfile : Profile
{
    public ExamSessionProfile()
    {
        CreateMap<CreateExamSessionModel, ExamSession>().ReverseMap();
        CreateMap<UpdateExamSessionModel, ExamSession>().ReverseMap();
        CreateMap<ExamSession, ExamSessionResponseModel>().ReverseMap();
    }
}
