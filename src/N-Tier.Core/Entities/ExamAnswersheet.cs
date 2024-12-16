using N_Tier.Core.Common;

namespace N_Tier.Core.Entities;

public class ExamAnswersheet:BaseEntity,IAuditedEntity
{
    public virtual ExamSession Session { get; set; }
    public virtual Student Student { get; set; }
    public DateTime SubmittedDate { get; set; }
    public string FilePath { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }
}
