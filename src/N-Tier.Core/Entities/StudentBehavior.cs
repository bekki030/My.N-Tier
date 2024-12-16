using N_Tier.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Core.Entities
{
    public class StudentBehavior : BaseEntity,IAuditedEntity
    {
        public virtual Student Student { get; set; }
        public virtual Employee Employee { get; set; }
        public DateTime Date { get; set; }  
        public string Description { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
