using N_Tier.Core.Common;

namespace N_Tier.Core.Entities;

public class ExamSession : BaseEntity,IAuditedEntity
{
    public virtual Exam Exam { get; set; }
    public int SessionNumber { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }
}
