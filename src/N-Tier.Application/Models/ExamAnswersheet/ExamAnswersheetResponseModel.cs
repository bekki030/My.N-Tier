namespace N_Tier.Application.Models.ExamAnswersheet;

public class ExamAnswersheetResponseModel : BaseResponseModel
{
    public DateTime SubmitedDate { get; set; }
    public string FilePath { get; set; }
}
