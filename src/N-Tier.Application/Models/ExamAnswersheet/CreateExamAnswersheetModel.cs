using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.Models.ExamAnswersheet;

public class CreateExamAnswersheetModel
{
    public Guid ExamSessionId { get; set; }
    public Guid StudentId { get; set; }
    public DateTime SubmitedDate { get; set; }
    public string FilePath { get; set; }
}
public class CreateExamAnswersheetResponseModel : BaseResponseModel { }
