namespace N_Tier.Application.Models.ExamSession;

public class ExamSessionResponseModel : BaseResponseModel
{
    public int SessionNumber { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}
