using AutoMapper;
using N_Tier.Application.Models.Exam;
using N_Tier.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.MappingProfiles
{
    public class ExamProfile : Profile
    {
        public ExamProfile()
        {
            CreateMap<CreateExamModel,Exam>().ReverseMap();
            CreateMap<UpdateExamModel,Exam>().ReverseMap();
            CreateMap<Exam,ExamResponseModel>().ReverseMap();
        }
    }
}
