using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.Models.ExamGradingCriteria;

public class ExamGradingCriteriaResponseModel : BaseResponseModel
{
    public int MinBall { get; set; }
    public int MaxBall { get; set; }
    public string Grade { get; set; }
}
