using AutoMapper;
using N_Tier.Application.Models.DiaryRecords;
using N_Tier.Core.Entities;

namespace N_Tier.Application.MappingProfiles;

public class DiaryRecordsProfile : Profile
{
    public DiaryRecordsProfile()
    {
        CreateMap<CreateDiaryRecordsModel, DiaryRecords>().ReverseMap();
        CreateMap<UpdateDiaryRecordsModel, DiaryRecords>().ReverseMap();
        CreateMap<DiaryRecords, DiaryRecordsResponseModel>().ReverseMap();
    }
}
