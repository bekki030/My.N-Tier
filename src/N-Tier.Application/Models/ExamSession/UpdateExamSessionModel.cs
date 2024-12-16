namespace N_Tier.Application.Models.ExamSession;

public class UpdateExamSessionModel
{
    public Guid ExamId { get; set; }
    public int SessionNumber { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}
public class UpdateExamSessionResponseModel : BaseResponseModel { }
