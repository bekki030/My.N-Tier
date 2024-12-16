using N_Tier.Application.Models.ExamSession;

namespace N_Tier.Application.Services;

public interface IExamSessionService
{
    Task<CreateExamSessionResponseModel> CreateAsync(CreateExamSessionModel creatExamSessionModel,
CancellationToken cancellationToken = default);


    Task<IEnumerable<ExamSessionResponseModel>>
        GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default);
}
