using AutoMapper;
using N_Tier.Application.Models.Subject;
using N_Tier.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.MappingProfiles
{
    public class SubjectProfile : Profile
    {
        public SubjectProfile()
        {
            CreateMap<CreateSubjectModel,Subject>().ReverseMap();
            CreateMap<UpdateSubjectModel,Subject>().ReverseMap();
            CreateMap<Subject,SubjectResponseModel>().ReverseMap();
        }
    }
}
