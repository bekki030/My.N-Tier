namespace N_Tier.Application.Models.StudentBehavior;

public class UpdateStudentBehaviorModel
{
    public Guid StudentId { get; set; }
    public Guid EmployeeId { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }
}
public class UpdateStudentBehaviorResponseModel : BaseResponseModel { }
