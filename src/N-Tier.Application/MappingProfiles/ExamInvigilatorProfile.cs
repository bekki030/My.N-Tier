using AutoMapper;
using N_Tier.Application.Models.ExamInvigilator;
using N_Tier.Core.Entities;

namespace N_Tier.Application.MappingProfiles;

public class ExamInvigilatorProfile : Profile
{
    public ExamInvigilatorProfile()
    {
        CreateMap<CreateExamInvigilatorModel, ExamInvigilator>().ReverseMap();
        CreateMap<UpdateExamInvigilatorModel, ExamInvigilator>().ReverseMap();
        CreateMap<ExamInvigilator, ExamInvigilatorResponseModel>().ReverseMap();
    }
}
