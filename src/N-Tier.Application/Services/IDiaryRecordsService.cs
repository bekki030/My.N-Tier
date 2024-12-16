using N_Tier.Application.Models.Exam;
using N_Tier.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using N_Tier.Application.Models.DiaryRecords;

namespace N_Tier.Application.Services
{
    public interface IDiaryRecordsService
    {
        Task<CreateDiaryRecordsResponseModel> CreateAsync(CreateDiaryRecordsModel creatDiaryRecordsModel,
CancellationToken cancellationToken = default);

        Task<IEnumerable<DiaryRecordsResponseModel>>
            GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
