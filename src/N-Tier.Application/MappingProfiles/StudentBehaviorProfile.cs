using AutoMapper;
using N_Tier.Application.Models.StudentBehavior;

namespace N_Tier.Application.MappingProfiles;

public class StudentBehaviorProfile : Profile
{
    public StudentBehaviorProfile()
    {
        CreateMap<CreateStudentBehaviorModel, StudentProfile>().ReverseMap();
        CreateMap<UpdateStudentBehaviorModel, StudentProfile>().ReverseMap();
        CreateMap<StudentProfile, StudentBehaviorResponseModel>().ReverseMap();
    }
}
