using N_Tier.Application.Models;
using N_Tier.Application.Models.ExamGradingCriteria;

namespace N_Tier.Application.Services;

public interface IExamGradingCriteriaService
{
    Task<CreateExamGradingCriteriaResponseModel> CreateAsync(CreateExamGradingCriteriaModel creatExamGradingCriteriaModel,
CancellationToken cancellationToken = default);

    Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IEnumerable<ExamGradingCriteriaResponseModel>>
        GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<UpdateExamGradingCriteriaResponseModel> UpdateAsync(Guid id, UpdateExamGradingCriteriaModel updateExamGradingCriteriaModel,
        CancellationToken cancellationToken = default);
}
