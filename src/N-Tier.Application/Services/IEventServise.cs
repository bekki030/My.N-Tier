using N_Tier.Application.Models.TodoItem;
using N_Tier.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using N_Tier.Application.Models.Event;

namespace N_Tier.Application.Services
{
    public interface IEventServise
    {
        Task<CreateEventResponseModel> CreateAsync(CreateEventModel createEventModel,
      CancellationToken cancellationToken = default);

        Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

        Task<IEnumerable<EventResponseModel>>
            GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<UpdateEventResponseModel> UpdateAsync(Guid id, UpdateEventModel updateEventModel,
            CancellationToken cancellationToken = default);
    }
}
