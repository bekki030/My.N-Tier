namespace N_Tier.Application.Models.Attendance;

public class UpdateAttendanceModel
{
    public Guid LessonId { get; set; }
    public bool IsPresent { get; set; }
}
public class UpdateAttendanceResponseModel : BaseResponseModel { }
