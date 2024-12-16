using N_Tier.Application.Models.Exam;
using N_Tier.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using N_Tier.Application.Models.ExamInvigilator;

namespace N_Tier.Application.Services;

public interface IExamInvigilatorService
{
    Task<CreateExamInvigilatorResponseModel> CreateAsync(CreateExamInvigilatorModel creatExamInvigilatorModel,
CancellationToken cancellationToken = default);

    Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IEnumerable<ExamInvigilatorResponseModel>>
        GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<UpdateExamInvigilatorResponseModel> UpdateAsync(Guid id, UpdateExamInvigilatorModel updateExamInvigilatorModel,
        CancellationToken cancellationToken = default);
}
