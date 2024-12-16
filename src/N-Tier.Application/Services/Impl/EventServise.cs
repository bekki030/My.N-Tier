using AutoMapper;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Event;
using N_Tier.Core.Entities;
using N_Tier.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.Services.Impl
{
    public class EventServise : IEventServise
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;
        public EventServise(IMapper mapper,IEventRepository eventRepository, IStudentRepository studentRepository)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
            _studentRepository = studentRepository;
        }

        public async Task<CreateEventResponseModel> CreateAsync(CreateEventModel createEventModel, CancellationToken cancellationToken = default)
        {
            var student = await _studentRepository.GetFirstAsync(x=>x.Id == createEventModel.StudentId);
            var even = _mapper.Map<Event>(createEventModel);
            even.Student = student;
            return new CreateEventResponseModel
            {
                Id = (await _eventRepository.AddAsync(even)).Id,
            };
        }

        public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var even = await _eventRepository.GetFirstAsync(x => x.Id == id);
            return new BaseResponseModel
            {
                Id = (await _eventRepository.DeleteAsync(even)).Id,
            };
        }

        public async Task<IEnumerable<EventResponseModel>> GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var even = await _eventRepository.GetAllAsync(x => x.Id == id);
            return _mapper.Map<IEnumerable<EventResponseModel>>(even);
        }

        public async Task<UpdateEventResponseModel> UpdateAsync(Guid id, UpdateEventModel updateEventModel, CancellationToken cancellationToken = default)
        {
            var ever = await _eventRepository.GetFirstAsync(x=> x.Id == id);
            _mapper.Map(ever, updateEventModel);
            return new UpdateEventResponseModel
            {
                Id = (await _eventRepository.UpdateAsync(ever)).Id,
            };
        }
    }
}
