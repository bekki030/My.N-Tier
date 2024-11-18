using N_Tier.Core.Common;
using N_Tier.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Core.Entities
{
    public class Employee : BaseEntity, IAuditedEntity
    {
        public Guid PersonId { get; set; }
        public Person Person { get; set; }
        public PositionEnum Position { get; set; }
        public List<Lesson> lessons { get; set; } = new List<Lesson>();
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
