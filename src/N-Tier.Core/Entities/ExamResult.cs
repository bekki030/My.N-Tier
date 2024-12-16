using N_Tier.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Core.Entities;

public class ExamResult :BaseEntity, IAuditedEntity
{
    public virtual Exam Exam { get; set; }
    public virtual Student Student { get; set; }
    public int  Ball { get; set; }
    public string Grade { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }
}
