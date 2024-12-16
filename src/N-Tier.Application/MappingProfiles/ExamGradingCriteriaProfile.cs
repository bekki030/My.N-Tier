using AutoMapper;
using N_Tier.Application.Models.ExamGradingCriteria;
using N_Tier.Core.Entities;

namespace N_Tier.Application.MappingProfiles;

public class ExamGradingCriteriaProfile : Profile
{
    public ExamGradingCriteriaProfile()
    {
        CreateMap<CreateExamGradingCriteriaModel, ExamGradingCriteria>().ReverseMap();
        CreateMap<UpdateExamGradingCriteriaModel, ExamGradingCriteria>().ReverseMap();
        CreateMap<ExamGradingCriteria, ExamGradingCriteriaResponseModel>().ReverseMap();
    }
}
