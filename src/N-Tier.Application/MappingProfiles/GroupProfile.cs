using AutoMapper;
using N_Tier.Application.Models.Group;
using N_Tier.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.MappingProfiles
{
    public class GroupProfile : Profile
    {
        public GroupProfile()
        {
            CreateMap<CreateGroupModel,Group>().ReverseMap();
            CreateMap<UpdateGroupModel,Group>().ReverseMap();
            CreateMap<Group,GroupResponseModel>().ReverseMap();
        }
    }
}
