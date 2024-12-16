using N_Tier.Application.Models;
using N_Tier.Application.Models.StudentBehavior;

namespace N_Tier.Application.Services;

public interface IStudentBehaviorService
{
    Task<CreateStudentBehaviorResponseModel> CreateAsync(CreateStudentBehaviorModel createStudentbehaviorModel,
CancellationToken cancellationToken = default);

    Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IEnumerable<StudentBehaviorResponseModel>>
        GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<UpdateStudentBehaviorResponseModel> UpdateAsync(Guid id, UpdateStudentBehaviorModel updateStudentbehaviorModel,
        CancellationToken cancellationToken = default);
}
