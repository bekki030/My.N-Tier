namespace N_Tier.Application.Models.Attendance;

public class CreateAttendanceModel
{
    public Guid LessonId { get; set; }
    public bool IsPresent { get; set; }
}
public class CreateAttendanseResponseModel : BaseResponseModel { }
