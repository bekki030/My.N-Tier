using N_Tier.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.Models.Diary
{
    public class DiaryResponseModel : BaseResponseModel
    {
        public int Rating { get; set; }
        public DateTime DateTime { get; set; }
        public WeekDayEnum WeekDay { get; set; }
    }
}
