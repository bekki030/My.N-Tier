namespace N_Tier.Application.Models.CheatingReport;

public class CreateCheatingReportModel
{
    public Guid ExamSessionId { get; set; }
    public Guid StudentId { get; set; }
    public string Description { get; set; }
    public DateTime ReportDate { get; set; }
}
public class CreateCheatingReportResponseModel : BaseResponseModel { }
