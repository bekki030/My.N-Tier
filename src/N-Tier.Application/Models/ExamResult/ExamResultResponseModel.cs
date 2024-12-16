using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.Models.ExamResult;

public class ExamResultResponseModel : BaseResponseModel
{
    public int Ball { get; set; }
    public string Grade { get; set; }
}
