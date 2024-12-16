using N_Tier.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.Models.DiaryRecords;

public class DiaryRecordsResponseModel : BaseResponseModel
{
    public WeekDayEnum WeekDay { get; set; }
    public DateTime Date { get; set; }
    public int Rating { get; set; }
}
