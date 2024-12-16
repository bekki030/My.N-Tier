using N_Tier.Application.Models.Subject;
using N_Tier.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using N_Tier.Application.Models.Group;
using N_Tier.Application.Models.TodoItem;

namespace N_Tier.Application.Services
{
    public interface IGroupServise
    {
        Task<CreateGroupResponseModel> CreateAsync(CreateGroupModel createGroupModel,
CancellationToken cancellationToken = default);

        Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

        Task<IEnumerable<GroupResponseModel>>
            GetAllGroupAsync(Guid id, CancellationToken cancellationToken = default);
        Task<UpdateGroupResponseModel> UpdateAsync(Guid id, UpdateGroupModel updateGroupModel,
       CancellationToken cancellationToken = default);
    }
}
