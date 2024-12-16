namespace N_Tier.Application.Models.CheatingReport;

public class UpdateCheatingReportModel
{
    public Guid ExamSessionId { get; set; }
    public Guid StudentId { get; set; }
    public string Description { get; set; }
    public DateTime ReportDate { get; set; }
}
public class UpdateCheatingReportResponseModel : BaseResponseModel { }
