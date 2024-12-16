using AutoMapper;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Group;
using N_Tier.Core.Entities;
using N_Tier.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.Services.Impl
{
    public class GroupServise : IGroupServise
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IMapper _mapper;
        public GroupServise(IMapper mapper,IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
            _mapper = mapper;
        }

        public async Task<CreateGroupResponseModel> CreateAsync(CreateGroupModel createGroupModel, CancellationToken cancellationToken = default)
        {
            var group = _mapper.Map<Group>(createGroupModel);
            return new CreateGroupResponseModel
            {
                Id = (await _groupRepository.AddAsync(group)).Id,
            };
        }

        public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var group = await _groupRepository.GetFirstAsync(x => x.Id == id);
            return new BaseResponseModel
            {
                Id = (await _groupRepository.DeleteAsync(group)).Id,
            };
        }

        public async Task<IEnumerable<GroupResponseModel>> GetAllGroupAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var group = await _groupRepository.GetAllAsync(x => x.Id == id);
            return _mapper.Map<IEnumerable<GroupResponseModel>>(group);
        }

        public async Task<UpdateGroupResponseModel> UpdateAsync(Guid id, UpdateGroupModel updateGroupModel, CancellationToken cancellationToken = default)
        {
            var group = await _groupRepository.GetFirstAsync(x=> x.Id == id);  
            _mapper.Map(group, updateGroupModel);
            return new UpdateGroupResponseModel
            {
                Id = (await _groupRepository.UpdateAsync(group)).Id,
            };
        }
    }
}
