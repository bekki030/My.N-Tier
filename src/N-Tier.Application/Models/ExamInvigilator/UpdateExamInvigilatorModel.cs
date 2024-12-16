namespace N_Tier.Application.Models.ExamInvigilator;

public class UpdateExamInvigilatorModel
{
    public Guid ExamId { get; set; }
    public Guid EmployeeId { get; set; }
    public DateTime AssignedDate { get; set; }
}
public class UpdateExamInvigilatorResponseModel : BaseResponseModel { }
