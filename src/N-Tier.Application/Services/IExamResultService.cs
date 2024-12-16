using N_Tier.Application.Models;
using N_Tier.Application.Models.Exam;
using N_Tier.Application.Models.ExamResult;

namespace N_Tier.Application.Services;

public interface IExamResultService
{
    Task<CreateExamResultResponseModel> CreateAsync(CreateExamResultModel creatExamResultModel,
CancellationToken cancellationToken = default);

    Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IEnumerable<ExamResultResponseModel>>
        GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default);
}
