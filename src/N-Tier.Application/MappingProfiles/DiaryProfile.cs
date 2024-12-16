using AutoMapper;
using N_Tier.Application.Models.Diary;
using N_Tier.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.MappingProfiles
{
    public class DiaryProfile : Profile
    {
        public DiaryProfile()
        {
            CreateMap<CreateDiaryModel, Diary>().ReverseMap();
            CreateMap<UpdateDiaryModel, Diary>().ReverseMap();
            CreateMap<Diary,DiaryResponseModel>().ReverseMap();

        }
    }
}
