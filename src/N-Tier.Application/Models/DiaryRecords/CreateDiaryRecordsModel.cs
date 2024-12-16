using N_Tier.Core.Enums;

namespace N_Tier.Application.Models.DiaryRecords;

public class CreateDiaryRecordsModel
{
    public Guid DiaryId { get; set; }
    public Guid SubjectId { get; set; }
    public WeekDayEnum WeekDay { get; set; }
    public DateTime Date { get; set; }
    public int Rating { get; set; }
}
public class CreateDiaryRecordsResponseModel : BaseResponseModel { }