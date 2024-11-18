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
        public Guid SubjectId {  get; set; }
        public Guid EmployeeId { get; set; }
        public Guid GroupId { get; set; }
        public DateTime DateTime { get; set; }
        public string? CreatedBy { get ; set ; }
        public DateTime? CreatedOn { get; set ; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
