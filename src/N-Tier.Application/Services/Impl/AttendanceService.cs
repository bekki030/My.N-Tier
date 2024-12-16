using AutoMapper;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Attendance;
using N_Tier.Application.Models.Exam;
using N_Tier.Core.Entities;
using N_Tier.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace N_Tier.Application.Services.Impl
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILessonRepository _lessonRepository;

        public AttendanceService(IMapper mapper, IAttendanceRepository repository, ILessonRepository lessonRepository)
        {
            _mapper = mapper;
            _repository = repository;
            _lessonRepository = lessonRepository;   
        }

        public async Task<CreateAttendanseResponseModel> CreateAsync(CreateAttendanceModel createAttendanceModel,
            CancellationToken cancellationToken = default)
        {
            var lesson = await _lessonRepository.GetFirstAsync(x=>x.Id == createAttendanceModel.LessonId);
            var attendance = _mapper.Map<Attendance>(createAttendanceModel);
            attendance.Lesson = lesson;
            var createdAttendance = await _repository.AddAsync(attendance);
            return new CreateAttendanseResponseModel
            {
                Id = createdAttendance.Id,
            };
        }

        public async Task<IEnumerable<AttendanceResponseModel>> GetAllByListIdAsync(Guid id,
            CancellationToken cancellationToken = default)
        {
            var attendances = await _repository.GetAllAsync(x => x.Id == id);
            return _mapper.Map<IEnumerable<AttendanceResponseModel>>(attendances);
        }

        public async Task<UpdateAttendanceResponseModel> UpdateAsync(Guid id, UpdateAttendanceModel updateAttendanceModel,
            CancellationToken cancellationToken = default)
        {
            var attendance = await _repository.GetFirstAsync(x => x.Id == id);
            if (attendance == null)
            {
                throw new KeyNotFoundException($"Attendance with ID {id} not found.");
            }

            _mapper.Map(updateAttendanceModel, attendance);
            var updatedAttendance = await _repository.UpdateAsync(attendance);
            return new UpdateAttendanceResponseModel
            {
                Id = updatedAttendance.Id,
            };
        }
    }
}
