using N_Tier.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Core.Entities
{
    public class Lesson : BaseEntity, IAuditedEntity
    {
        public virtual Subject Subject {  get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Group Group { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string? CreatedBy { get ; set ; }
        public DateTime? CreatedOn { get; set ; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
