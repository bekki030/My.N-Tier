using N_Tier.Application.Models.TodoItem;
using N_Tier.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using N_Tier.Application.Models.Subject;

namespace N_Tier.Application.Services
{
    public interface ISubjectServise
    {
        Task<CreateSubjectResponseModel> CreateAsync(CreateSubjectModel createSubjectModel,
      CancellationToken cancellationToken = default);

        Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

        Task<IEnumerable<SubjectResponseModel>>
            GetAllSubjectAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
