using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.Models.Exam
{
    public class CreateExamModel
    {
        public Guid GroupId { get; set; }
        public Guid SubjectId { get; set; }
        public Guid RoomId { get; set; }
        public DateTime DateTime { get; set; }
    }
    public class CreateExamResponseModel : BaseResponseModel { }
}
