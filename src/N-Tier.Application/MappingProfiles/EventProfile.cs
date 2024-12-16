using AutoMapper;
using N_Tier.Application.Models.Event;
using N_Tier.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.MappingProfiles
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<CreateEventModel,Event>().ReverseMap();
            CreateMap<UpdateEventModel,Event>().ReverseMap();
            CreateMap<Event,EventResponseModel>().ReverseMap();
        }
    }
}
