using N_Tier.Application.Models;
using N_Tier.Application.Models.Student;

namespace N_Tier.Application.Services
{
    public interface IStudentServise
    {
        Task<CreateStudentResponseModel> CreateAsync(CreateStudentModel createStudentModel,
      CancellationToken cancellationToken = default);

        Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

        Task<IEnumerable<StudentResponseModel>>
            GetAllStudentAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
