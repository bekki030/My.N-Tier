using N_Tier.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Core.Entities
{
    public class Room : BaseEntity, IAuditedEntity
    {
        public string Name { get; set; }
        public int RoomNumber { get; set; }
        public List<Exam> exams { get; set; } = new List<Exam>();
        public List<Lesson> lessons { get; set; } = new List<Lesson>();

        public string? CreatedBy { get ; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set ; }
        public DateTime? UpdatedOn { get; set; }
    }
}
