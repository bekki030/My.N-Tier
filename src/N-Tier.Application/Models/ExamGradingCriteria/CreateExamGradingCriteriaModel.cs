namespace N_Tier.Application.Models.ExamGradingCriteria;

public class CreateExamGradingCriteriaModel
{
    public Guid ExamId { get; set; }
    public int MinBall { get; set; }
    public int MaxBall { get; set; }
    public string Grade { get; set; }
}
public class CreateExamGradingCriteriaResponseModel : BaseResponseModel { }
