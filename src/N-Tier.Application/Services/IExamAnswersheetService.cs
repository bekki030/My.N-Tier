using N_Tier.Application.Models;
using N_Tier.Application.Models.ExamAnswersheet;

namespace N_Tier.Application.Services
{
    public interface IExamAnswersheetService
    {
        Task<CreateExamAnswersheetResponseModel> CreateAsync(CreateExamAnswersheetModel creatExamAnswerModel,
CancellationToken cancellationToken = default);

        Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

        Task<IEnumerable<ExamAnswersheetResponseModel>>
            GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<UpdateExamAnswersheetResposeModel> UpdateAsync(Guid id, UpdateExamAnswersheetModel updateExamansqwerModel,
            CancellationToken cancellationToken = default);
    }
}
