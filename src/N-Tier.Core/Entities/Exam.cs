using N_Tier.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Core.Entities
{
    public class Exam : BaseEntity,IAuditedEntity
    {
        public DateTime Date { get; set; }
        public virtual Group Group { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual Room Room { get; set; }
        public virtual Shift Shift { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

    }
}
