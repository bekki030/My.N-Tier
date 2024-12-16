using AutoMapper;
using N_Tier.Application.Models.Room;
using N_Tier.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.MappingProfiles
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<CreateRoomModel,Room>().ReverseMap();
            CreateMap<UpdateRoomModel,Room>().ReverseMap();
            CreateMap<Room,RoomResponseModel>().ReverseMap();
        }
    }
}
