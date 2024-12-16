using AutoMapper;
using N_Tier.Application.Models.Shift;
using N_Tier.Core.Entities;

namespace N_Tier.Application.MappingProfiles;

public class ShiftProfile : Profile
{
    public ShiftProfile()
    {
        CreateMap<CreateShiftModel, Shift>().ReverseMap();
        CreateMap<UpdateShiftModel, Shift>().ReverseMap();
        CreateMap<Shift,ShiftResponseModel>().ReverseMap();
    }
}
