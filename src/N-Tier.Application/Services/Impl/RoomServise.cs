using AutoMapper;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Room;
using N_Tier.Core.Entities;
using N_Tier.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.Services.Impl
{
    public class RoomServise:IRoomServise
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;
        public RoomServise(IRoomRepository roomRepository,IMapper mapper)
        {
            _mapper = mapper;
            _roomRepository = roomRepository;
        }

        public async Task<CreateRoomResponseModel> CreateAsync(CreateRoomModel createRoomModel, CancellationToken cancellationToken = default)
        {
            var room = _mapper.Map<Room>(createRoomModel);
            return new CreateRoomResponseModel
            {
                Id = (await _roomRepository.AddAsync(room)).Id,
            };
        }

        public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var room = await _roomRepository.GetFirstAsync(x => x.Id == id);
            return new BaseResponseModel
            {
                Id = (await _roomRepository.DeleteAsync(room)).Id,
            };
        }

        public async Task<IEnumerable<RoomResponseModel>> GetAllRoomAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var room = await _roomRepository.GetAllAsync(x => x.Id == id);
            return _mapper.Map<IEnumerable<RoomResponseModel>>(room);
        }

        public async Task<UpdateRoomResponseModel> UpdateAsync(Guid id, UpdateRoomModel updateRoomModel, CancellationToken cancellationToken = default)
        {
            var room = await _roomRepository.GetFirstAsync(x=> x.Id == id); 
            _mapper.Map(room, updateRoomModel);
            return new UpdateRoomResponseModel
            {
                Id = (await _roomRepository.UpdateAsync(room)).Id,
            };
        }
    }
}
