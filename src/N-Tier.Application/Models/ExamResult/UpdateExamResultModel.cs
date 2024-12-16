namespace N_Tier.Application.Models.ExamResult;

public class UpdateExamResultModel
{
    public Guid ExamId { get; set; }
    public Guid StudentId { get; set; }
    public int Ball { get; set; }
    public string Grade { get; set; }
}
public class UpdateExamResultResponseModel : BaseResponseModel { }
