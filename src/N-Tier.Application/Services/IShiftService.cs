using N_Tier.Application.Models;
using N_Tier.Application.Models.Exam;
using N_Tier.Application.Models.Shift;

namespace N_Tier.Application.Services;

public interface IShiftService
{
    Task<CreateShiftResponseModel> CreateAsync(CreateShiftModel creatExamModel,
        CancellationToken cancellationToken = default);

    Task<IEnumerable<ShiftResponseModel>>
        GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<UpdateShiftResponseModel> UpdateAsync(Guid id, UpdateShiftModel updateExamModel,
        CancellationToken cancellationToken = default);
}
