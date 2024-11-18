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
        public Guid GroupId { get; set; }
        public Guid SubjectId { get; set; }
        public Guid RoomId { get; set; }
        public DateTime DateTime { get; set; }
        public Group Group { get; set; }
        public Subject Subject { get; set; }
        public Room Room { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

    }
}
