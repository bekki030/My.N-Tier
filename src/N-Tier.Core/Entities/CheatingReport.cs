using N_Tier.Core.Common;

namespace N_Tier.Core.Entities;

public class CheatingReport:BaseEntity,IAuditedEntity
{
    public virtual ExamSession Session { get; set; }
    public virtual Student Student { get; set; }
    public string Description { get; set; }
    public DateTime ReportDate { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }
}
