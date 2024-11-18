using N_Tier.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.Models.Diary
{
    internal class UpdateDiaryModel
    {
        public Guid StudentId { get; set; }
        public Guid SubjectId { get; set; }
        public int Rating { get; set; }
        public DateTime DateTime { get; set; }
        public WeekDayEnum WeekDay { get; set; }
    }
    public class UpdateDiaryResponseModel : BaseResponseModel { }
}
