using AutoMapper;
using N_Tier.Application.Models.ExamAnswersheet;
using N_Tier.Core.Entities;

namespace N_Tier.Application.MappingProfiles;

public class ExamAnswersheetProfile : Profile
{
    public ExamAnswersheetProfile()
    {
        CreateMap<CreateExamAnswersheetModel, ExamAnswersheet>().ReverseMap();
        CreateMap<UpdateExamAnswersheetModel, ExamAnswersheet>().ReverseMap();
        CreateMap<ExamAnswersheet, ExamAnswersheetResponseModel>().ReverseMap();
    }
}
