using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.Models.Lesson
{
    public class CreateLessonModel
    {
        public Guid SubjectId { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid GroupId { get; set; }
        public DateTime DateTime { get; set; }
    }
    public class CreateLessonResponseModel : BaseResponseModel { }
}
