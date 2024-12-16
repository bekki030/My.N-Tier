using N_Tier.Core.Common;
using N_Tier.Core.Enums;

namespace N_Tier.Core.Entities;

public class DiaryRecords : BaseEntity,IAuditedEntity
{
    public virtual Diary Diary { get; set; }
    public virtual Subject Subject { get; set; }
    public WeekDayEnum WeekDay { get; set; }
    public DateTime Date { get; set; }
    public int Rating { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }
}
