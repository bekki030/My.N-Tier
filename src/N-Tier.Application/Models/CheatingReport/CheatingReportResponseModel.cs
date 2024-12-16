namespace N_Tier.Application.Models.CheatingReport;

public class CheatingReportResponseModel : BaseResponseModel
{
    public string Description { get; set; }
    public DateTime ReportDate { get; set; }
}
