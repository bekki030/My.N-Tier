using N_Tier.Application.Models.TodoItem;
using N_Tier.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using N_Tier.Application.Models.Diary;

namespace N_Tier.Application.Services
{
    public interface IDiaryServise
    {
        Task<CreateDiaryResponseModel> CreateAsync(CreateDiaryModel createDiaryModel,
      CancellationToken cancellationToken = default);

        Task<IEnumerable<DiaryResponseModel>>
            GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
