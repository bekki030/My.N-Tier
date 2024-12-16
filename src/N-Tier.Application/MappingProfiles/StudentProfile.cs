using AutoMapper;
using N_Tier.Application.Models.Person;
using N_Tier.Application.Models.Student;
using N_Tier.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.MappingProfiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<CreateStudentModel,Student>().ReverseMap();
            CreateMap<UpdateStudentModel,Student>().ReverseMap();
            //CreateMap<Student,StudentResponseModel>().ReverseMap();
            CreateMap<CreatePersonModel,Student>().ReverseMap();
            CreateMap<CreatePersonModel, Person>().ReverseMap();
            CreateMap<Person,CreatePersonModel>().ReverseMap();
            CreateMap<Student, StudentResponseModel>()
                        .ForMember(dest => dest.Person, opt => opt.MapFrom(src => src.Person));

        }
    }
}
