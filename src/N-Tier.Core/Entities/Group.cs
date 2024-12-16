using N_Tier.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Core.Entities
{
    public class Group : BaseEntity, IAuditedEntity
    {
        public string Name { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
        public List<Lesson> Lessons { get; set; } = new List<Lesson>();
        public List<Exam> Exam { get; set; } = new List<Exam>();
        public string? CreatedBy { get ; set; }
        public DateTime? CreatedOn { get; set ; }
        public string? UpdatedBy { get ; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
