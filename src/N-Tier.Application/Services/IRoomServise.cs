using N_Tier.Application.Models.TodoItem;
using N_Tier.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using N_Tier.Application.Models.Room;

namespace N_Tier.Application.Services
{
    public interface IRoomServise
    {
        Task<CreateRoomResponseModel> CreateAsync(CreateRoomModel createRoomModel,
    CancellationToken cancellationToken = default);

        Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

        Task<IEnumerable<RoomResponseModel>>
            GetAllRoomAsync(Guid id, CancellationToken cancellationToken = default);
       
        Task<UpdateRoomResponseModel> UpdateAsync(Guid id, UpdateRoomModel updateRoomModel,
            CancellationToken cancellationToken = default);
    }
}
