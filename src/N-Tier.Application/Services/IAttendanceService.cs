using N_Tier.Application.Models;
using N_Tier.Application.Models.Attendance;
using N_Tier.Application.Models.Exam;

namespace N_Tier.Application.Services;

public interface IAttendanceService
{
    Task<CreateAttendanseResponseModel> CreateAsync(CreateAttendanceModel createAttendanceModel,
CancellationToken cancellationToken = default);

    Task<IEnumerable<AttendanceResponseModel>>
        GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<UpdateAttendanceResponseModel> UpdateAsync(Guid id, UpdateAttendanceModel updateExamModel,
        CancellationToken cancellationToken = default);
}
